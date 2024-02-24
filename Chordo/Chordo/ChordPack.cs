namespace Chordo
{   
    /// <summary>
    /// A collection of chords
    /// </summary>
    internal class ChordPack
    {
        List<Chord> chords;
        string name;
        /// <summary>
        /// Constructor for if the chords in the pack are known
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pChords"></param>
        public ChordPack(string pName, List<Chord> pChords)
        {
            name = pName;
            chords = pChords;
        }
        /// <summary>
        /// Constructor for if the chords aren't known
        /// </summary>
        /// <param name="pName"></param>
        public ChordPack(string pName)
        {
            name = pName;
            chords = new List<Chord>();
        }
        /// <summary>
        /// Adds a chord to the pack
        /// </summary>
        /// <param name="chord"></param>
        internal void AddChord(Chord chord)
        {
            chords.Add(chord);
        }
        /// <summary>
        /// Returns the list of chord in the pack
        /// </summary>
        /// <returns></returns>
        public List<Chord> GetChords()
        {
            return chords;
        }
        /// <summary>
        /// ToString override prints name and chord count
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string send = $"Chord Pack, '{name}', has {chords.Count} Chords in it";
            return send;
        }
    }
}
