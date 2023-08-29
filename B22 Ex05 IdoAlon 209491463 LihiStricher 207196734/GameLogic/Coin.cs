using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameLogic
{
    public class Coin
    {
        private const int k_ChangeDirection = -1;
        private static readonly int sr_CoinButtonSize = 70;
        private Point m_PlaceOnBoard;
        private char m_CharOfCoin;

        public static int CoinButtonSize
        {
            get
            {
                return sr_CoinButtonSize;
            }
        }

        public Button CoinButton { get; set; }

        internal enum eDirections
        {
            Right = 1,
            Left = -1,
            Down = 1,
            Up = -1,
        }

        internal enum eCharOfCoins
        {
            FirstPlayer = 'X',
            SecondPlayer = 'O',
            FirstPlayerKing = 'Z',
            SecondPlayerKing = 'Q',
        }

        public Coin(char i_CharOfCoin, Point i_PlaceOnBoard, Color i_BackgroundColor)
        {
            CoinButton = new Button();
            if(i_CharOfCoin == ' ')
            {
                CoinButton.Text = i_CharOfCoin.ToString();
            }
            else if(i_CharOfCoin == 'X')
            {
                CoinButton.Image = Properties.Resources.X;
            }
            else if (i_CharOfCoin == 'O')
            {
                CoinButton.Image = Properties.Resources.O;
            }

            CoinButton.ImageAlign = ContentAlignment.MiddleCenter;
            CoinButton.BackColor = i_BackgroundColor;
            CoinButton.Height = sr_CoinButtonSize;
            CoinButton.Width = sr_CoinButtonSize;
            CoinButton.Location = new Point(i_PlaceOnBoard.Y * CoinButton.Height, (i_PlaceOnBoard.X * CoinButton.Width) + GameForm.GapFromTop);
            m_CharOfCoin = i_CharOfCoin;
            m_PlaceOnBoard = i_PlaceOnBoard;
        }

        public char CharOfCoin
        {
            get
            {
                return m_CharOfCoin;
            }

            set
            {
                m_CharOfCoin = value;
            }
        }

        public Point PlaceOnBoard
        {
            get
            {
                return m_PlaceOnBoard;
            }

            set
            {
                m_PlaceOnBoard.X = value.X;
                m_PlaceOnBoard.Y = value.Y;
            }
        }

        private bool checkOutOfBounesForEatRight(int i_UpDownDirection, Board i_Board)
        {
            bool checkOutOfBounesForEatRight = true;

            if (m_PlaceOnBoard.X + (2 * i_UpDownDirection) > i_Board.Size - 1 || m_PlaceOnBoard.X + (2 * i_UpDownDirection) < 0)
            {
                checkOutOfBounesForEatRight = false;
            }
            else if (m_PlaceOnBoard.Y + 2 > i_Board.Size - 1)
            {
                checkOutOfBounesForEatRight = false;
            }

            return checkOutOfBounesForEatRight;
        }

        private bool checkOutOfBounesForEatLeft(int i_UpDownDirection, Board i_Board)
        {
            bool checkOutOfBounesForEatLeft = true;

            if (m_PlaceOnBoard.X + (2 * i_UpDownDirection) > i_Board.Size - 1 || m_PlaceOnBoard.X + (2 * i_UpDownDirection) < 0)
            {
                checkOutOfBounesForEatLeft = false;
            }
            else if (m_PlaceOnBoard.Y - 2 < 0)
            {
                checkOutOfBounesForEatLeft = false;
            }

            return checkOutOfBounesForEatLeft;
        }

        private bool isUnoccupiedSquaorRightEat(Board i_Board, int i_UpDownDirection)
        {
            bool isUnoccupiedSquaorRightEat = false;

            if (checkOutOfBounesForEatRight(i_UpDownDirection, i_Board))
            {
                if (i_Board.GameBoard[m_PlaceOnBoard.X + (i_UpDownDirection * 2), m_PlaceOnBoard.Y + 2].m_CharOfCoin == ' ')
                {
                    isUnoccupiedSquaorRightEat = true;
                }
            }

            return isUnoccupiedSquaorRightEat;
        }

        private bool isUnoccupiedSquaorLeftEat(Board i_Board, int i_UpDownDirection)
        {
            bool isUnoccupiedSquaorLeftEat = false;

            if (i_Board.GameBoard[m_PlaceOnBoard.X + (i_UpDownDirection * 2), m_PlaceOnBoard.Y - 2].m_CharOfCoin == ' ')
            {
                isUnoccupiedSquaorLeftEat = true;
            }

            return isUnoccupiedSquaorLeftEat;
        }

        private bool checkOutOfBounesForRegularRightStep(int i_UpDownDirection, Board i_Board)
        {
            bool checkOutOfBounesForRegularRightStep = true;

            if (m_PlaceOnBoard.X + i_UpDownDirection > i_Board.Size - 1 || m_PlaceOnBoard.X + i_UpDownDirection < 0)
            {
                checkOutOfBounesForRegularRightStep = false;
            }
            else if (m_PlaceOnBoard.Y + 1 > i_Board.Size - 1)
            {
                checkOutOfBounesForRegularRightStep = false;
            }

            return checkOutOfBounesForRegularRightStep;
        }

        private bool checkOutOfBounesForRegularLeftStep(int i_UpDownDirection, Board i_Board)
        {
            bool checkOutOfBounesForRegularLeftStep = true;

            if (m_PlaceOnBoard.X + i_UpDownDirection > i_Board.Size - 1 || m_PlaceOnBoard.X + i_UpDownDirection < 0)
            {
                checkOutOfBounesForRegularLeftStep = false;
            }
            else if (m_PlaceOnBoard.Y - 1 < 0)
            {
                checkOutOfBounesForRegularLeftStep = false;
            }

            return checkOutOfBounesForRegularLeftStep;
        }

        private void addNewEatStepToList(List<Step> i_ListOfStep, int i_PointX, int i_PointY, int i_UpDownDirection, int i_RightLeftDirection, Board i_Board)
        {
            Point startValidPoint = new Point(i_PointX, i_PointY);
            Point endValidPoint = new Point(i_PointX + (i_UpDownDirection * 2), i_PointY + (2 * i_RightLeftDirection));
            Step stepToAddToList = new Step();

            stepToAddToList.SetStep(startValidPoint, endValidPoint);
            i_ListOfStep.Add(stepToAddToList);
        }

        private void addNewRegularStepToList(List<Step> i_ListOfStep, int i_PointX, int i_PointY, int i_UpDownDirection, int i_RightLeftDirection, Board i_Board)
        {
            Point startValidPoint = new Point(i_PointX, i_PointY);
            Point endValidPoint = new Point(i_PointX + i_UpDownDirection, i_PointY + i_RightLeftDirection);
            Step stepToAddToList = new Step();

            stepToAddToList.SetStep(startValidPoint, endValidPoint);
            i_ListOfStep.Add(stepToAddToList);
        }

        internal void AddToEatList(List<Step> i_ListOfStep, int i_UpDownDirection, Board i_Board)
        {
            if (checkOutOfBounesForEatRight(i_UpDownDirection, i_Board))
            {
                if (i_Board.GameBoard[m_PlaceOnBoard.X + i_UpDownDirection, m_PlaceOnBoard.Y + 1].isOpponentCoin(i_UpDownDirection))
                {
                    if (isUnoccupiedSquaorRightEat(i_Board, i_UpDownDirection))
                    {
                        addNewEatStepToList(i_ListOfStep, m_PlaceOnBoard.X, m_PlaceOnBoard.Y, i_UpDownDirection, (int)eDirections.Right, i_Board);
                    }
                }
            }

            if (checkOutOfBounesForEatLeft(i_UpDownDirection, i_Board))
            {
                if (i_Board.GameBoard[m_PlaceOnBoard.X + i_UpDownDirection, m_PlaceOnBoard.Y - 1].isOpponentCoin(i_UpDownDirection))
                {
                    if (isUnoccupiedSquaorLeftEat(i_Board, i_UpDownDirection))
                    {
                        addNewEatStepToList(i_ListOfStep, m_PlaceOnBoard.X, m_PlaceOnBoard.Y, i_UpDownDirection, (int)eDirections.Left, i_Board);
                    }
                }
            }

            if (IsKing())
            {
                if (checkOutOfBounesForEatRight(i_UpDownDirection * k_ChangeDirection, i_Board))
                {
                    if (i_Board.GameBoard[m_PlaceOnBoard.X - i_UpDownDirection, m_PlaceOnBoard.Y + 1].isOpponentCoin(i_UpDownDirection))
                    {
                        if (isUnoccupiedSquaorRightEat(i_Board, i_UpDownDirection * k_ChangeDirection))
                        {
                            addNewEatStepToList(i_ListOfStep, m_PlaceOnBoard.X, m_PlaceOnBoard.Y, i_UpDownDirection * k_ChangeDirection, (int)eDirections.Right, i_Board);
                        }
                    }
                }

                if (checkOutOfBounesForEatLeft(i_UpDownDirection * k_ChangeDirection, i_Board))
                {
                    if (i_Board.GameBoard[m_PlaceOnBoard.X - i_UpDownDirection, m_PlaceOnBoard.Y - 1].isOpponentCoin(i_UpDownDirection))
                    {
                        if (isUnoccupiedSquaorLeftEat(i_Board, i_UpDownDirection * k_ChangeDirection))
                        {
                            addNewEatStepToList(i_ListOfStep, m_PlaceOnBoard.X, m_PlaceOnBoard.Y, i_UpDownDirection * k_ChangeDirection, (int)eDirections.Left, i_Board);
                        }
                    }
                }
            }
        }

        internal void AddToRegularList(List<Step> i_ListOfStep, int i_UpDownDirection, Board i_Board)
        {
            if (isUnoccupiedSquaorRightRegularStep(i_Board, i_UpDownDirection))
            {
                addNewRegularStepToList(i_ListOfStep, m_PlaceOnBoard.X, m_PlaceOnBoard.Y, i_UpDownDirection, (int)eDirections.Right, i_Board);
            }

            if (isUnoccupiedSquaorLeftRegularStep(i_Board, i_UpDownDirection))
            {
                addNewRegularStepToList(i_ListOfStep, m_PlaceOnBoard.X, m_PlaceOnBoard.Y, i_UpDownDirection, (int)eDirections.Left, i_Board);
            }

            if (IsKing())
            {
                if (isUnoccupiedSquaorRightRegularStep(i_Board, i_UpDownDirection * k_ChangeDirection))
                {
                    addNewRegularStepToList(i_ListOfStep, m_PlaceOnBoard.X, m_PlaceOnBoard.Y, i_UpDownDirection * k_ChangeDirection, (int)eDirections.Right, i_Board);
                }

                if (isUnoccupiedSquaorLeftRegularStep(i_Board, i_UpDownDirection * k_ChangeDirection))
                {
                    addNewRegularStepToList(i_ListOfStep, m_PlaceOnBoard.X, m_PlaceOnBoard.Y, i_UpDownDirection * k_ChangeDirection, (int)eDirections.Left, i_Board);
                }
            }
        }

        private bool isUnoccupiedSquaorRightRegularStep(Board i_Board, int i_UpDownDirection)
        {
            bool isUnoccupiedSquaorRightRegularStep = false;

            if (checkOutOfBounesForRegularRightStep(i_UpDownDirection, i_Board))
            {
                if (i_Board.GameBoard[m_PlaceOnBoard.X + i_UpDownDirection, m_PlaceOnBoard.Y + 1].m_CharOfCoin == ' ')
                {
                    isUnoccupiedSquaorRightRegularStep = true;
                }
            }

            return isUnoccupiedSquaorRightRegularStep;
        }

        private bool isUnoccupiedSquaorLeftRegularStep(Board i_Board, int i_UpDownDirection)
        {
            bool isUnoccupiedSquaorLeftRegularStep = false;

            if (checkOutOfBounesForRegularLeftStep(i_UpDownDirection, i_Board))
            {
                if (i_Board.GameBoard[m_PlaceOnBoard.X + i_UpDownDirection, m_PlaceOnBoard.Y - 1].m_CharOfCoin == ' ')
                {
                    isUnoccupiedSquaorLeftRegularStep = true;
                }
            }

            return isUnoccupiedSquaorLeftRegularStep;
        }

        private bool isOpponentCoin(int i_Direction)
        {
            bool isOpponentCoin = false;

            if (i_Direction == (int)Coin.eDirections.Down)
            {
                if (CharOfCoin == (char)Coin.eCharOfCoins.FirstPlayer || CharOfCoin == (char)Coin.eCharOfCoins.FirstPlayerKing)
                {
                    isOpponentCoin = true;
                }
            }
            else if (i_Direction == (int)Coin.eDirections.Up)
            {
                if (CharOfCoin == (char)Coin.eCharOfCoins.SecondPlayer || CharOfCoin == (char)Coin.eCharOfCoins.SecondPlayerKing)
                {
                    isOpponentCoin = true;
                }
            }

            return isOpponentCoin;
        }

        internal bool IsKing()
        {
            bool isKing = false;

            if (CharOfCoin.Equals((char)Coin.eCharOfCoins.SecondPlayerKing) || CharOfCoin.Equals((char)Coin.eCharOfCoins.FirstPlayerKing))
            {
                isKing = true;
            }

            return isKing;
        }
    }
}
