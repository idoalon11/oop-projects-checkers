using System.Collections.Generic;

namespace GameLogic
{
    public class Player
    {
        private readonly int r_DirectionMove;
        private readonly bool r_IsComputer = false;
        private readonly string r_Name;
        private int m_Score;
        private List<Coin> m_MyCoins;

        public Player(string i_PlayerName, int i_DirectionMove, bool i_isComputer)
        {
            r_Name = i_PlayerName;
            r_DirectionMove = i_DirectionMove;
            r_IsComputer = i_isComputer;
            m_MyCoins = new List<Coin>();
            m_Score = 0;
        }

        public string Name
        {
            get
            {
                return r_Name;
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

        public List<Coin> MyCoins
        {
            get
            {
                return m_MyCoins;
            }

            set
            {
                m_MyCoins = value;
            }
        }

        public int DirectionMove
        {
            get
            {
                return r_DirectionMove;
            }
        }

        public bool IsComputer
        {
            get
            {
                return r_IsComputer;
            }
        }

        internal void AddToCoinList(Coin i_CoinToAdd)
        {
            m_MyCoins.Add(i_CoinToAdd);
        }

        internal void RemoveCoinFromList(Coin i_CoinToRemove)
        {
            m_MyCoins.Remove(i_CoinToRemove);
        }

        internal void UpdateLists(List<Step> i_ListOfEatSteps, List<Step> i_ListOfRegularSteps, Board i_board)
        {
            foreach (Coin coin in m_MyCoins)
            {
                coin.AddToEatList(i_ListOfEatSteps, r_DirectionMove, i_board);
                coin.AddToRegularList(i_ListOfRegularSteps, r_DirectionMove, i_board);
            }
        }

        internal int CalculateScore()
        {
            int score = 0;

            foreach (Coin coin in m_MyCoins)
            {
                if (coin.IsKing())
                {
                    score += 4;
                }
                else
                {
                    score++;
                }
            }

            return score;
        }
    }
}
