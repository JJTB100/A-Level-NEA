namespace Chordo
{
    internal class Chord
    {
        List<string> notes;
        public double score;
        public string name;
        public bool favourite;

        public int time = 60;
        public int timesPlayed = 0;

        public Chord(string pName, int numNotes, string note1 = null, string note2 = null, string note3 = null, string note4 = null, string note5 = null)
        {
            notes = new List<string>();
            AddNote(note1);
            AddNote(note2);
            AddNote(note3);
            AddNote(note4);
            AddNote(note5);
            name = pName;
            score = 0.6;
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

        internal List<string> GetNotes()
        {
            return notes;
        }
    }
}