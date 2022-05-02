using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SquareChaser
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(20, 283, 20, 20);
        Rectangle player2 = new Rectangle(434, 283, 20, 20);
        Rectangle whiteSquare;
        Rectangle yellowCircle;
        Rectangle redCircle;

        //Sounds
        SoundPlayer speedBoost = new SoundPlayer(Properties.Resources.speedBoost);
        SoundPlayer ding = new SoundPlayer(Properties.Resources.ding);
        SoundPlayer wrong = new SoundPlayer(Properties.Resources.wrong); 
        SoundPlayer win = new SoundPlayer(Properties.Resources.win);

        //Colours
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        Pen whitePen = new Pen(Color.White, 10);

        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftDown = false;
        bool rightDown = false;

        //Player Scores
        int player1Score, player2Score;

        //Player speeds
        int player1Speed = 4;
        int player2Speed = 4;

        Random randGen = new Random();

        int whiteSquareX, whiteSquareY, yellowCircleX, yellowCircleY, redCircleX, redCircleY;

        public Form1()
        {
            InitializeComponent();
            
            whiteSquareX = randGen.Next(15, 440);
            whiteSquareY = randGen.Next(15, 553);
            yellowCircleX = randGen.Next(15, 440);
            yellowCircleY = randGen.Next(15, 553);
            redCircleX = randGen.Next(15, 440);
            redCircleY = randGen.Next(15, 553);

            yellowCircle = new Rectangle(yellowCircleX, yellowCircleY, 10, 10);
            whiteSquare = new Rectangle(whiteSquareX, whiteSquareY, 10, 10);
            redCircle = new Rectangle(redCircleX, redCircleY, 10, 10);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            //move player 1
            if (wDown == true && player1.Y > 15)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < 552)
            {
                player1.Y += player1Speed;
            }

            if (aDown == true && player1.X > 15)
            {
                player1.X -= player1Speed;
            }

            if (dDown == true && player1.X < 437)
            {
                player1.X += player1Speed;
            }
            //move player 2
            if (upArrowDown == true && player2.Y > 15)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < 552)
            {
                player2.Y += player2Speed;
            }

            if (leftDown == true && player2.X > 15)
            {
                player2.X -= player2Speed;
            }

            if (rightDown == true && player2.X < 437)
            {
                player2.X += player2Speed;
            }

            //Player Makes contact with white square
            if(player1.IntersectsWith(whiteSquare))
            {
                ding.Play();

                player1Score++;
                player1ScoreLabel.Text = $"{player1Score}";

                whiteSquareX = randGen.Next(15, 440);
                whiteSquareY = randGen.Next(15, 553);

                whiteSquare = new Rectangle(whiteSquareX, whiteSquareY, 10, 10);
            }
            else if(player2.IntersectsWith(whiteSquare))
            {
                ding.Play();

                player2Score++;
                player2ScoreLabel.Text = $"{player2Score}";

                whiteSquareX = randGen.Next(15, 440);
                whiteSquareY = randGen.Next(15, 553);

                whiteSquare = new Rectangle(whiteSquareX, whiteSquareY, 10, 10);
            }
           
            //Player Makes Contact With Yellow Circle
            if (player1.IntersectsWith(yellowCircle))
            {
                speedBoost.Play();

                player1Speed = player1Speed + 2;

                yellowCircleX = randGen.Next(15, 440);
                yellowCircleY = randGen.Next(15, 553);

                yellowCircle = new Rectangle(yellowCircleX, yellowCircleY, 10, 10);
            }
            else if (player2.IntersectsWith(yellowCircle))
            {
                speedBoost.Play();

                player2Speed = player2Speed + 2;

                yellowCircleX = randGen.Next(15, 440);
                yellowCircleY = randGen.Next(15, 553);

                yellowCircle = new Rectangle(yellowCircleX, yellowCircleY, 10, 10);
            }

            //Player Makes Contact with Red Circle
            if (player1.IntersectsWith(redCircle))
            {
                wrong.Play();

                player1Speed = player1Speed - 2;

                redCircleX = randGen.Next(15, 440);
                redCircleY = randGen.Next(15, 553);

                redCircle = new Rectangle(redCircleX, redCircleY, 10, 10);
            }
            else if (player2.IntersectsWith(redCircle))
            {
                wrong.Play();

                player2Speed = player2Speed - 2;

                redCircleX = randGen.Next(15, 440);
                redCircleY = randGen.Next(15, 553);

                redCircle = new Rectangle(redCircleX, redCircleY, 10, 10);
            }

            //Player gets score of 5 and wins.
            if(player1Score == 5)
            {
                win.Play();

                gameEngine.Enabled = false;
                winLabel.Visible = true;
                //resetButton.Visible = true;
                winLabel.Text = $"Player 1 Wins, {player1Score} - {player2Score}";
            }
            else if (player2Score == 5)
            {
                win.Play();

                gameEngine.Enabled = false;
                winLabel.Visible = true;
                //resetButton.Visible = true;
                winLabel.Text = $"Player 2 Wins, {player2Score} - {player1Score}";
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Draws the graphics on the screen
            e.Graphics.DrawRectangle(whitePen, 10, 10, 454, 567);
            e.Graphics.FillRectangle(redBrush, player1);
            e.Graphics.FillRectangle(blueBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, whiteSquare);
            e.Graphics.FillEllipse(yellowBrush, yellowCircle);
            e.Graphics.FillEllipse(redBrush, redCircle);
        }        
        
        private void button1_Click(object sender, EventArgs e)
        {
           //Reset Button
            //player1Score = 0;
            //player2Score = 0;
            //winLabel.Visible = false;
            //resetButton.Visible = false;
            //gameEngine.Enabled = true;
        }
    }
}
