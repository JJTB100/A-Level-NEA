using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoChordsGame
{
    internal class Chord
    {
        string[] notes;
        int score;
        public Chord(int numNotes, string note1, string note2 = null, string note3 = null, string note4 = null, string note5 = null) 
        {
            switch (numNotes)
            {
                case 1:
                    notes = new string[] { note1 };
                    break;
                case 2:
                    notes = new string[] { note1, note2 };
                    break;
                case 3:
                    notes = new string[] { note1, note2, note3 };
                    break;
                case 4:
                    notes = new string[] { note1, note2, note3, note4 };
                    break;
                case 5:
                    notes = new string[] { note1, note2, note3, note4, note5 };
                    break;

            }
        }
    }
}
