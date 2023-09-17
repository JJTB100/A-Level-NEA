using NAudio.Wave;

namespace PianoChordsGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = -1; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                var caps = NAudio.Wave.WaveIn.GetCapabilities(i);
                comboBox1.Items.Add($"{i}: {caps.ProductName}");
            }

        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            var waveIn = new NAudio.Wave.WaveInEvent
            {
                DeviceNumber = comboBox1.SelectedIndex, // indicates which microphone to use
                WaveFormat = new NAudio.Wave.WaveFormat(rate: 44100, bits: 16, channels: 1),
                BufferMilliseconds = 20
            };

            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.StartRecording();
        }
        void WaveIn_DataAvailable(object? sender, NAudio.Wave.WaveInEventArgs e)
        {
            // copy buffer into an array of integers
            Int16[] values = new Int16[e.Buffer.Length / 2];
            Buffer.BlockCopy(e.Buffer, 0, values, 0, e.Buffer.Length);

            Console.WriteLine(e.Buffer.ToString());
            float fraction = (float)(values.Max() / 32768 * 100);
            int percent = (int)Math.Ceiling(fraction);

            //output to volume meter
            pbVolume.Value = percent;
            string bar = new('#', (int)(fraction * 70));
            string meter = "[" + bar.PadRight(60, '-') + "]";
            Console.CursorLeft = 0;
            Console.CursorVisible = false;
            Console.Write($"{meter} {fraction * 100:00.0}%");
        }
    }

}