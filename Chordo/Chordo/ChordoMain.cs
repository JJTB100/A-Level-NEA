using Chordo.Properties;
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
        public static int MAXTIMEALLOWED = 15; //seconds
        /// <summary>
        /// gets the form going
        /// </summary>
        public ChordoMain()
        {
            InitializeComponent();
            lblHelper.Text = "Hi! Please select at least one chord pack (on the left) to continue.";
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
            btnHeart.BackgroundImage = Resources.emptyHeart_removebg_preview;
            time = MAXTIMEALLOWED;
            lblTimer.Text = "__";
            lblTimer.ForeColor = Color.Black;
            NoScreen();
        }
        private void btnHeart_Click(object sender, EventArgs e)
        {
            if (Rev.GetCurrentChord().favourite == false)
            {
                btnHeart.BackgroundImage = Resources.heart_removebg_preview;
                lblHelper.Text = "Chord Favourited! You should see this chord more from now on.";
                Rev.MakeFavourite(true);

            }
            else
            {
                btnHeart.BackgroundImage = Resources.emptyHeart_removebg_preview;
                lblHelper.Text = "Chord Unfavourited!";
                Rev.MakeFavourite(false);

            }
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
                    lblErrorOut.Text = "You must select at least one chord pack to continue";
                }
                else
                {
                    lblHelper.Text = "Play the chord before the time runs out!";
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

        public int MAXNOTESBEFOREINCORRECT = 100;

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
                foreach (string note in notesPlayed) { Console.Write(note + ", "); }
                Console.WriteLine();
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
                btnHeart.BackgroundImage = Resources.heart_removebg_preview;
            }
            //Start timer countdown from MAXTIMEALLOWED
            CountdownTimer.Enabled = true;
            notesPlayed = new List<string>();
            ListenTick.Enabled = true;

            int x = 2;
            Console.WriteLine($"Chord Name: {Rev.GetCurrentChord().name}\nFavourite: {Rev.GetCurrentChord().IsFav()}\nScore: {Rev.GetCurrentChord().score}\nNotes: {Rev.GetCurrentChord().GetNotesAsString()}\nTimes Played: {Rev.GetCurrentChord().timesPlayed}");
        }
        /// <summary>
        /// Displays the correct screen
        /// </summary>
        private void CorrectScreen()
        {
            Rev.CalcChordScore(MAXTIMEALLOWED - time);
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
            Rev.CalcChordScore(MAXTIMEALLOWED);
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
            if (time < 0)
            {
                IncorrectScreen();
                System.Threading.Thread.Sleep(QUESTION_TIMEOUT);

                NewQuestion();

            }
            if (time < 5 )
            {
                lblTimer.ForeColor = Color.Red;

                lblTimer.Font = new Font("Russo One", 72, FontStyle.Underline);
            }
            lblTimer.Text = time.ToString();
            System.Threading.Thread.Sleep(500);
            lblTimer.Font = new Font("Russo One", 72, FontStyle.Bold);
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
        private void clbPacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblHelper.Text = "Great! You've selected a chord pack! If you're happy with your selection, get your piano ready and press 'Start'!";
        }
    }
}