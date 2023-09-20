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
        public void OnTick()
        {
            //read bytes from bwp into frames
            int frameSize = BUFFERSIZE;
            var frames = new byte[frameSize];
            bwp.Read(frames, 0, frameSize);

            //check that the buffer isn't empty
            if (frames.Length == 0) return;
            if (frames[frameSize - 2] == 0) return;

            //pull PCM values from the buffer
            // incoming data is 16-bit (2 bytes per audio point)
            int BYTES_PER_POINT = 2;

            // create a (32-bit) int array ready to fill with the 16-bit data
            int PointCount = frames.Length / BYTES_PER_POINT;

            // create double arrays to hold the data
            double[] pcm = new double[PointCount];
            double[] fftReal = new double[PointCount / 2];
        }

    }
}
