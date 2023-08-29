using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameLogic
{
    public class Game
    {
        private readonly Board r_Board;
        private readonly Player r_FirstPlayer;
        private readonly Player r_SecondPlayer;
        private readonly GameForm r_Form;
        private bool m_UserWantToContinue;
        private Player m_CurrentPlayer;
        private Player m_NextPlayer;
        private List<Step> m_ListOfRegularStep;
        private List<Step> m_ListOfEatStep;
        private Step m_CurrentStep;

        public Game(string i_FirstPlayerName, string i_SecondPlayerName, int i_SizeOfBoard, bool i_IsComputer)
        {
            r_FirstPlayer = new Player(i_FirstPlayerName, (int)Coin.eDirections.Up, false);
            r_SecondPlayer = new Player(i_SecondPlayerName, (int)Coin.eDirections.Down, i_IsComputer);
            r_Board = new Board(i_SizeOfBoard);
            m_ListOfRegularStep = new List<Step>();
            m_ListOfEatStep = new List<Step>();
            m_CurrentStep = new Step();
            r_Form = new GameForm(this);
            r_Form.ShowDialog();
        }

        public Player FirstPlayer
        {
            get
            {
                return r_FirstPlayer;
            }
        }

        public Player SecondPlayer
        {
            get
            {
                return r_SecondPlayer;
            }
        }

        public Board Board
        {
            get { return r_Board; }
        }

        public bool UserWantToContinue
        {
            get
            {
                return m_UserWantToContinue;
            }

            set
            {
                m_UserWantToContinue = value;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
        }

        internal void Init()
        {
            r_Board.Init(r_FirstPlayer, r_SecondPlayer);
            m_CurrentPlayer = r_FirstPlayer;
            m_NextPlayer = r_SecondPlayer;
        }

        private void resetBoard()
        {
            r_Form.Controls.Clear();
            r_Form.Controls.Add(r_Form.LableFirstPlayerName);
            r_Form.Controls.Add(r_Form.LableSecondPlayerName);
        }

        internal void PlayerStep(Point i_StartPoint, Point i_EndPoint)
        {
            Button currentButton;
            Coin coinToRemove;

            m_CurrentStep.IsEatStep = false;
            m_CurrentStep.Start = i_StartPoint;
            m_CurrentStep.End = i_EndPoint;
            m_CurrentPlayer.UpdateLists(m_ListOfEatStep, m_ListOfRegularStep, r_Board);
            if (m_ListOfEatStep.Count != 0)
            {
                m_CurrentStep.IsEatStep = true;
                if (!Step.IsValid(m_CurrentStep, m_ListOfEatStep))
                {
                    r_Form.IsFirstClick = true;
                    currentButton = r_Board.GameBoard[m_CurrentStep.Start.X, m_CurrentStep.Start.Y].CoinButton;
                    currentButton.BackColor = Color.White;
                    MessageBox.Show("The stpe is invalid, note that if you cant eat, you must eat!", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    coinToRemove = r_Board.GameBoard[(m_CurrentStep.Start.X + m_CurrentStep.End.X) / 2, (m_CurrentStep.Start.Y + m_CurrentStep.End.Y) / 2];
                    r_Form.Controls.Remove(coinToRemove.CoinButton);
                    m_NextPlayer.RemoveCoinFromList(coinToRemove);
                    r_Board.SetBoard(m_CurrentStep);
                    currentButton = r_Board.GameBoard[m_CurrentStep.Start.X, m_CurrentStep.Start.Y].CoinButton;
                    r_Form.Controls.Add(currentButton);
                    currentButton.Click += new System.EventHandler(r_Form.CoinButton_Click);
                    clearLists();
                    r_Board.GameBoard[m_CurrentStep.End.X, m_CurrentStep.End.Y].AddToEatList(m_ListOfEatStep, m_CurrentPlayer.DirectionMove, r_Board);
                }

                if (m_ListOfEatStep.Count == 0)
                {
                    switchPlayers();
                    clearLists();
                    m_CurrentPlayer.UpdateLists(m_ListOfEatStep, m_ListOfRegularStep, r_Board);
                }
            }
            else
            {
                if (!Step.IsValid(m_CurrentStep, m_ListOfRegularStep))
                {
                    r_Form.IsFirstClick = true;
                    currentButton = r_Board.GameBoard[m_CurrentStep.Start.X, m_CurrentStep.Start.Y].CoinButton;
                    currentButton.BackColor = Color.White;
                    MessageBox.Show("The step is invalid!", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    r_Board.SetBoard(m_CurrentStep);
                    currentButton = r_Board.GameBoard[m_CurrentStep.Start.X, m_CurrentStep.Start.Y].CoinButton;
                    r_Form.Controls.Add(currentButton);
                    currentButton.Click += new System.EventHandler(r_Form.CoinButton_Click);
                    switchPlayers();
                    clearLists();
                    m_CurrentPlayer.UpdateLists(m_ListOfEatStep, m_ListOfRegularStep, r_Board);
                }
            }

            checkIfTheGameIsOver();
        }

        internal void ComputerStep()
        {
            int randomNumberToChooseStep;
            Button currentButton;
            Coin coinToRemove;

            m_CurrentStep.IsEatStep = false;
            m_CurrentPlayer.UpdateLists(m_ListOfEatStep, m_ListOfRegularStep, r_Board);
            while (m_ListOfEatStep.Count != 0)
            {
                randomNumberToChooseStep = new Random().Next(0, m_ListOfEatStep.Count);
                m_CurrentStep = m_ListOfEatStep[randomNumberToChooseStep];
                m_CurrentStep.IsEatStep = true;
                coinToRemove = r_Board.GameBoard[(m_CurrentStep.Start.X + m_CurrentStep.End.X) / 2, (m_CurrentStep.Start.Y + m_CurrentStep.End.Y) / 2];
                r_Form.Controls.Remove(coinToRemove.CoinButton);
                m_NextPlayer.RemoveCoinFromList(coinToRemove);
                r_Board.SetBoard(m_CurrentStep);
                currentButton = r_Board.GameBoard[m_CurrentStep.Start.X, m_CurrentStep.Start.Y].CoinButton;
                r_Form.Controls.Add(currentButton);
                currentButton.Click += new System.EventHandler(r_Form.CoinButton_Click);
                clearLists();
                r_Board.GameBoard[m_CurrentStep.End.X, m_CurrentStep.End.Y].AddToEatList(m_ListOfEatStep, m_CurrentPlayer.DirectionMove, r_Board);
            }

            if(!m_CurrentStep.IsEatStep)
            {
                randomNumberToChooseStep = new Random().Next(0, m_ListOfRegularStep.Count);
                m_CurrentStep = m_ListOfRegularStep[randomNumberToChooseStep];
                r_Board.SetBoard(m_CurrentStep);
                currentButton = r_Board.GameBoard[m_CurrentStep.Start.X, m_CurrentStep.Start.Y].CoinButton;
                r_Form.Controls.Add(currentButton);
                currentButton.Click += new System.EventHandler(r_Form.CoinButton_Click);
            }

            switchPlayers();
            clearLists();
            m_CurrentPlayer.UpdateLists(m_ListOfEatStep, m_ListOfRegularStep, r_Board);
            checkIfTheGameIsOver();
        }

        private void clearLists()
        {
            m_ListOfEatStep.Clear();
            m_ListOfRegularStep.Clear();
        }

        private void checkIfTheGameIsOver()
        {
            bool gameOver = false;
            DialogResult result = DialogResult.None;

            if (playerCantMove(r_FirstPlayer) && playerCantMove(r_SecondPlayer))
            {
                gameOver = true;
                result = MessageBox.Show("Tie!\nAnother Round?", "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else if (checkWin())
            {
                gameOver = true;
                result = MessageBox.Show(m_NextPlayer.Name.ToString() + " won!\nAnother Round?", "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            UserWantToContinue = result == DialogResult.Yes;
            if(gameOver)
            {
                updateScore();
                if (UserWantToContinue)
                {
                    resetBoard();
                    Init();
                    r_Form.InitButtons();
                }
                else
                {
                    r_Form.Close();
                }
            }
        }

        private bool playerCantMove(Player i_PlayerToCheck)
        {
            bool cantMove = false;

            clearLists();
            i_PlayerToCheck.UpdateLists(m_ListOfEatStep, m_ListOfRegularStep, r_Board);
            if (m_ListOfRegularStep.Count == 0 && m_ListOfEatStep.Count == 0)
            {
                cantMove = true;
            }

            clearLists();

            return cantMove;
        }

        private bool checkWin()
        {
            bool thereIsWin = false;

            if (playerCantMove(m_CurrentPlayer) || runOutOfCoins(m_CurrentPlayer))
            {
                thereIsWin = true;
            }

            return thereIsWin;
        }

        private bool runOutOfCoins(Player i_CurretPlayer)
        {
            bool noMoreCoins = false;

            if (i_CurretPlayer.MyCoins.Count == 0)
            {
                noMoreCoins = true;
            }

            return noMoreCoins;
        }

        private void switchPlayers()
        {
            Player tempPlayer = null;
            tempPlayer = m_CurrentPlayer;
            m_CurrentPlayer = m_NextPlayer;
            m_NextPlayer = tempPlayer;
        }

        private void updateScore()
        {
            int loserScore = m_CurrentPlayer.CalculateScore();
            int winnerScore = m_NextPlayer.CalculateScore();

            m_NextPlayer.Score += Math.Abs(winnerScore - loserScore);
            r_Form.LableFirstPlayerName.Text = r_FirstPlayer.Name + ": " + r_FirstPlayer.Score;
            r_Form.LableSecondPlayerName.Text = r_SecondPlayer.Name + ": " + r_SecondPlayer.Score;
        }
    }
}
