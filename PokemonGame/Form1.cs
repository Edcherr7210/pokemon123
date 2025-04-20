namespace PokemonGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //This Code should go in each Form to make the form full Screen.
            //It allows the border to pass the taskbar so the taskbar won't get in the way
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void butQuit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks for Playing!");
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Rules = new Rules();
            Rules.Closed += (s, args) => this.Close();
            Rules.Show();
        }

        private void butPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Choose_your_team = new Choose_your_team();
            Choose_your_team.Closed += (s, args) => this.Close();
            Choose_your_team.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
