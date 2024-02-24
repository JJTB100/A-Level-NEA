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
        double Sensitivity;
        /// <summary>
        /// If True, Start when btn pressed, if false, stop.
        /// </summary>
        bool btnStartMode = true;
        int streak = 0;
        List<int> checkedPacks = new List<int>();
        public static int MAXTIMEALLOWED = 15; //seconds
        /// <summary>
        /// gets the form going
        /// </summary>
        public ChordoMain()
        {
            // Start Form & Engines
            InitializeComponent();
            lblHelper.Text = "Hi! Please select at least one chord pack (on the left) to continue.";
            Rev = new RevisionEngine(lblErrorOut, clbPacks);

            mic = new Listener();
            mic.minAmplitude = (double)sensitivitySlider.Value / 100;
            // Reset to start
            ResetAll();

        }
        /// <summary>
        /// Resets the time, chord text, screen colour
        /// </summary>
        void ResetAll()
        {
            // Reset Heart to empty
            btnHeart.BackgroundImage = Resources.emptyHeart_removebg_preview;
            // reset time to max
            time = MAXTIMEALLOWED;
            lblTimer.Text = "__";
            lblTimer.ForeColor = Color.Black;
            // Reset visual feedback
            NoScreen();
        }
        /// <summary>
        /// On heart button clicked, favourite or unfavourite the chord
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHeart_Click(object sender, EventArgs e)
        {
            // if it's not favourited already, favourite and change heart colour
            if (Rev.GetCurrentChord().favourite == false)
            {
                btnHeart.BackgroundImage = Resources.heart_removebg_preview;
                lblHelper.Text = "Chord Favourited! You should see this chord more from now on.";
                Rev.MakeFavourite(true);
            }
            // else unfavourite it and change to empty heart
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

        // Pause length between questiosn
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
                string notesToOut = "";
                foreach (string note in notesPlayed) { notesToOut += note; }
                foreach (string note in notesPlayed) { Console.Write(note + ", "); }
                lblErrorOut.Text = "Notes Played: " + notesToOut;
                Console.WriteLine();
                //check if the notes are in the chord and do stuff based on that
                bool correct = Rev.CheckNotes(notesPlayed);
                if (correct)
                {
                    CorrectScreen();
                    QuestionTimeOut();

                    NewQuestion();
                }
                else if (notesPlayed.Count > MAXNOTESBEFOREINCORRECT)
                {
                    IncorrectScreen();
                    QuestionTimeOut();

                    NewQuestion();
                }
            }

            //Enable tick
            ListenTick.Start();
        }
        /// <summary>
        /// Pause the system and streak displayed if multiple of 5 
        /// </summary>
        private void QuestionTimeOut()
        {
            if (streak % 5 == 0 && streak != 0)
            {
                lblChord.Text = $"Your streak is {streak}!";
                lblChord.Font = new Font("Segoe Print", 24, FontStyle.Bold);
                Application.DoEvents();
                System.Threading.Thread.Sleep(QUESTION_TIMEOUT);
                lblChord.Font = new Font("Segoe Print", 72, FontStyle.Bold);


            }
            System.Threading.Thread.Sleep(QUESTION_TIMEOUT);
        }
        /// <summary>
        /// Gives a new chord
        /// </summary>
        private void NewQuestion()
        {
            ResetAll();
            //Display Chord
            lblChord.Text = Rev.NextChord(checkedPacks).name.ToString();
            //set the colour of the chord to the colour relative to the score
            int red = (int)Math.Round(255 * (Rev.GetCurrentChord().score));
            //Color color = Color.FromArgb(red, 128, 128);
            //lblChord.ForeColor = color;

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
            // check if time has run out
            if (time < 0)
            {
                IncorrectScreen();
                QuestionTimeOut();

                NewQuestion();

            }
            // check if time is almost out
            if (time < 5)
            {
                lblTimer.ForeColor = Color.Red;

                lblTimer.Font = new Font("Russo One", 72, FontStyle.Underline);
            }
            lblTimer.Text = time.ToString();


        }
        /// <summary>
        /// Runs on press of the skip button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSkip_Click(object sender, EventArgs e)
        {
            IncorrectScreen();
            QuestionTimeOut();

            NewQuestion();
        }
        /// <summary>
        /// Runs on index changed of pack selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clbPacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update help messages
            if (btnStartMode)
            {
                lblHelper.Text = "Great! You've selected a chord pack! If you're happy with your selection, get your piano ready and press 'Start'!";
            }
            else
            {
                lblHelper.Text = "To change the chords you're playing, press stop, then select them.";
            }
        }
        /// <summary>
        /// on change of sens slider, change mic amp mins
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sensitivitySlider_Scroll(object sender, EventArgs e)
        {
            mic.minAmplitude = (double)sensitivitySlider.Value / 100;
        }
        /// <summary>
        /// Toggle high contrast button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToggleHighContrast_Click(object sender, EventArgs e)
        {

            if (lblChord.BackColor == SystemColors.Control)
            {
                lblChord.BackColor = SystemColors.ControlText;
                lblChord.ForeColor = SystemColors.Control;
            }
            else
            {
                lblChord.BackColor = SystemColors.Control;
                lblChord.ForeColor = SystemColors.ControlText;
            }
        }
    }
}