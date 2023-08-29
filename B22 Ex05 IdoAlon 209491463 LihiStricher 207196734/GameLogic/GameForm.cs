using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLogic
{
    public partial class GameForm : Form
    {
        private static readonly int sr_GapFromTop = 100;
        private readonly Game r_CurrentGame;
        private Label m_LableFirstPlayerName = new Label();
        private Label m_LableSecondPlayerName = new Label();
        private Point m_StartPoint;

        public static int GapFromTop
        {
            get
            {
                return sr_GapFromTop;
            }
        }

        public bool IsFirstClick { get; set; }

        public Game CurrentGame
        {
            get
            {
                return r_CurrentGame;
            }
        }

        public Label LableFirstPlayerName
        {
            get
            {
                return m_LableFirstPlayerName;
            }

            set
            {
                m_LableFirstPlayerName = value;
            }
        }

        public Label LableSecondPlayerName
        {
            get
            {
                return m_LableSecondPlayerName;
            }

            set
            {
                m_LableSecondPlayerName = value;
            }
        }

        public Point StartPoint
        {
            get
            {
                return m_StartPoint;
            }

            set
            {
                m_StartPoint = value;
            }
        }

        public GameForm(Game i_game)
        {
            r_CurrentGame = i_game;
            initComponnent();
        }

        private void initComponnent()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Damka";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ClientSize = new Size(CurrentGame.Board.Size * Coin.CoinButtonSize, (CurrentGame.Board.Size * Coin.CoinButtonSize) + GameForm.GapFromTop);
            m_LableFirstPlayerName.Text = CurrentGame.FirstPlayer.Name + ": " + CurrentGame.FirstPlayer.Score;
            m_LableSecondPlayerName.Text = CurrentGame.SecondPlayer.Name + ": " + CurrentGame.SecondPlayer.Score;
            m_LableFirstPlayerName.Top = 40;
            m_LableFirstPlayerName.Width = 150;
            m_LableFirstPlayerName.TextAlign = ContentAlignment.MiddleCenter;
            m_LableSecondPlayerName.Top = 40;
            m_LableSecondPlayerName.Width = 150;
            m_LableSecondPlayerName.Left = this.ClientSize.Width - m_LableSecondPlayerName.Width;
            m_LableSecondPlayerName.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(m_LableFirstPlayerName);
            this.Controls.Add(m_LableSecondPlayerName);
            IsFirstClick = true;
            CurrentGame.Init();
            InitButtons();
        }

        internal void InitButtons()
        {
            foreach (Coin coin in CurrentGame.Board.GameBoard)
            {
                this.Controls.Add(coin.CoinButton);
                coin.CoinButton.Click += new System.EventHandler(CoinButton_Click);
            }
        }

        public void CoinButton_Click(object sender, EventArgs e)
        {
            if (IsFirstClick)
            {
                if ((sender as Button).Text != " ")
                {
                    (sender as Button).BackColor = Color.LightBlue;
                    m_StartPoint = (sender as Button).Location;
                    IsFirstClick = false;
                }
            }
            else if (!IsFirstClick)
            {
                IsFirstClick = true;
                if (m_StartPoint == (sender as Button).Location)
                {
                    (sender as Button).BackColor = Color.White;
                }
                else
                {
                    CurrentGame.PlayerStep(setUserStep(StartPoint), setUserStep((sender as Button).Location));
                    if (CurrentGame.CurrentPlayer.IsComputer)
                    {
                        CurrentGame.ComputerStep();
                    }
                }
            }
        }

        private Point setUserStep(Point i_PointToSet)
        {
            Point pointToReturn = new Point((i_PointToSet.Y - GameForm.GapFromTop) / Coin.CoinButtonSize, i_PointToSet.X / Coin.CoinButtonSize);

            return pointToReturn;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameForm
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
        }
    }
}
