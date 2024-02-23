using Accord.Math;
using Accord.Statistics;
using CsvHelper.Configuration.Attributes;
using Microsoft.VisualBasic.Logging;
using NAudio.Wave;

namespace Chordo
{
    public class Listener
    {
        //Declare classes and variables
        public WaveIn waveIn;
        public BufferedWaveProvider bwp;
        private int RATE;
        private int BUFFERSIZE;
        public int DEVICENUMBER;
        private double threshold;
        double[] hannWindow;
        public double minAmplitude;

        /// <summary>
        /// Consructor - instantiates helper classes with values given, starts buffer.
        /// </summary>
        /// <param name="pBUFFERSIZE">Size of the buffer each sample | default: 8192 bytes</param>
        /// <param name="pRATE">sample rate of the wave | default = 44100Hz</param>
        /// <param name="pDeviceNumber">The device number of the microphone | default = 1</param>
        public Listener(int pBUFFERSIZE = 8192, int pRATE = 44100, int pDeviceNumber = 1, double minAmplitude = 0)
        {
            RATE = pRATE;
            BUFFERSIZE = pBUFFERSIZE;

            // Initialise WaveIn class
            waveIn = new WaveIn
            {
                DeviceNumber = DEVICENUMBER,
                WaveFormat = new WaveFormat(RATE, 1)
            };
            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
            this.minAmplitude = minAmplitude;
        }
        /// <summary>
        /// Event handler that activates when there is data available in the class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void waveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            //Add data to buffer
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }
        /// <summary>
        /// Starts listening to the mic
        /// </summary>
        public void StartListening()
        {
            // Starts the buffer
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            bwp.BufferLength = BUFFERSIZE * 2;
            bwp.DiscardOnBufferOverflow = true;
            // Starts recording the wave
            waveIn.StartRecording();
        }
        /// <summary>
        /// Stops listening to the mic
        /// </summary>
        public void StopListening()
        {
            waveIn.StopRecording();
        }
        /// <summary>
        /// finds what note is a frequency by using midi nums. Contains validation to discard notes if they are too far away from the actual frequency.
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public string WhatNoteAmI(double frequency)
        {
            // Calculate MIDInum
            double MIDInum = 12 * Math.Log2((double)frequency / (double)440) + 69;
            // Validation: too far away from actual frequency
            if(Math.Abs(MIDInum - Math.Round(MIDInum))>(0.3))
            {
                return null;
            }
            // Round the MIDInum
            int MIDInumRounded = (int)Math.Round(MIDInum);
            string[] notes = { "A", "A♯", "B", "C", "C♯", "D", "D♯", "E", "F", "F♯", "G", "G♯" };
            // find the note
            string note = notes[((MIDInumRounded - 21) % 12)];
            return note;
        }
        /// <summary>
        /// Process the data on tick
        /// </summary>
        /// <returns></returns>
        public List<string> ProcessData()
        {

            //read bytes from bwp into frames
            int frameSize = BUFFERSIZE;
            var frames = new byte[frameSize];
            bwp.Read(frames, 0, frameSize);

            //check that the buffer isn't empty
            if (frames.Length == 0) return null;
            //if (frames[frameSize - 2] == 0) return null;

            //pull PCM values from the buffer
            // incoming data is 16-bit (2 bytes per audio point)
            int BYTES_PER_POINT = 2;
            // create a (32-bit) int array ready to fill with the 16-bit data
            int PointCount = frames.Length / BYTES_PER_POINT;

            // Generate the Hanning Window
            GenerateHannWindow();

            // Get the pcm values from the wave
            double[] pcm = CalculatePCMValues(frames, PointCount);
            
            // Apply the Hann Window
            for (int i = 0; i < hannWindow.Length; i++)
            {
                pcm[i] *= hannWindow[i];
            }

            // Get the fftReal Values
            double[] fftReal = CalculateFFTRealValues(frames, PointCount, pcm);
            // Adjust for Db
            double[] fftDb = DbScale(fftReal);
            // Normalise 0-1
            fftDb.Normalize(true);

            //double[] hps = CalculateHPS(fftReal);
            //double[] NormalisedHPS = hps.Normalize();

            // Return the notes played
            return PullNotes(fftDb, fftDb, PointCount);
        }
        /// <summary>
        /// Normalise
        /// </summary>
        /// <param name="hps"></param>
        /// <returns></returns>
        private double[] Normalise(double[] hps)
        {
            double[] Nhps = new double[hps.Length];
            //using z-score normalisation
            //calculate mean and standard deviation of the hps
            double meanHps = hps.Mean();
            double stdHps = hps.StandardDeviation();
            //foreach element, center the values around the mean with a std dev of 1
            for(int i = 0;i < Nhps.Length;i++)
            {
                Nhps[i] = (hps[i]-meanHps) / stdHps;
            }
            return Nhps;
        }
        
