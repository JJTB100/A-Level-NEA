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

        /// <summary>
        /// Consructor - instantiates helper classes with values given, starts buffer.
        /// </summary>
        /// <param name="pBUFFERSIZE">Size of the buffer each sample | default: 8192 bytes</param>
        /// <param name="pRATE">sample rate of the wave | default = 44100Hz</param>
        /// <param name="pDeviceNumber">The device number of the microphone | default = 1</param>
        public Listener(int pBUFFERSIZE = 8192, int pRATE = 44100, int pDeviceNumber = 1)
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

        public void StartListening()
        {
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            bwp.BufferLength = BUFFERSIZE * 2;
            bwp.DiscardOnBufferOverflow = true;
            waveIn.StartRecording();
        }
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
            double MIDInum = 12 * Math.Log2((double)frequency / (double)440) + 69;
            //Validation: too far away from actaul frequency
            if(MIDInum - Math.Round(MIDInum)>Math.Abs(0.7))
            {
                return null;
            }
            int MIDInumRounded = (int)Math.Round(MIDInum);
            string[] notes = { "A", "A♯", "B", "C", "C♯", "D", "D♯", "E", "F", "F♯", "G", "G♯" };
            string note = notes[((MIDInumRounded - 21) % 12)];
            return note;
        }

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
            //Console.WriteLine(PointCount);

            double[] pcm = CalculatePCMValues(frames, PointCount);
            double[] fftDb = DbScale(CalculateFFTValues(frames, PointCount, pcm));

            double fftMaxFreq = RATE / 2;
            double pcmPointSpacingMs = RATE / 1000;
            double fftPointSpacingHz = fftMaxFreq / PointCount;

            double[][] eventData = { pcm, fftDb, new[] { pcmPointSpacingMs }, new[] { fftPointSpacingHz } };
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
        /// <param name="fftRealDB"></param>
        /// <param name="PointCount"></param>
        /// <returns></returns>
        public List<string> PullNotes(double[] fftRealDB, int PointCount)
        {
            List<string> notes = new List<string>();
            threshold = Calibrate(fftRealDB);
            for (int i = 0; i < fftRealDB.Length; i++)
            {
                if (fftRealDB[i] > threshold && i > 10)
                {
                    
                    int frequency = (i * RATE) / PointCount;
                    string note = WhatNoteAmI(frequency);
                    if(note != null)
                    {
                        if (!notes.Contains(note))
                        {
                            notes.Add(note);
                        }
                    }

                }
            }
            return notes;

        }

        private double Calibrate(double[] fftRealDB)
        {
            double highest=0;
            double secondHighest = 0;
            double thirdHighest = 0;
            double fourthHighest = 0;
            for (int i = 0; i < fftRealDB.Length; i++)
            {
                if (fftRealDB[i] > highest)
                {
                    highest = fftRealDB[i];
                }
                else if (fftRealDB[i] > secondHighest){
                    secondHighest = fftRealDB[i];
                }
                else if (fftRealDB[i] > thirdHighest)
                {
                    thirdHighest = fftRealDB[i];
                }
                else if (fftRealDB[i] > fourthHighest)
                {
                    fourthHighest = fftRealDB[i];
                }
            }
            return fourthHighest;
        }
    }
}
