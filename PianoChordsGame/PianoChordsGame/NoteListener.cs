using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoChordsGame
{
    internal class NoteListener
    {
        public WaveIn waveIn;
        public BufferedWaveProvider bwp;
        private int RATE;
        private int BUFFERSIZE;
        public int DEVICENUMBER;

        public NoteListener(int pBUFFERSIZE, int pRATE=44100, int pDeviceNumber=1)
        {
            RATE = pRATE;
            BUFFERSIZE = pBUFFERSIZE;

            //initialise WaveIn class
            waveIn = new WaveIn
            {
                DeviceNumber = DEVICENUMBER,
                WaveFormat = new WaveFormat(RATE, 1)
            };

            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
        }
        private void waveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            //Add data to buffer
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }
        
        public void StartListening()
        {
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            bwp.BufferLength = BUFFERSIZE * 2;
            bwp.DiscardOnBufferOverflow = true;
            waveIn.StartRecording();
        }
        public string WhatNoteAmI(double frequency)
        {
            double MIDInum = 12 * Math.Log2((double)frequency / (double)440) + 69;
            int MIDInumRounded = (int)Math.Round(MIDInum);
            string[] notes = { "A", "A#/Bb", "B", "C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G", "G#/Ab" };
            string note = notes[((MIDInumRounded - 21) % 12)];
            return note;
        }
        public List<string> ProcessData(ScottPlot.FormsPlot ScottFFT, ScottPlot.FormsPlot ScottPCM)
        {
            //read bytes from bwp into frames
            int frameSize = BUFFERSIZE;
            var frames = new byte[frameSize];
            bwp.Read(frames, 0, frameSize);

            //check that the buffer isn't empty
            if (frames.Length == 0) return null;
            if (frames[frameSize - 2] == 0) return null;

          
            //pull PCM values from the buffer
            // incoming data is 16-bit (2 bytes per audio point)
            int BYTES_PER_POINT = 2;

            // create a (32-bit) int array ready to fill with the 16-bit data
            int PointCount = frames.Length / BYTES_PER_POINT;

            double[] pcm = CalculatePCMValues(frames, PointCount);
            double[] fftDb = DbScale(CalculateFFTValues(frames, PointCount, pcm));

            double fftMaxFreq = RATE / 2;
            double pcmPointSpacingMs = RATE / 1000;
            double fftPointSpacingHz = fftMaxFreq / PointCount;

            ScottPCM.Plot.Clear();
            ScottFFT.Plot.Clear();
            ScottPCM.Plot.AddSignal(pcm, pcmPointSpacingMs);
            ScottFFT.Plot.AddSignal(fftDb, fftPointSpacingHz);
            ScottFFT.Plot.SetAxisLimits(0, 200, -50, 5);
            ScottPCM.Plot.SetAxisLimits(0, 100, -10, 10);
            ScottPCM.Refresh();
            ScottFFT.Refresh();

            return PullNotes(fftDb, PointCount);
        }

        public double[] CalculatePCMValues(byte[] frames, int PointCount)
        {

           
            double[] pcm = new double[PointCount];

            for (int i = 0; i < PointCount; i++)
            {
                // read the int16 from the two bytes
                var val = BitConverter.ToInt16(frames, i * 2);

                // store the value in Ys as a percent
                pcm[i] = (double)(val) / Math.Pow(2, 16) * 100.0;

            }


            return pcm;
        }
        public double[] CalculateFFTValues(byte[] frames, int PointCount, double[] pcm)
        {
            double[] fftReal = new double[PointCount / 2];

            //get fft values
            var fft = FFT(pcm);
            Array.Copy(fft, fftReal, fftReal.Length);
            foreach(double item in fftReal)
            {
                Console.WriteLine(item);
            }
            return fftReal;
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

        public double[] DbScale(double[] fftReal)
        {
            double[] fftRealDB = new double[fftReal.Length];

            int a = 0;
            foreach (var f in fftReal)
            {
                var y = (Math.Log10(f) * 10);
                fftRealDB[a] = y;
                a++;
            }

            return fftRealDB;

        }

        public List<string> PullNotes(double[] fftRealDB, int PointCount)
        {
            List<string> notes = new List<string>();
            for (int i = 0; i < fftRealDB.Length; i++)
            {
                if (fftRealDB[i] > 0 && i > 10)
                {
                    int frequency = (i * RATE) / PointCount;
                    string note = WhatNoteAmI(frequency);
                    if (!notes.Contains(note))
                    {
                        notes.Add(note);
                    }
                }
            }
            return notes;

        }
    }
}
