using System.Text.RegularExpressions;

namespace Chordo
{
    internal class RevisionEngine
    {
        List<ChordPack> packs = new List<ChordPack>();
        Chord currentChord;
        public RevisionEngine()
        {
            foreach (string file in Directory.EnumerateFiles(@"..\..\..\..\Packs"))
            {
                packs.Add(loadChords($"{file}"));
                
            }
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
            ChordPack pack = new(File.ReadLines(packAddress).First());

            //for each chord, match
            foreach (Match match in matches)
            {
                string CDname = match.Groups[1].Value;
                int CDnumNotes = int.Parse(match.Groups[2].Value);
                string CDnote1 = match.Groups[3].Value;

                Chord CD = new Chord(CDname, CDnumNotes, CDnote1);

                //add each note
                for (int i = 0; i < CDnumNotes; i++)
                {
                    CD.AddNote(match.Groups[i + 3].Value);
                }
                pack.AddChord(CD);
            }

            return pack;
        }
        private Chord prevChord;
        public Chord NextChord(List<int> chosenPacks)
        {
            //make a list of possible chordsD
            List<Chord> possibleChords = new List<Chord>();
            for (int i = 0; i < packs.Count; i++)
            {
                if (chosenPacks.Contains(i))
                {
                    possibleChords.AddRange(packs[i].GetChords());
                }
            }
            //remove previous chord from list
            if (possibleChords.Contains(prevChord))
            {
                possibleChords.Remove(prevChord);
            }

            //choose a chord
            Random r = new Random();
            int num = r.Next(0, possibleChords.Count);
            Console.WriteLine(possibleChords.Count);
            currentChord = possibleChords[num];
            prevChord = currentChord;
            return currentChord;

        }

        internal bool CheckNotes(List<string> notesPlayed)
        {
            foreach (string note in currentChord.GetNotes())
            {
                //if not in notes
                if (!notesPlayed.Contains(note))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
