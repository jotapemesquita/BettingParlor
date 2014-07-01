using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BettingParlor
{
    public class Guy
    {
        /// <summary>
        /// O nome do cara.
        /// </summary>
        public string Name;
        /// <summary>
        /// Uma instância de Bet que tem sua aposta.
        /// </summary>
        public Bet MyBet;
        /// <summary>
        /// Quanto dinheiro ele tem.
        /// </summary>
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            if (MyBet == null)
            {
                MyLabel.Text = "Aposta de " + Name;
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription();
            }
            
            MyRadioButton.Text = Name + " tem R$ " + Cash;
        }

        public void ClearBet()
        {
            MyBet = null;
            UpdateLabels();
        }

        public bool PlaceBet(int amount, int dog)
        {
            if (Cash > amount && amount != 0)
            {
                MyBet = new Bet { Bettor = this };
                MyBet.Amount = amount;
                MyBet.Dog = dog;

                Cash -= amount;

                UpdateLabels();

                return true;
            }

            return false;
        }

        public void Collect(int winner)
        {
            Cash += MyBet.PayOut(winner);
            UpdateLabels();
        }

    }
}
