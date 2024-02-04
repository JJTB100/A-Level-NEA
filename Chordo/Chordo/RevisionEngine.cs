using System.Text.RegularExpressions;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using CsvHelper;
using System.Globalization;

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
            for (int i = 0; i < packs.Count; i++)
            {
                AllChords.AddRange(packs[i].GetChords());
            }
            LoadUserData(@"..\..\..\..\UserData.csv");
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
        /// <summary>
        /// Saves the Chord data to a csv file
        /// </summary>
        /// <param name="address"></param>
        private void SaveUserData(string address)
        {
            //new csv file
            using (var writer = new StreamWriter(address))

            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {

                csv.Context.RegisterClassMap<ChordMap>();
                csv.WriteRecords(AllChords);

            }
        }
        /// <summary>
        /// loads the user data from address
        /// </summary>
        /// <param name="address"></param>
        private void LoadUserData(string address)
        {
            if(File.Exists(address))
            {
                //open csv
                using (var reader = new StreamReader(address))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<ChordMap>();
                    //get chords
                    var records = csv.GetRecords<Chord>();
                    //iterate over chords
                    foreach(var record in records)
                    {
                        //give current chords new values
                        foreach (var OldChord in FindChords(record.name))
                        {
                            OldChord.score = record.score;
                            OldChord.favourite = record.favourite;
                            OldChord.time = record.time;
                            OldChord.timesPlayed = record.timesPlayed;
                            OldChord.name = record.name;
                        }
                    }
                }
            }

        }
        /// <summary>
        /// Finds all the chords in AllChords with a specific name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List of Chords</returns>
        private List<Chord> FindChords(string name)
        {
            List<Chord> returnValues = new List<Chord>();
            foreach(var chord in AllChords)
            {
                if(chord.name == name)
                {
                    returnValues.Add(chord);
                }
            }
            return returnValues;
        }
        private Chord prevChord;
        Random r = new Random();
        /// <summary>
        /// Chooses a next new chord, uses score
        /// </summary>
        /// <param name="chosenPacks"></param>
        /// <returns></returns>
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

            //save user data
            SaveUserData(@"..\..\..\..\UserData.csv");

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
        /// <summary>
        /// Calculates a new score for the chord
        /// </summary>
        /// <param name="time"></param>
        public void CalcChordScore(int time)
        {
            // keep track of timesPlayed
            currentChord.timesPlayed++;
            int favBoost = 0;
            // check if it's favourited or not
            if (currentChord.favourite)
            {
                favBoost = 1;

            }
            // calc score ( a number between 0 and 1)
            double score = (timeEffect * (time/15) + prevTimeEffect * (currentChord.time/15) + favouriteEffect * (favBoost)) / currentChord.timesPlayed;
            Console.WriteLine($"SCORE CALC: new TIME: {time}, Prev TIME: {currentChord.time}, favBoost: {favBoost}, times Played: {currentChord.timesPlayed}, score: {score}");

            // store score and time
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
