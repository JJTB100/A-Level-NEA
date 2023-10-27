namespace Chordo
{
    public partial class ChordoMain : Form
    {
        public ChordoMain()
        {
            InitializeComponent();
        }

        private void btnToggleMusic_Click(object sender, EventArgs e)
        {

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
    }
}