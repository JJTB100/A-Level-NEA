namespace Chordo
{
    public partial class ChordoMain : Form
    {
        RevisionEngine Rev;

        public ChordoMain()
        {
            InitializeComponent();
            Rev = new RevisionEngine();
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
            //Display Chord
            //Get new chord from engine
            Chord next = Rev.NextChord();
            lblChord.Text = next.name.ToString();
            //Display chord name
        }
    }
}