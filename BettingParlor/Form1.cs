using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BettingParlor
{
    public partial class Form1 : Form
    {

        public Greyhound[] greyhounds;
        public Guy[] guys;
        private const int RACETRACK_LENGTH = 525;

        private bool hasWinner = false;

        private Guy currentBettor;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();

            label1.Text = "Aposta mínima: " + numericUpDown1.Minimum + " reais";
        }

        private void CreateObjects()
        {
            guys = new Guy[] { 
                new Guy { Name = "Clailton", Cash = 50, MyLabel = labelBettor1, MyRadioButton = radioButton1 }, 
                new Guy { Name = "Matheus", Cash = 75, MyLabel = labelBettor2, MyRadioButton = radioButton2 },
                new Guy { Name = "Arnon", Cash = 45, MyLabel = labelBettor3, MyRadioButton = radioButton3 } 
            };

            for (int i = 0; i < guys.Length; i++)
            {
                guys[i].UpdateLabels();   
            }

            Random randomizer = new Random();
            greyhounds = new Greyhound[] { 
                new Greyhound { MyPictureBox = pictureDog1, Randomizer = randomizer, RacetrackLength = RACETRACK_LENGTH },
                new Greyhound { MyPictureBox = pictureDog2, Randomizer = randomizer, RacetrackLength = RACETRACK_LENGTH },
                new Greyhound { MyPictureBox = pictureDog3, Randomizer = randomizer, RacetrackLength = RACETRACK_LENGTH },
                new Greyhound { MyPictureBox = pictureDog4, Randomizer = randomizer, RacetrackLength = RACETRACK_LENGTH }
            };

            for (int i = 0; i < greyhounds.Length; i++)
            {
                greyhounds[i].StartingPosition = greyhounds[i].MyPictureBox.Location.X;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int winningDog = 0;
            button1.Enabled = false;

            while (!hasWinner)
            {
                for (int i = 0; i < greyhounds.Length && !hasWinner; i++)
                {
                    hasWinner = greyhounds[i].Run();

                    if (hasWinner)
                    {
                        winningDog = i;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(25);
                    }
                }
            }

            for (int i = 0; i < guys.Length; i++)
            {
                if(guys[i].MyBet != null)
                    guys[i].Collect(winningDog);
            }

            int winningNumber = winningDog + 1;
            MessageBox.Show("Nós temos um vencedor - Cão N° " + winningNumber);
            button1.Enabled = true;

            foreach (Greyhound greyhound in greyhounds)
            {
                greyhound.TakeStartingPosition();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentBettor == null)
            {
                MessageBox.Show("Escolha um apostador antes!");
                return;
            }

            currentBettor.PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            currentBettor = guys[0];
            UpdateLabels();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            currentBettor = guys[1];
            UpdateLabels();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            currentBettor = guys[2];
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            labelCurrentBettor.Text = currentBettor.Name;
        }
    }
}
