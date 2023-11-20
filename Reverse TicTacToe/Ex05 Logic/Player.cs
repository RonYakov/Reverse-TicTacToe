
namespace TicTacToe
{
    public class Player
    {
        public const char k_Computer = 'C';
        public const char k_Human = 'H';
        private char? m_Type = null;
        private MatrixGameCell.eValue m_MySymbol;
        private int? m_ID = null;
        private string m_Name = null;
        private int m_Score = 0;

        public char? Type
        {
            get
            {
                return m_Type;
            }
            set
            {
                m_Type = value;
            }
        }
        internal MatrixGameCell.eValue Symbol
        {
            get
            {
                return m_MySymbol;
            }
            set
            {
                m_MySymbol = value;
            }
        }
        internal int? ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        public int Score 
        { 
            get 
            { 
                return m_Score; 
            }
            set
            {
                m_Score = value; 
            }
        }

        public void UpdateWin()
        {
            m_Score++;
        }

    }
}
