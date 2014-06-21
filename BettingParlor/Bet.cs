using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingParlor
{
    public class Bet
    {
        /// <summary>
        /// A quantidade de dinheiro que foi apostada.
        /// </summary>
        public int Amount;
        /// <summary>
        /// O número do cão em que apostamos.
        /// </summary>
        public int Dog;
        /// <summary>
        /// O cara que fez a aposta.
        /// </summary>
        public Guy Bettor;

        public string GetDescription()
        {
            string description = Amount > 0 ? Bettor.Name + " apostou R$ " + Amount + " no cão #" + Dog : Bettor.Name + " não apostou.";
            return description;
        }

        public int PayOut(int winner)
        {
            if (Dog == winner)
            {
                return Amount;
            }

            return -Amount;
        }
    }
}
