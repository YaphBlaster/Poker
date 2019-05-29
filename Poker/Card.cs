using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Card
    {
        /// <summary>
        /// All possible suits
        /// </summary>
        public enum SUIT
        {
            HEARTS,
            SPADES,
            DIAMONDS,
            CLUBS
        }

        /// <summary>
        /// All possible values
        /// </summary>
        public enum VALUE
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN,
            EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
        }

        //properties
        public SUIT MySuit { get; set; }
        public VALUE MyValue { get; set; }

        /// <summary>
        /// Card constructor
        /// </summary>
        /// <param name="value">Card number value</param>
        /// <param name="suit">Card suit</param>
        public Card(string value, string suit)
        {

            MyValue = ConvertToCardNumber(value);
            MySuit = ConvertToSuit(suit);
        }

        public Card()
        {

        }

        /// <summary>
        /// Converts a string suit to the suit value
        /// </summary>
        /// <param name="suit">The inputted suit</param>
        /// <returns>Suit</returns>
        public SUIT ConvertToSuit(string suit)
        {
            SUIT tempSuit = SUIT.HEARTS;
            switch (suit.ToUpper())
            {
                case "H":
                    tempSuit = SUIT.HEARTS;
                    break;
                case "S":
                    tempSuit = SUIT.SPADES;
                    break;
                case "D":
                    tempSuit = SUIT.DIAMONDS;
                    break;
                case "C":
                    tempSuit = SUIT.CLUBS;
                    break;
            }

            return tempSuit;
        }

        /// <summary>
        /// Converts a string cardnumber to the card value
        /// </summary>
        /// <param name="cardNumber">The inputted card number</param>
        /// <returns>Card number</returns>
        public VALUE ConvertToCardNumber(string cardNumber)
        {
            VALUE tempNumber = (VALUE)0;
            switch (cardNumber)
            {
                case "A":
                    tempNumber = VALUE.ACE;
                    break;
                case "2":
                    tempNumber = VALUE.TWO;
                    break;
                case "3":
                    tempNumber = VALUE.THREE;
                    break;
                case "4":
                    tempNumber = VALUE.FOUR;
                    break;
                case "5":
                    tempNumber = VALUE.FIVE;
                    break;
                case "6":
                    tempNumber = VALUE.SIX;
                    break;
                case "7":
                    tempNumber = VALUE.SEVEN;
                    break;
                case "8":
                    tempNumber = VALUE.EIGHT;
                    break;
                case "9":
                    tempNumber = VALUE.NINE;
                    break;
                case "10":
                    tempNumber = VALUE.TEN;
                    break;
                case "J":
                    tempNumber = VALUE.JACK;
                    break;
                case "Q":
                    tempNumber = VALUE.QUEEN;
                    break;
                case "K":
                    tempNumber = VALUE.KING;
                    break;
            }

            return tempNumber;
        }

    }
}
