using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05_UI;
using TicTacToe;

namespace Ex05_UI
{
    public partial class FormGameSettings : Form
    {
        private Game m_game = null;

        public FormGameSettings(Game i_game)
        {
            m_game = i_game;
            InitializeComponent();
        }

        private void FormGameSettings_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox v_CheckBoxPlayer2 = sender as CheckBox;

            if(v_CheckBoxPlayer2.Checked)
            {
                textBoxPlayer2.Enabled = true;
                textBoxPlayer2.Text = "";
            }

            else
            {
                textBoxPlayer2.Enabled = false;
                textBoxPlayer2.Text = "[Computer]";
            }
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCols.Value = numericUpDownRows.Value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownRows.Value = numericUpDownCols.Value;
        }

        private void TextBoxPlayer1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPlayer2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            bool v_IsAgainstComputer = !checkBoxPlayer2.Checked;

            m_game.Start((uint)numericUpDownRows.Value);
            if(v_IsAgainstComputer)
            {
                textBoxPlayer2.Text = "Computer";
            }

            m_game.PlayersSet(v_IsAgainstComputer, textBoxPlayer1.Text, textBoxPlayer2.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
