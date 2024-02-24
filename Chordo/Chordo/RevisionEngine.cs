using System.Text.RegularExpressions;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using CsvHelper;
using System.Globalization;

namespace Chordo
{
    /// <summary>
    /// The class that handles learning and chord output
    /// </summary>
    internal class RevisionEngine
    {
        // Numbers between 0 and 1 that describes how much the different variables affects the chord's score
        double timeEffect = 0.5;
        double prevTimeEffect = 0.5;
        double favouriteEffect = 0.5;
        List<ChordPack> packs = new List<ChordPack>();
        Chord currentChord;
        public List<Chord> AllChords;
        Label ErrorOut;
        /// <summary>
        /// Constructor, loads chords from file
        /// </summary>
        /// <param name="pErrorOut">Where errors should be outputted</param>
        /// <param name="clbPacks">The listbox of packs</param>
        public RevisionEngine(Label pErrorOut, ListBox clbPacks )
        {
            this.ErrorOut = pErrorOut;
            AllChords = new List<Chord>();
            // Iterate over the files in the folder
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
            // Foreach pack add the chords to a complete list of all chords
            for (int i = 0; i < packs.Count; i++)
            {
                AllChords.AddRange(packs[i].GetChords());
            }
            // load any pre-existing data
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
            // Read Text from file
            string packText = File.ReadAllText(packAddress);
            // match the regex
            MatchCollection matches = ScanChordsReg.Matches(packText);

            // display error if no matches
            if (matches.Count == 0)
            {
                ErrorOut.Text = $"The chordpack {packAddress} didn't contain valid data or was empty.";
                return null;
            }

            // make new pack where name is the first line
            ChordPack pack = new(File.ReadLines(packAddress).First());

            // for each chord, match
            foreach (Match match in matches)
            {   
                // match will be in format {CDName} {CDNumNotes} {CDNote 1} {Note 2} .. { Note x} 
                string CDname = match.Groups[1].Value;
                int CDnumNotes = int.Parse(match.Groups[2].Value);
                string CDnote1 = match.Groups[3].Value;

                // Instantiate the chord
                Chord CD = new Chord(CDname, CDnumNotes, CDnote1);

                // add each note
                for (int i = 1; i < CDnumNotes; i++)
                {
                    CD.AddNote(match.Groups[i + 3].Value);
                }

                // Add the chord to the pack
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
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    // Write the chords to the csv file according to the map
                    csv.Context.RegisterClassMap<ChordMap>();
                    csv.WriteRecords(AllChords);

                }
            }
        }
        /// <summary>
        /// loads the user data from address
        /// </summary>
        /// <param name="address"></param>
        private void LoadUserData(string address)
        {
            // Check if the file exists
            if(File.Exists(address))
            {
                // Open csv
                using (var reader = new StreamReader(address))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<ChordMap>();
                    // Get chords
                    var records = csv.GetRecords<Chord>();
                    // Iterate over chords
                    foreach(var record in records)
                    {
                        // Give current chords new values
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
        /// Returns all the chords in AllChords with a specific name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List of Chords</returns>
        private List<Chord> FindChords(string name)
        {
            List<Chord> returnValues = new List<Chord>();

            // Linear Search
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
            // Make a list of possible chords
            List<Chord> possibleChords = new List<Chord>();
            for (int i = 0; i < packs.Count; i++)
            {
                if (chosenPacks.Contains(i))
                {
                    possibleChords.AddRange(packs[i].GetChords());
                }
            }
            // Remove previous chord from list
            if (possibleChords.Contains(prevChord))
            {
                possibleChords.Remove(prevChord);
            }

            // Choose a chord
            // Order the chords by descended score
            possibleChords = possibleChords.OrderBy(a => r.Next()).ToList();
            possibleChords = possibleChords.OrderBy(x => x.score).ToList();
            possibleChords.Reverse();
            int num=0;
            // Choose the first, second or third chord
            if (!(possibleChords.Count < 2))
            {
                num = r.Next(0, 2);
            }
            currentChord = possibleChords[num];
            prevChord = currentChord;

            // Save user data
            SaveUserData(@"..\..\..\..\UserData.csv");

            return currentChord;

        }

        /// <summary>
        /// Checks if the notes played are in the current chord
        /// </summary>
        /// <param name="notesPlayed">These are the notes that should be checked</param>
        /// <returns></returns>
        internal bool CheckNotes(List<string> notesPlayed)
        {
            // Linear Search
            foreach (string note in currentChord.GetNotes())
            {
                // If not in notes
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
            // Keep track of timesPlayed
            currentChord.timesPlayed++;
            int favBoost = 0;
            // Check if it's favourited or not
            if (currentChord.favourite)
            {
                favBoost = 1;

            }
            // Calc score ( a number between 0 and 1)
            double score = (timeEffect * (time / 15) + prevTimeEffect * (currentChord.time / 15) + favouriteEffect * (favBoost)) / currentChord.timesPlayed;
            // DEBUGGING:
            Console.WriteLine($"SCORE CALC: new TIME: {time}, Prev TIME: {currentChord.time}, favBoost: {favBoost}, times Played: {currentChord.timesPlayed}, score: {score}");

            // Store score and time
            currentChord.score = score;
            currentChord.time = time;
        }
        /// <summary>
        /// Gets the current chord
        /// </summary>
        /// <returns>currentChord</returns>
        internal Chord GetCurrentChord()
        {
            return currentChord;
        }
        /// <summary>
        /// makes the current chord favourited
        /// </summary>
        /// <param name="v"></param>
        internal void MakeFavourite(bool v)
        {
            currentChord.favourite = v;
        }
    }
}
