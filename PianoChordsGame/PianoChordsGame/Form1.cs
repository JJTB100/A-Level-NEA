using Accord.Math;
using NAudio.Wave;
using ScottPlot;

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
            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
            SetupGraphLabels();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            //start sound buffer
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);

            bwp.BufferLength = BUFFERSIZE * 2;

            bwp.DiscardOnBufferOverflow = true;
            waveIn.StartRecording();
            btnStart.Enabled = false;
            timerUpdateGraph.Start();



        }
        private string WhatNoteAmI(double frequency)
        {
            double MIDInum = 12 * Math.Log2((double)frequency / (double)440) + 69;
            int MIDInumRounded = (int)Math.Round(MIDInum);
            string[] notes = { "A", "A#/Bb", "B", "C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G", "G#/Ab" };
            string note = notes[((MIDInumRounded-21) % 12)];
            lblNotesPlayed.Text = note;
            return note;
        }

        private void waveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            //Add data to buffer
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        private void timerUpdateGraph_Tick(object sender, EventArgs e)
        {
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

            // create double array to hold the data to graph
            double[] pcm = new double[graphPointCount];
            double[] fftReal = new double[graphPointCount / 2];

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

            //get fft values
            var fft = FFT(pcm);
            double fftMaxFreq = RATE / 2;
            double fftPointSpacingHz = fftMaxFreq / graphPointCount;
            Array.Copy(fft, fftReal, fftReal.Length);


            double[] fftRealDB = new double[fftReal.Length];

            int a = 0;
            foreach (var f in fftReal)
            {
                var y = (Math.Log10(f) * 10);
                fftRealDB[a] = y;
                a++;
            }

            // plot the Xs and Ys for both graphs
            ScottPCM.Plot.Clear();
            ScottFFT.Plot.Clear();
            ScottPCM.Plot.AddSignal(pcm, pcmPointSpacingMs);
            ScottFFT.Plot.AddSignal(fftRealDB, fftPointSpacingHz);
            ScottFFT.Plot.SetAxisLimits(0, 400, -50, 5);
            ScottPCM.Plot.SetAxisLimits(0, 100, -1, 1);

            ScottPCM.Refresh();
            ScottFFT.Refresh();

            //re-enable timer
            timerUpdateGraph.Enabled = true;

            for(int i = 0; i < fftReal.Length; i++)
            {
                if (fftRealDB[i] > 0 && i > 10)
                {
                    int frequency = (i * RATE) / graphPointCount;
                    Console.WriteLine(frequency);
                    WhatNoteAmI(frequency);
                }
            }


            Application.DoEvents();

        }
        public void SetupGraphLabels()
        {
            ScottPCM.Plot.Title("Microphone PCM Data");
            ScottPCM.Plot.YLabel("Amplitude (PCM)");
            ScottPCM.Plot.XLabel("Time (ms)");
            ScottFFT.Plot.Title("Microphone FFT Data");
            ScottFFT.Plot.YLabel("Power (raw)");
            ScottFFT.Plot.XLabel("Frequency (Hz)");
            ScottFFT.Plot.SetAxisLimits(0, 1000, 0, 10);
        }
        public double[] FFT(double[] data)
        {
            double[] fft = new double[data.Length];
            System.Numerics.Complex[] fftComplex = new System.Numerics.Complex[data.Length];
            for (int i = 0; i < data.Length; i++)
                fftComplex[i] = new System.Numerics.Complex(data[i], 0.0);
            Accord.Math.FourierTransform.FFT(fftComplex, Accord.Math.FourierTransform.Direction.Forward);
            for (int i = 0; i < data.Length; i++)
                fft[i] = fftComplex[i].Magnitude;
            return fft;
        }

    }

}