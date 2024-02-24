using Accord;
using System.Web;

namespace Chordo
{
    /// <summary>
    /// Chord Object 
    /// </summary>
    internal class Chord
    {
        List<string> notes;
        public double score;
        public string name;
        public bool favourite;

        public int time = ChordoMain.MAXTIMEALLOWED;
        public int timesPlayed = 0;
        /// <summary>
        /// Construct the chord
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="numNotes"></param>
        /// <param name="note1"></param>
        /// <param name="note2"></param>
        /// <param name="note3"></param>
        /// <param name="note4"></param>
        /// <param name="note5"></param>
        public Chord(string pName, int numNotes, string note1 = null, string note2 = null, string note3 = null, string note4 = null, string note5 = null)
        {     
            notes = new List<string>();
            AddNote(note1);
            AddNote(note2);
            AddNote(note3);
            AddNote(note4);
            AddNote(note5);
            name = pName;
            score = 0;
            

        }
        public Chord()
        {
            
        }


        /// <summary>
        /// Adds a note to the chord
        /// </summary>
        /// <param name="note"></param>
        internal void AddNote(string note)
        {
            if (note != null)
            {
                notes.Add(note);
            }
        }
        /// <summary>
        /// Returns all the notes in the chord
        /// </summary>
        /// <returns>List<String> notes</returns>
        internal List<string> GetNotes()
        {
            return notes;
        }

        /// <summary>
        /// Returns the notes in the chord as a string
        /// </summary>
        /// <returns></returns>
        internal string GetNotesAsString()
        {
            string output = "";
            foreach (string note in notes)
            {
                output += note + ", ";
            }
            return output;
        }

        /// <summary>
        /// Returns true/false dependant on the chord's favourite state
        /// </summary>
        /// <returns></returns>
        internal bool IsFav()
        {
            return favourite;
        }
    }
}