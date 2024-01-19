using NAudio.Wave;
using System.Windows.Forms;

namespace Chordo
{
    public partial class ChordoMain : Form
    {
        RevisionEngine Rev;
        Listener mic;
        int time;
        bool btnStartMode = true;
        int streak = 0;
        List<int> checkedPacks = new List<int>();
        /// <summary>
        /// gets the form going
        /// </summary>
        public ChordoMain()
        {

            InitializeComponent();
            lblErrorOut.Text = "Hi! Please select a pack to continue.";
            Rev = new RevisionEngine(lblErrorOut, clbPacks);
            

            //Presence check for a microphone
            WaveIn devCheck = new WaveIn();
            //tbc

            mic = new Listener();
            ResetAll();

        }
        /// <summary>
        /// Resets the time, chord text, screen colour
        /// </summary>
        void ResetAll()
        {
            pbFullHeart.Visible = false;
            pbEmptyHeart.Visible = true;
            time = 60;
            //lblChord.Text = "Press Start to continue";
            lblTimer.Text = "__";
            NoScreen();
        }
        /// <summary>
        /// Runs when the full heart is clicked, makes it an empty heart and unfavourites the chord
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbFullHeart_Click(object sender, EventArgs e)
        {
            Rev.MakeFavourite(false);
            pbFullHeart.Visible = false;
            pbEmptyHeart.Visible = true;
        }
        /// <summary>
        /// Runs when the empty heart is clicked, makes it full and favourits the chord
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbEmptyHeart_Click(object sender, EventArgs e)
        {
            Rev.MakeFavourite(true);
            pbFullHeart.Visible = true;
            pbEmptyHeart.Visible = false;
        }
        /// <summary>
        /// Runs on start or stop button clicked, if start button then initilise a lot of the microphone and revision engine, and load the chord packs in the checked list. 
        /// If the stop button, then stop listening reset stuff.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartStop_Click(object sender, EventArgs e)
        {

            if (btnStartMode)
            {
                checkedPacks = new List<int> { };
                //add each checked item to the list
                for (int x = 0; x < clbPacks.Items.Count; x++)
                {
                    if (clbPacks.GetItemChecked(x))
                    {
                        checkedPacks.Add(x);
                    }
                }
                //Shows error if no packs selected
                if (checkedPacks.Count == 0)
                {
                    MessageBox.Show("You must select at least 1 pack");
                }
                else
                {

                    //Start the mic listening and reset
                    mic.StartListening();
                    NewQuestion();
                    btnStartStop.Text = "Exit";
                    btnStartMode = false;
                }
            }
            else
            {
                //disable timers
                ListenTick.Enabled = false;
                CountdownTimer.Enabled = false;
                //stop listening
                mic.StopListening();
                ResetAll();
                btnStartStop.Text = "Start";
                btnStartMode = true;

            }

        }

        List<string> notesPlayed = new List<string>();

        public int MAXNOTESBEFOREINCORRECT = 7;

        public int QUESTION_TIMEOUT = 1000;
        /// <summary>
        /// runs at a regular interval based on the clock. analyses notes and checks whether they are in the chord or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenTick_Tick(object sender, EventArgs e)
        {
            //Listen for new chord on tick
            //Disable tick
            ListenTick.Enabled = false;
            //Listen
            List<string> notesFound = mic.ProcessData();
            //makes sure there are notes
            if (notesFound != null && notesFound.Count != 0)
            {
                //make sure none of the notes are repeated
                foreach (string note in notesFound)
                {
                    if (!notesPlayed.Contains(note))
                    {
                        notesPlayed.Add(note);
                    }
                }

                //                foreach (string note in notesPlayed) { Console.Write(note + ", "); }
                //check if the notes are in the chord and do stuff based on that
                bool correct = Rev.CheckNotes(notesPlayed);
                if (correct)
                {
                    CorrectScreen();
                    System.Threading.Thread.Sleep(QUESTION_TIMEOUT);

                    NewQuestion();
                }
                else if (notesPlayed.Count > MAXNOTESBEFOREINCORRECT)
                {
                    IncorrectScreen();
                    System.Threading.Thread.Sleep(QUESTION_TIMEOUT);

                    NewQuestion();
                }
            }

            //Enable tick
            ListenTick.Start();
        }
        /// <summary>
        /// Gives a new chord
        /// </summary>
        private void NewQuestion()
        {
            ResetAll();
            //Display Chord
            lblChord.Text = Rev.NextChord(checkedPacks).name.ToString();
            //Update the favourite icon accordingly
            if (Rev.GetCurrentChord().IsFav() == true)
            {
                pbEmptyHeart.Visible = false;
                pbFullHeart.Visible = true;
            }
            //Start timer countdown from 60
            CountdownTimer.Enabled = true;
            notesPlayed = new List<string>();
            ListenTick.Enabled = true;

            int x = 2;
            Console.WriteLine($"Chord Name: {Rev.GetCurrentChord().name}\nFavourite: {Rev.GetCurrentChord().IsFav()}\nScore: {Rev.GetCurrentChord().score}\nNotes: {Rev.GetCurrentChord().GetNotesAsString()}");
        }
        /// <summary>
        /// Displays the correct screen
        /// </summary>
        private void CorrectScreen()
        {
            Rev.CalcChordScore(60 - time);
            lblChord.BackgroundImage = new Bitmap(Chordo.Properties.Resources.GreenTick);
            lblChord.BackgroundImageLayout = ImageLayout.Zoom;
            streak++;
            lblStreak.Text = streak.ToString();
            Application.DoEvents();
        }
        /// <summary>
        /// Displays the incorrect screen
        /// </summary>
        private void IncorrectScreen()
        {
            Rev.CalcChordScore(60);
            lblChord.BackgroundImage = new Bitmap(Chordo.Properties.Resources.RedCross);
            lblChord.BackgroundImageLayout = ImageLayout.Zoom;
            streak = 0;
            lblStreak.Text = streak.ToString();
            Application.DoEvents();

        }
        /// <summary>
        /// Undisplays the tick/cross
        /// </summary>
        private void NoScreen()
        {
            lblChord.BackgroundImage = null;
            lblChord.BackgroundImageLayout = ImageLayout.Zoom;
            Application.DoEvents();

        }
        /// <summary>
        /// Runs every time the countdown timer ticks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            time--;
            lblTimer.Text = time.ToString();
            if (time < 0)
            {
                IncorrectScreen();
                System.Threading.Thread.Sleep(QUESTION_TIMEOUT);

                NewQuestion();

            }
        }
        /// <summary>
        /// Runs on press of the skip button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSkip_Click(object sender, EventArgs e)
        {
            IncorrectScreen();
            System.Threading.Thread.Sleep(QUESTION_TIMEOUT);

            NewQuestion();
        }


    }
}