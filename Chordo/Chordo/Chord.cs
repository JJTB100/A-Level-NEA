using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordo
{
    internal class Chord
    {
        List<string> notes;
        int score;
        public string name;
        public Chord(string pName, int numNotes, string note1=null, string note2 = null, string note3 = null, string note4 = null, string note5 = null)
        {
            notes = new List<string>();
            AddNote(note1);
            AddNote(note2);
            AddNote(note3);
            AddNote(note4);
            AddNote(note5);
            name = pName;
        }

        /// <summary>
        /// Adds a note to the chord
        /// </summary>
        /// <param name="note"></param>
        internal void AddNote(string note)
        { 
            if(note != null)
            {
                notes.Add(note);
            }
        }

        internal IEnumerable<string> GetNotes()
        {
            return notes;
        }
    }
}