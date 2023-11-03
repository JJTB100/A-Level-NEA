using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Chordo
{
    internal class RevisionEngine
    {
        List<ChordPack> packs = new List<ChordPack>();

        public RevisionEngine()
        {
            packs.Add(loadChords("MajorChordsPack.txt"));
            //packs.Add(new ChordPack("Major", ));
            
        }
        Regex ScanChordsReg = new Regex("(.+), (\\d), (.+), (.+), (.+);");
        /// <summary>
        /// Loads all the chords in a pack from a text file, using REGEX. Text File in format "name, numNotes, note1{, note2, note3, note4, note5}\n"
        /// </summary>
        /// <param name="packAddress"></param>
        /// <returns>a chord pack</returns>
        /// <exception cref="NotImplementedException"></exception>
        private ChordPack loadChords(string packAddress)
        {
            //Read Text from file
            string packText = File.ReadAllText(packAddress);
            MatchCollection matches = ScanChordsReg.Matches(packText);
            ChordPack pack = new(File.ReadLines(packAddress).First(), null);

            //for each chord, match
            foreach (Match match in matches)
            {
                string CDname = match.Groups[ 1].Value;
                int CDnumNotes = int.Parse(match.Groups[ 2].Value);
                string CDnote1 = match.Groups[3].Value;

                Chord CD = new Chord(CDname, CDnumNotes, CDnote1);

                //add each note
                for (int i=0; i<CDnumNotes; i++)
                {
                    CD.AddNote(match.Groups[i+3].Value);
                }
            }
            return pack;
        }
    }
}
