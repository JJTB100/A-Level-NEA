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

        public ChordoMain()
        {

            InitializeComponent();
            Rev = new RevisionEngine();
            //get packs available
            foreach (string file in Directory.EnumerateFiles(@"..\..\..\..\Packs"))
            {
                clbPacks.Items.Add(File.ReadLines(file).First());
            }

            mic = new Listener();
            ResetAll();

        }
        void ResetAll()
        {
            time = 60;
            lblChord.Text = "Press Start to continue";
            lblTimer.Text = "__";
            NoScreen();
        }
        private void pbFullHeart_Click(object sender, EventArgs e)
        {
            pbFullHeart.Visible = false;
            pbEmptyHeart.Visible = true;
        }

        private void pbEmptyHeart_Click(object sender, EventArgs e)
        {
            pbFullHeart.Visible = true;
            pbEmptyHeart.Visible = false;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartMode)
            {
                for (int x = 0; x < clbPacks.Items.Count; x++)
                {
                    if (clbPacks.GetItemChecked(x))
                    {
                        checkedPacks.Add(x);
                    }
                }
                if (checkedPacks.Count == 0)
                {
                    MessageBox.Show("You must select at least 1 pack");
                }
                else
                {
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

        private void ListenTick_Tick(object sender, EventArgs e)
        {
            //Listen for new chord on tick
            //Disable tick
            ListenTick.Enabled = false;
            //Listen
            List<string> notesFound = mic.ProcessData();
            if (notesFound != null && notesFound.Count != 0)
            {
                foreach (string note in notesFound)
                {
                    if (!notesPlayed.Contains(note))
                    {
                        notesPlayed.Add(note);
                    }
                }

                foreach (string note in notesPlayed) { Console.Write(note + ", "); }
                Console.WriteLine();
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

        private void NewQuestion()
        {
            ResetAll();
            //Display Chord
            lblChord.Text = Rev.NextChord(checkedPacks).name.ToString();

            //Start timer countdown from 60
            CountdownTimer.Enabled = true;
            notesPlayed = new List<string>();
            ListenTick.Enabled = true;
        }

        private void CorrectScreen()
        {
            Console.WriteLine("Correct");
            lblChord.BackgroundImage = new Bitmap(Chordo.Properties.Resources.GreenTick);
            lblChord.BackgroundImageLayout = ImageLayout.Zoom;
            streak++;
            lblStreak.Text = streak.ToString();
            Application.DoEvents();
        }
        private void IncorrectScreen()
        {
            lblChord.BackgroundImage = new Bitmap(Chordo.Properties.Resources.RedCross);
            lblChord.BackgroundImageLayout = ImageLayout.Zoom;
            streak = 0;
            lblStreak.Text = streak.ToString();
            Application.DoEvents();

        }
        private void NoScreen()
        {
            lblChord.BackgroundImage = null;
            lblChord.BackgroundImageLayout = ImageLayout.Zoom;
            Application.DoEvents();

        }
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            time--;
            Console.WriteLine(time);
            lblTimer.Text = time.ToString();
            if (time < 0)
            {
                IncorrectScreen();
                System.Threading.Thread.Sleep(QUESTION_TIMEOUT);

                NewQuestion();

            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            IncorrectScreen();
            System.Threading.Thread.Sleep(QUESTION_TIMEOUT);

            NewQuestion();
        }
    }
}