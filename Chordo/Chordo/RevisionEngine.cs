using System.Text.RegularExpressions;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Chordo
{
    internal class RevisionEngine
    {
        double timeEffect = 0.5;//Numbers between 0 and 1 that describes how much the previous time effects the chord's score
        double prevTimeEffect = 0.5;
        double favouriteEffect = 0.5;
        List<ChordPack> packs = new List<ChordPack>();
        Chord currentChord;
        public List<Chord> AllChords;
        Label ErrorOut;
        public RevisionEngine(Label pErrorOut, ListBox clbPacks )
        {
            this.ErrorOut = pErrorOut;
            AllChords = new List<Chord>();
            foreach (string file in Directory.EnumerateFiles(@"..\..\..\..\Packs"))
            {
                
                //validation, don't add if pack hasn't got chords in it
                ChordPack? chordpck = (loadChords($"{file}"));
                if (chordpck != null)
                {
                    clbPacks.Items.Add(File.ReadLines(file).First());
                    packs.Add(chordpck);
                }
                

            }
        }
        Regex ScanChordsReg = new Regex("(.+), (\\d), (.+), (.+), (.+);");
        /// <summary>
        /// Loads all the chords in a pack from a text file, using REGEX. Text File in format "name, numNotes, note1{, note2, note3, note4, note5}\n"
        /// </summary>
        /// <param name="packAddress"></param>
        /// <returns>a chord pack</returns>
        /// <exception cref="NotImplementedException"></exception>
        private ChordPack? loadChords(string packAddress)
        {
            //Read Text from file
            string packText = File.ReadAllText(packAddress);
            
            MatchCollection matches = ScanChordsReg.Matches(packText);

            if (matches.Count == 0)
            {
                ErrorOut.Text = $"The chordpack {packAddress} didn't contain valid data or was empty.";
                return null;
            }
            ChordPack pack = new(File.ReadLines(packAddress).First());

            

            //for each chord, match
            foreach (Match match in matches)
            {
                string CDname = match.Groups[1].Value;
                int CDnumNotes = int.Parse(match.Groups[2].Value);
                string CDnote1 = match.Groups[3].Value;

                Chord CD = new Chord(CDname, CDnumNotes, CDnote1);

                //add each note
                for (int i = 1; i < CDnumNotes; i++)
                {
                    CD.AddNote(match.Groups[i + 3].Value);
                }
                pack.AddChord(CD);
            }

            return pack;
        }
        private void SaveUserData(string address)
        {
            //open csv file
            /*format:
             * chordName, score, favourite
             */
            List<string> memory = File.ReadLines(address).ToList();
            string[,] mem2d = new string[memory.Count, 3];
            //seperate into 2d array
            for (int i = 0; i < memory.Count(); i++)
            {
                for (int j = 0; j < memory[i].Split(",").Count(); j++)
                {
                    mem2d[i, j] = memory[i].Split(",")[j];
                }
            }
            //check if chord is in db

            foreach (Chord chord in AllChords)
            {
                bool found = false;
                for(int i=0; i<memory.Count(); i++)
                {
                    if (mem2d[i, 0] == (chord.name))
                    {
                        //if it is, change the score and fav state
                        mem2d[i, 1] = chord.score.ToString();
                        mem2d[i, 2] = chord.favourite.ToString();
                        found = true;
                    }
                }
                if (!found)
                {
                    //if it isn't, add it
                    
                }

            }
        }
        private Chord prevChord;
        Random r = new Random();
        public Chord NextChord(List<int> chosenPacks)
        {
            //make a list of possible chordsD
            List<Chord> possibleChords = new List<Chord>();
            for (int i = 0; i < packs.Count; i++)
            {
                AllChords.AddRange(packs[i].GetChords());
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
            possibleChords = possibleChords.OrderBy(a => r.Next()).ToList();
            possibleChords = possibleChords.OrderBy(x => x.score).ToList();
            possibleChords.Reverse();
            int num=0;
            if (!(possibleChords.Count < 2))
            {
                num = r.Next(0, 2);
            }
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
        public void CalcChordScore(int time)
        {
            currentChord.timesPlayed++;
            int favBoost = 0;
            if (currentChord.favourite)
            {
                favBoost = 100;

            }
            double score = (timeEffect * (time) + prevTimeEffect * (currentChord.time) + favouriteEffect * (favBoost)) / 100 * currentChord.timesPlayed;
            currentChord.score = score;
            currentChord.time = time;
        }

        internal Chord GetCurrentChord()
        {
            return currentChord;
        }

        internal void MakeFavourite(bool v)
        {
            currentChord.favourite = v;
        }
    }
}
