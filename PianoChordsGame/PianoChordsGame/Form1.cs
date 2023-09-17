using NAudio.Wave;

namespace PianoChordsGame
{
    public partial class Form1 : Form
    {
        public WaveIn waveIn;
        public BufferedWaveProvider bwp;
        private int RATE = 44100;
        private int BUFFERSIZE = (int)Math.Pow(2, 13);

        public Form1()
        {
            InitializeComponent();
            for (int i = -1; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                var caps = NAudio.Wave.WaveIn.GetCapabilities(i);
                comboBox1.Items.Add($"{i}: {caps.ProductName}");
            }
            comboBox1.SelectedIndex = 1;
            //initialise WaveIn class
            waveIn = new WaveIn
            {
                DeviceNumber = comboBox1.SelectedIndex - 1,
                WaveFormat = new WaveFormat(RATE, 1)
            };
            SetupGraphLabels();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            //start sound buffer
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
            bwp.BufferLength = BUFFERSIZE * 2;

            bwp.DiscardOnBufferOverflow = true;
            waveIn.StartRecording();
            btnStart.Enabled = false;
            timerUpdateGraph.Start();

        }

        private void waveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            //Add data to buffer
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        private void timerUpdateGraph_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("TICK");
            //read bytes from bwp into frames
            int frameSize = BUFFERSIZE;
            var frames = new byte[frameSize];
            bwp.Read(frames, 0, frameSize);

            //check that the buffer isn't empty
            if (frames.Length == 0) return;
            if (frames[frameSize - 2] == 0) return;

            timerUpdateGraph.Enabled = false; //disable timer whilst maths happens

            //pull PCM values from the buffer
            // incoming data is 16-bit (2 bytes per audio point)
            int BYTES_PER_POINT = 2;

            // create a (32-bit) int array ready to fill with the 16-bit data
            int graphPointCount = frames.Length / BYTES_PER_POINT;

            // create double array to hold the data we will graph
            double[] pcm = new double[graphPointCount];

            // populate Xs and Ys with double data
            for (int i = 0; i < graphPointCount; i++)
            {
                // read the int16 from the two bytes
                var val = BitConverter.ToInt16(frames, i * 2);

                // store the value in Ys as a percent (+/- 100% = 200%)
                pcm[i] = (double)(val) / Math.Pow(2, 16) * 200.0;

            }

            // determine horizontal axis units for graph
            double pcmPointSpacingMs = RATE / 1000;

            // plot the Xs and Ys for both graphs
            ScottPCM.Plot.Clear();
            ScottPCM.Plot.AddSignal(pcm, pcmPointSpacingMs);
            ScottPCM.Plot.AxisAuto();
            ScottPCM.Refresh();

            //re-enable timer
            timerUpdateGraph.Enabled = true;


            Application.DoEvents();

        }
        public void SetupGraphLabels()
        {
            ScottPCM.Plot.Title("Microphone PCM Data");
            ScottPCM.Plot.YLabel("Amplitude (PCM)");
            ScottPCM.Plot.XLabel("Time (ms)");
        }
    }

}