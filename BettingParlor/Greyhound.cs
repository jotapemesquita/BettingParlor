using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BettingParlor
{
    public class Greyhound
    {
        /// <summary>
        /// Onde PictureBox inicia;
        /// </summary>
        public int StartingPosition;
        /// <summary>
        /// O tamanho da pista de corrida.
        /// </summary>
        public int RacetrackLength;
        /// <summary>
        /// Meu objeto PictureBox.
        /// </summary>
        public PictureBox MyPictureBox = null;
        /// <summary>
        /// Minha posição na pista.
        /// </summary>
        public int Location = 0;
        /// <summary>
        /// Uma instância de Random.
        /// </summary>
        public Random Randomizer;

        /// <summary>
        ///  Faz o cão correr.
        /// </summary>
        /// <returns>Retorna true se o cão ganhar.</returns>
        public bool Run()
        {
            int distance = Randomizer.Next(1, 4);
            Point p = MyPictureBox.Location;
            p.X += distance;
            Location = p.X;
            MyPictureBox.Location = p;

            return Location >= RacetrackLength;
        }

        /// <summary>
        /// Redefine a posição para a linha de partida.
        /// </summary>
        public void TakeStartingPosition()
        {
            Point p = MyPictureBox.Location;
            p.X = StartingPosition;
            Location = 0;
            MyPictureBox.Location = p;
        }

    }
}
