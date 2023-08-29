using System.Drawing;

namespace GameLogic
{
    public class Board
    {
        private readonly int r_Size;
        private readonly Coin[,] r_GameBoard;

        public Board(int i_Size)
        {
            r_Size = i_Size;
            r_GameBoard = new Coin[r_Size, r_Size];
        }

        public int Size
        {
            get
            {
                return r_Size;
            }
        }

        public Coin[,] GameBoard
        {
            get
            {
                return r_GameBoard;
            }
        }

        internal void Init(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            i_FirstPlayer.MyCoins.Clear();
            i_SecondPlayer.MyCoins.Clear();
            for (int i = 0; i < r_Size; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        r_GameBoard[i, j] = new Coin(' ', new Point(i, j), Color.Gray);
                        r_GameBoard[i, j].CoinButton.Enabled = false;
                    }
                    else
                    {
                        r_GameBoard[i, j] = new Coin(' ', new Point(i, j), Color.White);
                    }
                }
            }

            for (int i = 0; i < (r_Size / 2) - 1; i++)
            {
                rowInit(i, (i + 1) % 2, (char)Coin.eCharOfCoins.SecondPlayer, i_SecondPlayer);
            }

            for (int i = (r_Size / 2) + 1; i < r_Size; i++)
            {
                rowInit(i, (i + 1) % 2, (char)Coin.eCharOfCoins.FirstPlayer, i_FirstPlayer);
            }
        }

        private void rowInit(int i_NumberOfRow, int i_NumberOFStartCol, char i_PlayerCoin, Player i_Player)
        {
            Point currentPoint;
            Coin currentCoin;

            for (int j = i_NumberOFStartCol; j < r_Size; j = j + 2)
            {
                currentPoint = new Point(i_NumberOfRow, j);
                currentCoin = new Coin(i_PlayerCoin, currentPoint, Color.White);
                r_GameBoard[i_NumberOfRow, j] = currentCoin;
                i_Player.AddToCoinList(currentCoin);
            }
        }

        internal void SetBoard(Step i_CurrentStep)
        {
            int startX = i_CurrentStep.Start.X;
            int startY = i_CurrentStep.Start.Y;
            int endX = i_CurrentStep.End.X;
            int endY = i_CurrentStep.End.Y;

            r_GameBoard[endX, endY] = r_GameBoard[startX, startY];
            r_GameBoard[endX, endY].PlaceOnBoard = i_CurrentStep.End;
            r_GameBoard[endX, endY].CoinButton.Location = new Point(i_CurrentStep.End.Y * Coin.CoinButtonSize, (i_CurrentStep.End.X * Coin.CoinButtonSize) + GameForm.GapFromTop);
            r_GameBoard[endX, endY].CoinButton.BringToFront();
            r_GameBoard[endX, endY].CoinButton.BackColor = Color.White;
            r_GameBoard[startX, startY] = new Coin(' ', new Point(startX, startY), Color.White);
            if (i_CurrentStep.IsEatStep)
            {
                r_GameBoard[(startX + endX) / 2, (startY + endY) / 2] = new Coin(' ', new Point((startX + endX) / 2, (startY + endY) / 2), Color.White);
            }

            NeedToMakeKing(i_CurrentStep.End);
        }

        internal void NeedToMakeKing(Point i_PlaceOnBoard)
        {
            if (i_PlaceOnBoard.X == 0 && !r_GameBoard[i_PlaceOnBoard.X, i_PlaceOnBoard.Y].IsKing())
            {
                r_GameBoard[i_PlaceOnBoard.X, i_PlaceOnBoard.Y].CharOfCoin = (char)Coin.eCharOfCoins.FirstPlayerKing;
                r_GameBoard[i_PlaceOnBoard.X, i_PlaceOnBoard.Y].CoinButton.Image = Properties.Resources.Z;
            }
            else if (i_PlaceOnBoard.X == r_Size - 1 && !r_GameBoard[i_PlaceOnBoard.X, i_PlaceOnBoard.Y].IsKing())
            {
                r_GameBoard[i_PlaceOnBoard.X, i_PlaceOnBoard.Y].CharOfCoin = (char)Coin.eCharOfCoins.SecondPlayerKing;
                r_GameBoard[i_PlaceOnBoard.X, i_PlaceOnBoard.Y].CoinButton.Image = Properties.Resources.Q;
            }

            r_GameBoard[i_PlaceOnBoard.X, i_PlaceOnBoard.Y].CoinButton.ImageAlign = ContentAlignment.MiddleCenter;
        }
    }
}
