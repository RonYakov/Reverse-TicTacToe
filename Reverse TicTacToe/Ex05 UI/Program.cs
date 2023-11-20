using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe;

namespace Ex05_UI
{
    internal class Program
    {
        public static void Main() 
        {
            Game game = new Game();
            DialogResult v_Result;

            FormGameSettings formTestLogIn = new FormGameSettings(game);
            v_Result = formTestLogIn.ShowDialog();

            if(v_Result == DialogResult.OK)
            {
                FormTicTacToeMisere formTicTacToeMisere = new FormTicTacToeMisere(game);
                formTicTacToeMisere.ShowDialog();
            }
        }
    }
}
