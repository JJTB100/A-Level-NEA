namespace Chordo
{
    internal class ChordPack
    {
        List<Chord> chords;
        string name;
        public ChordPack(string pName, List<Chord> pChords)
        {
            name = pName;
            chords = pChords;
        }
        public ChordPack(string pName)
        {
            name = pName;
            chords = new List<Chord>();
        }

        internal void AddChord(Chord chord)
        {
            chords.Add(chord);
        }

        public List<Chord> GetChords()
        {
            return chords;
        }

        public override string ToString()
        {
            string send = $"Chord Pack, '{name}', has {chords.Count} Chords in it";
            return send;
        }
    }
}
