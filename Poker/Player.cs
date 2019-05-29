using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }

        public Player()
        {

        }

        /// <summary>
        /// Player constructor
        /// </summary>
        /// <param name="myName">The name of the player</param>
        /// <param name="myCards">The cards of the player</param>
        public Player(string myName, List<Card> myCards)
        {
            Name = myName;
            Cards = myCards;
        }
    }
}
