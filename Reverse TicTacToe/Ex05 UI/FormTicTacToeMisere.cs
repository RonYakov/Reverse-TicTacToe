using System;
using System.Drawing;
using System.Windows.Forms;
using TicTacToe;

namespace Ex05_UI
{
    public partial class FormTicTacToeMisere : Form
    {
        private enum e_PlayerIndicator { Player1, Player2 };

        private Game m_Game = null;
        private int k_ButtonHeight = 60;
        private int k_ButtonWidth = 70;
        private int k_AdditionalHeightPixel = 90;
        private int k_AdditionalWidthPixel = 40;
        private int k_Spacing = 8;
        private e_PlayerIndicator m_PlayerIndicator;
        private bool m_IsAgainstComputer;
        private Button[,] m_Buttons;

        public FormTicTacToeMisere(Game i_Game)
        {
            m_Game = i_Game;
            m_PlayerIndicator = e_PlayerIndicator.Player1;
            m_IsAgainstComputer = m_Game.Player2.Type == Player.k_Computer;
            m_Buttons = new Button[(int)m_Game.BoardSize, (int)m_Game.BoardSize];
            InitializeComponent();
            makeFormStyle();
            makeTicTacToeBoard();
        }

        private void makeFormStyle()
        {
            int v_BoardSize = (int)m_Game.BoardSize;

            Size = new Size(k_ButtonWidth * v_BoardSize + k_AdditionalWidthPixel, k_ButtonHeight * v_BoardSize + k_AdditionalHeightPixel);
            MinimumSize = Size;
            MaximumSize = Size;
            labelPlayer1.Text = string.Format("{0}: {1}", m_Game.Player1.Name, m_Game.Player1.Score);
            labelPlayer2.Text = string.Format("{0}: {1}", m_Game.Player2.Name, m_Game.Player2.Score);
            labelPlayer1.Left = Size.Width / 2 - k_Spacing - labelPlayer1.Width;
            labelPlayer2.Left = Size.Width / 2 + k_Spacing;
        }

        private void makeTicTacToeBoard()
        {
            int v_BoardSize = (int)m_Game.BoardSize;

            tableLayoutPanelTicTacToeBoard.ColumnCount = v_BoardSize;
            tableLayoutPanelTicTacToeBoard.RowCount = v_BoardSize;
            tableLayoutPanelTicTacToeBoard.Size = new Size(k_ButtonWidth * v_BoardSize, k_ButtonHeight * v_BoardSize);
            for(int i = 0; i < v_BoardSize; i++) 
            {
                tableLayoutPanelTicTacToeBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, k_ButtonWidth));
                tableLayoutPanelTicTacToeBoard.RowStyles.Add(new RowStyle(SizeType.Absolute, k_ButtonHeight));
                for (int j = 0; j < v_BoardSize; j++)
                {
                    Button v_Button = new Button();
                    v_Button.Name = string.Format("{0}{1}", i, j);
                    v_Button.Dock = DockStyle.Fill;
                    tableLayoutPanelTicTacToeBoard.Controls.Add(v_Button, j, i);
                    v_Button.Click += button_OnClick;
                    m_Buttons[i, j] = v_Button;
                }
            }
        }

        private void FormTicTacToeMisere_Load(object sender, EventArgs e)
        {

        }

        private void button_OnClick(object sender, EventArgs e)
        {
            Button v_Button = sender as Button;
            
            v_Button.Enabled = false;
            if(m_PlayerIndicator == e_PlayerIndicator.Player1)
            {
                v_Button.Text = "X";
                makePlayerTurn(v_Button);
                if (m_IsAgainstComputer)
                {
                    makeComputerTurn();
                }
                else
                {
                    m_PlayerIndicator = e_PlayerIndicator.Player2;
                }
            }
            else
            {
                v_Button.Text = "O";
                m_PlayerIndicator = e_PlayerIndicator.Player1;
                makePlayerTurn(v_Button);
            }
        }

        private void makeComputerTurn()
        {
            int v_RowNum, v_ColNum;
            eTurnStatus v_TurnStatus;

            v_TurnStatus = Game.Turn.ComputerAction(m_Game, out v_RowNum, out v_ColNum);
            m_Buttons[v_RowNum, v_ColNum].Enabled = false;
            m_Buttons[v_RowNum, v_ColNum].Text = "O";
            gameResult(v_TurnStatus);
        }

        private void makePlayerTurn(Button i_Button)
        {
            int v_RowNum, v_ColNum;
            eTurnStatus v_TurnStatus;

            getIndexesFromButtonName(i_Button, out v_RowNum, out v_ColNum);
            v_TurnStatus = Game.Turn.PlayerAction(m_Game, (uint)v_RowNum, (uint)v_ColNum);
            gameResult(v_TurnStatus);
        }

        private void gameResult(eTurnStatus i_TurnStatus)
        {
            switch (i_TurnStatus)
            {
                case eTurnStatus.Tie:
                    tieMessage();
                    endOfRound();
                    break;

                case eTurnStatus.Loser:
                    m_Game.WhoIsWaiting().UpdateWin();
                    winnerMessage();
                    endOfRound();
                    break;

                default:
                    break;
            }
        }

        private void tieMessage()
        {
            DialogResult v_Result = MessageBox.Show("Tie!\nWould you like to play another round?", "A Tie!", MessageBoxButtons.YesNo);
            if (v_Result == DialogResult.No)
            {
                this.Close();
            }
        }

        private void winnerMessage()
        {
            DialogResult v_Result = MessageBox.Show(string.Format("The winner is {0}!\nWould you like to play another round?", m_Game.CurrentWinner), "A Win!", MessageBoxButtons.YesNo);
            if (v_Result == DialogResult.No)
            {
                this.Close();
            }
        }

        private void endOfRound()
        {
            foreach(Button v_Button in m_Buttons)
            {
                v_Button.Enabled = true;
                v_Button.Text = "";
            }

            labelPlayer1.Text = string.Format("{0}: {1}", m_Game.Player1.Name, m_Game.Player1.Score);
            labelPlayer2.Text = string.Format("{0}: {1}", m_Game.Player2.Name, m_Game.Player2.Score);
            m_Game.EndRound();
        }

        private void getIndexesFromButtonName(Button i_Button, out int o_RowNum, out int o_ColNum) 
        {
            o_RowNum = i_Button.Name[0] - '0' + 1;
            o_ColNum = i_Button.Name[1] - '0' + 1;
        }
    }
}
