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
using System.Threading;

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        public string playerChoice, cpuChoice;
        public int wins = 0;
        public int losses = 0;
        public int ties = 0;

        public Random randGen = new Random();

        public SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        public SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        public Image rockImage = Properties.Resources.rock168x280;
        public Image paperImage = Properties.Resources.paper168x280;
        public Image scissorImage = Properties.Resources.scissors168x280;
        public Image winImage = Properties.Resources.winTrans;
        public Image loseImage = Properties.Resources.loseTrans;
        public Image tieImage = Properties.Resources.tieTrans;

        public Graphics g;

        public Form1()
        {
            InitializeComponent();

            g = this.CreateGraphics();
        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            //set player choice
            playerChoice = "rock";
            //Run everything
            Match();
            Refresh();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            //set player choice
            playerChoice = "paper";
            //Run everything
            Match();
            Refresh();
        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            //set player choice
            playerChoice = "scissors";
            //Run everything
            Match();
            Refresh();
        }
        public void ComputerTurn()
        {
            //determine and set cpu choice. display cpu image
            int randValue = randGen.Next(1, 4);

            if (randValue == 1)
            {
                cpuChoice = "rock";
                g.DrawImage(rockImage, 360, 70, 168, 280);
            }
            else if (randValue == 2)
            {
                cpuChoice = "paper";
                g.DrawImage(paperImage, 360, 70, 168, 280);
            }
            else
            {
                cpuChoice = "scissors";
                g.DrawImage(scissorImage, 360, 70, 168, 280);
            }
        }
        public void DetermineWinner()
        {
            if (playerChoice == cpuChoice)
            {
                g.DrawImage(tieImage, 225, 5, 250, 150);
                ties++;
                tiesLabel.Text = "Ties: " + ties;
            }
            else if ((cpuChoice == "rock" && playerChoice == "scissors") || (cpuChoice == "paper" && playerChoice == "rock") || (cpuChoice == "scissors" && playerChoice == "paper"))
            {
                g.DrawImage(loseImage, 225, 5, 250, 150);
                losses++;
                lossesLabel.Text = "Losses: " + losses;
            }
            else
            {
                g.DrawImage(winImage, 225, 5, 250, 150);
                wins++;
                winsLabel.Text = "Wins: " + wins;
            }
        }
        public void Match()
        {

            //determine and set cpu choice. display cpu image
            ComputerTurn();

            //play sound and display player choice image
            jabPlayer.Play();
            if (playerChoice == "scissors")
            {
                g.DrawImage(scissorImage, 168, 70, 168, 280);
            }
            else if (playerChoice == "rock")
            {
                g.DrawImage(rockImage, 168, 70, 168, 280);
            }
            else
            {
                g.DrawImage(paperImage, 168, 70, 168, 280);
            }
            Thread.Sleep(1000);

            //determine who the winner is and display result
            DetermineWinner();

            gongPlayer.Play();
            Thread.Sleep(3000);
        }

    }
}
