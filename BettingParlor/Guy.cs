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
            MyLabel.Text = "Aposta de " + Name;
            MyRadioButton.Text = Name + " tem R$" + Cash;
        }

        public void ClearBet()
        {

        }

        public bool PlaceBet(int amount, int dog)
        {
            if (Cash > amount && amount != 0)
            {

            }

            return true;
        }

        public void Collect(int winner)
        {

        }

    }
}
