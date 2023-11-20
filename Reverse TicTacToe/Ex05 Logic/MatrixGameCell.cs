
namespace TicTacToe
{
    internal struct MatrixGameCell
    {
        private eValue m_Value;
        internal enum eValue { Empty, Player1, Player2 }

        internal MatrixGameCell(eValue i_Value)
        {
            m_Value = i_Value;
        }

        internal eValue Value 
        { 
            get 
            {
                return m_Value;
            } 
            set 
            { 
                    m_Value = value;  
            }
        }

        internal bool IsEmpty()
        { 
            return m_Value == eValue.Empty;
        }
    }
}
