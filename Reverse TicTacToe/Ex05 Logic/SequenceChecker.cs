
namespace TicTacToe
{
    internal class SequenceChecker
    {
        private const int k_NumOfPlayers = 2;
        private static uint[,] s_Rows = null;
        private static uint[,] s_Columns = null;
        private static uint[,] s_Diagonal = null;
        private static uint s_Size = 0;
        private static uint s_NumOfTurnsInSingleGame = 0;

        internal static void Set(uint i_Size)
        {
            s_Rows = new uint[k_NumOfPlayers, i_Size];
            s_Columns = new uint[k_NumOfPlayers, i_Size]; 
            s_Diagonal = new uint[k_NumOfPlayers, k_NumOfPlayers];
            s_Size = i_Size;
            s_NumOfTurnsInSingleGame = 0;
        }

        internal static void Reset()
        {
            for (uint i = 0; i < s_Size; i++)
            {
                s_Rows[0, i] = 0;
                s_Rows[1, i] = 0;
                s_Columns[0, i] = 0;
                s_Columns[1, i] = 0;
            }

            for (uint i = 0; i < k_NumOfPlayers; i++)
            {
                s_Diagonal[0, i] = 0;
                s_Diagonal[1, i] = 0;
            }

            s_NumOfTurnsInSingleGame = 0;
        }

        internal static eTurnStatus UpdateBoardAndLooserChecker(uint i_Row, uint i_Coloumn, int i_PlayerNum)
        {
            s_NumOfTurnsInSingleGame++;
            s_Rows[i_PlayerNum, i_Row]++;
            s_Columns[i_PlayerNum, i_Coloumn]++;
            if(i_Row == i_Coloumn)
            {
                s_Diagonal[i_PlayerNum, 0]++;
            }

            if(i_Row + i_Coloumn == s_Size - 1)
            {
                s_Diagonal[i_PlayerNum, 1]++;
            }

            return looserChecker(i_Row, i_Coloumn, i_PlayerNum);
        }

        private static eTurnStatus looserChecker(uint i_Row, uint i_Coloumn, int i_PlayerNum)
        {
            if(s_Rows[i_PlayerNum, i_Row] == s_Size || s_Columns[i_PlayerNum,i_Coloumn] == s_Size)
            {
                return eTurnStatus.Loser;
            }
            else if(s_Diagonal[i_PlayerNum, 0] == s_Size || s_Diagonal[i_PlayerNum, 1] == s_Size)
            {
                return eTurnStatus.Loser;
            }
            
            if(s_NumOfTurnsInSingleGame == s_Size*s_Size)
            {
                return eTurnStatus.Tie;
            }
            else
            {
                return eTurnStatus.MidGame;
            }
        }
    }
}
