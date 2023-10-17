using Accord.Math;
using NAudio.Wave;
using ScottPlot;
using ScottPlot.MarkerShapes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Manufaktura.Controls;
using Manufaktura.Controls.Model;
using Manufaktura.Music.Model.MajorAndMinor;
using Manufaktura.Music.Model;

namespace PianoChordsGame
{

    public partial class Form1 : Form
    {
        NoteListener Listener;
        List<string> notesPlayed;
        public Form1()
        {
            InitializeComponent();
            for (int i = -1; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                var caps = NAudio.Wave.WaveIn.GetCapabilities(i);
                comboBox1.Items.Add($"{i}: {caps.ProductName}");
            }
            comboBox1.SelectedIndex = 1;

            Listener = new NoteListener((int)Math.Pow(2, 13));

            SetupGraphLabels();

            notesPlayed = new List<string>();

        }

        public void Li_PlotNew(object self, double[][] data)
        {
            ScottFFT.Plot.Clear();
            ScottFFT.Plot.AddSignal(data[1], data[3][0]);
            ScottFFT.Plot.SetAxisLimits(0, 200, -50, 5);
            ScottFFT.Refresh();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            //start sound buffer
            Listener.StartListening();

            btnStart.Enabled = false;

            timerUpdateGraph.Start();
        }

        private void timerUpdateGraph_Tick(object sender, EventArgs e)
        {

            timerUpdateGraph.Enabled = false; //disable timer whilst maths happens

            Listener.Plotting += Li_PlotNew;

            notesPlayed = Listener.ProcessData();

            string notesDisplay;
            if (notesPlayed != null && notesPlayed.Count != 0)
            {
                notesDisplay = "";
                foreach (string note in notesPlayed)
                {
                    notesDisplay += note + ", ";
                }

                lblNotesPlayed.Text = notesDisplay;
            }

            //re-enable timer
            timerUpdateGraph.Enabled = true;

            Application.DoEvents();

        }
        public void SetupGraphLabels()
        {
            ScottFFT.Plot.Title("Microphone FFT Data");
            ScottFFT.Plot.YLabel("Power (raw)");
            ScottFFT.Plot.XLabel("Frequency (KHz)");
        }

    }

}