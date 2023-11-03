using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        internal void AddChord(Chord chord)
        {
            chords.Add(chord);
        }
    }
}
