using GameLogic;

namespace AmericanCheckers
{
    public partial class GameSetting : Form
    {
        public GameSetting()
        {
            InitializeComponent();
        }

        private enum eBoardSize
        {
            RadioButtonSize6 = 6,
            RadioButtonSize8 = 8,
            RadioButtonSize10 = 10,
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(Player2CheckBox.Checked)
            {
                Player2TextBox.Enabled = true;
                Player2TextBox.Text = null;
            }
            else
            {
                Player2TextBox.Enabled = false;
                Player2TextBox.Text = "[Computer]";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ButtonDone_Click(object sender, EventArgs e)
        {
            string checkedRadioButton = string.Empty;
            eBoardSize boardSize;

            foreach (Control control in this.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Checked)
                    {
                        checkedRadioButton = radioButton.Name;
                    }
                }
            }

            boardSize = (eBoardSize)Enum.Parse(typeof(eBoardSize), checkedRadioButton);
            this.Hide();
            Game currentGame = new Game(this.Player1TextBox.Text, this.Player2TextBox.Text, (int)boardSize, !this.Player2CheckBox.Checked);
            this.Close();
        }

        private void Player2TextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Player1TextBox_TextChanged(object sender, EventArgs e)
        {
        }
    }
}