        private double[] CalculateHPS(double[] fftReal)
        {
            //Iterate through the positive half of the fft array
            double[] hps = new double[fftReal.Length];
            for (int i = 1; i < hps.Length; i++)
            {

                if (fftReal[i]<minAmplitude)
                {
                    fftReal[i] = 0;
                }
                // Iterate through its harmonics (j = i, j = 2 * i, j = 3 * i, ...)
                for (int j = i; j < fftReal.Length; j += i)
                {
                    // Multiply magnitudes of frequency and its harmonic:
                    {
                        hps[i] += fftReal[i] * fftReal[j];
                        fftReal[j] = 0;
                    }

                }
            }

            return hps;
        }
        

        public double[] CalculatePCMValues(byte[] frames, int PointCount)
        {


            double[] pcm = new double[PointCount];

            for (int i = 0; i < PointCount; i++)
            {
                // read the int16 from the two bytes
                var val = BitConverter.ToInt16(frames, i * 2);

                // store the value
                pcm[i] = (double)(val);

            }


            return pcm;
        }
        //Some code borrowed from ScottPlot
        private void GenerateHannWindow()
        {
            hannWindow = new double[BUFFERSIZE / 2];
            var angleUnit = 2 * Math.PI / (hannWindow.Length - 1);
            for (int i = 0; i < hannWindow.Length; i++)
            {
                hannWindow[i] = 0.5 * (1 - Math.Cos(i * angleUnit));
            }
        }
        //End of code borrowed from ScottPlot
        public double[] CalculateFFTRealValues(byte[] frames, int PointCount, double[] pcm)
        {
            double[] fftReal = new double[PointCount / 2];

            //get fft values
            var fft = FFT(pcm);
            Array.Copy(fft, fftReal, fftReal.Length);
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
        /// <summary>
        /// Get the notes from an array of fft values, including validation: variable threshold, 
        /// </summary>
        /// <returns></returns>
        public List<string> PullNotes(double[] hps, double[] fftIn, int PointCount)
        {
            int PrevI = 0;
            List<string> notes = new List<string>();
            threshold = Calibrate(hps);
            for (int i = 0; i < fftIn.Length; i++)
            {
                if (hps[i] >= threshold && i > 10 && i-PrevI>5)
                {
                    double frequency = (i * RATE) / PointCount;
                    if (frequency != 0)
                    {
                        Console.WriteLine("Freq:" + frequency + " " + i + " " + fftIn[i] + " " + threshold + " " + minAmplitude);
                    }
                    string note = WhatNoteAmI(frequency);
                    if (note != null)
                    {
                        if (!notes.Contains(note))
                        {
                            notes.Add(note);
                        }
                    }
                    PrevI = i;
                }
            }
            

            return notes;

        }

        private double Calibrate(double[] fftIn)
        {
            double highest=0;
            double secondHighest = 0;
            double thirdHighest = 0;
            double fourthHighest = 0;

            for (int i = 0; i < fftIn.Length; i++)
            {
                if (fftIn[i] > highest)
                {
                    fourthHighest = thirdHighest;
                    thirdHighest = secondHighest;
                    secondHighest = highest; 
                    highest = fftIn[i];
                    
                }
                else if (fftIn[i] > secondHighest)
                {
                    fourthHighest = thirdHighest;
                    thirdHighest = secondHighest;
                    secondHighest = fftIn[i];
                }

                else if (fftIn[i] > highest)
                {
                    fourthHighest = thirdHighest;
                    thirdHighest = fftIn[i];
                }

                if (fftIn[i] > highest)
                {
                    fourthHighest = fftIn[i];
                }
            }
            return highest;
            //Console.WriteLine(fourthHighest + " " + thirdHighest + " "+  secondHighest + " "+ highest);
            if (fourthHighest > minAmplitude)
            {
                return fourthHighest;

            }
            else if(thirdHighest > minAmplitude)
            {
                return thirdHighest;
            }
            else if(secondHighest > minAmplitude)
            {
                return secondHighest;
            }
            else if (highest > minAmplitude)
            {
                return highest;
            }
            else { return 1000000; }
        }
    }
}
