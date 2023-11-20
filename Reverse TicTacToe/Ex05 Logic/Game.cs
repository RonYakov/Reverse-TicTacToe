
using System;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    public class Game
    {
        private Player m_Player1 = new Player();
        private Player m_Player2 = new Player();
        private int m_PlayerIndicator = 0;
        private MatrixGameCell[,] m_GameMatrix = null;
        private uint m_BoardSize;
        private string m_CurrentWinner = null;
        

        public class Turn
        {
            public static eTurnStatus PlayerAction(Game i_Game, uint i_RowNum, uint i_ColNum)
            {
                eTurnStatus v_WhatIsTheGameStatus;

                i_RowNum--;
                i_ColNum--;
                i_Game.updatePlayerIndicator();
                i_Game.m_GameMatrix[i_RowNum, i_ColNum].Value = i_Game.WhoIsPlaying().Symbol;
                v_WhatIsTheGameStatus = SequenceChecker.UpdateBoardAndLooserChecker(i_RowNum, i_ColNum, (int)i_Game.WhoIsPlaying().ID);
                if(v_WhatIsTheGameStatus == eTurnStatus.Loser || v_WhatIsTheGameStatus == eTurnStatus.Quit)
                {
                    i_Game.CurrentWinner = i_Game.WhoIsWaiting().Name;
                }

                return v_WhatIsTheGameStatus;
            }

            public static eTurnStatus ComputerAction(Game i_Game, out int o_Row, out int o_Column)
            {
                Random random = new Random();
                bool v_FoundEmptyCell = false;
                eTurnStatus v_WhatIsTheGameStatus;

                i_Game.updatePlayerIndicator();
                o_Row = random.Next(i_Game.m_GameMatrix.GetLength(0));
                o_Column = random.Next(i_Game.m_GameMatrix.GetLength(1));
                while (!v_FoundEmptyCell)
                {
                    if (i_Game.m_GameMatrix[o_Row, o_Column].IsEmpty())
                    {
                        i_Game.m_GameMatrix[o_Row, o_Column].Value = i_Game.WhoIsPlaying().Symbol;
                        v_FoundEmptyCell = true;
                    }
                    else
                    {
                        o_Row = random.Next(i_Game.m_GameMatrix.GetLength(0));
                        o_Column = random.Next(i_Game.m_GameMatrix.GetLength(1));
                    }
                }

                v_WhatIsTheGameStatus = SequenceChecker.UpdateBoardAndLooserChecker((uint)o_Row, (uint)o_Column, (int)i_Game.WhoIsPlaying().ID);
                if (v_WhatIsTheGameStatus == eTurnStatus.Loser || v_WhatIsTheGameStatus == eTurnStatus.Quit)
                {
                    i_Game.CurrentWinner = i_Game.WhoIsWaiting().Name;
                }

                return v_WhatIsTheGameStatus;
            }
        }

        internal MatrixGameCell[,] Matrix
        {
            get
            {
                return m_GameMatrix;
            }
            set
            {
                m_GameMatrix = value;
            }
        }
        public Player Player1
        {
            get
            {
                return m_Player1;
            }
            set
            {
                m_Player1 = value;
            }
        }
        public Player Player2
        {
            get
            {
                return m_Player2;
            }
            set
            {
                m_Player2 = value;
            }
        }
        public uint BoardSize
        {
            get
            {
                return m_BoardSize;
            }
        }

        public string CurrentWinner
        {
            get 
            {
                return m_CurrentWinner;
            }
            set
            {
                m_CurrentWinner = value;
            }
        }

        public void Start(uint i_Size)
        {
            m_BoardSize = i_Size;
            m_GameMatrix = new MatrixGameCell[i_Size, i_Size];
            SequenceChecker.Set(i_Size);
        }

        public void PlayersSet(bool i_IsAgainstComputer, string i_Player1Name, string i_Player2Name)
        {
            bool v_True = true;

            if (i_IsAgainstComputer == v_True)
            {
                m_Player2.Type = Player.k_Computer;
            }
            else
            {
                m_Player2.Type = Player.k_Human;
            }

            m_Player1.Type = Player.k_Human;
            m_Player1.Name = i_Player1Name;
            m_Player2.Name = i_Player2Name;
            m_Player1.Symbol = MatrixGameCell.eValue.Player1;
            m_Player2.Symbol = MatrixGameCell.eValue.Player2;
            m_Player1.ID = 0;
            m_Player2.ID = 1;
        }

        public void EndRound()
        {
            SequenceChecker.Reset();
            resetMatrix();
        }

        public Player WhoIsPlaying()
        {
            if (m_PlayerIndicator == 1)
            {
                return m_Player1;
            }
            else 
            {
                return m_Player2;
            }
        }

        public Player WhoIsWaiting()
        {
            if(WhoIsPlaying() == m_Player1)
            {
                return m_Player2;
            }
            else
            {
                return m_Player1;
            }
        }

        private void updatePlayerIndicator()
        {
            m_PlayerIndicator = (m_PlayerIndicator + 1) % 2;
        }

        private void resetMatrix()
        {
            for (int i = 0; i < m_GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_GameMatrix.GetLength(1); j++)
                {
                    m_GameMatrix[i, j].Value = MatrixGameCell.eValue.Empty;
                }
            }
        }
    }
}



