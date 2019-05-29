using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{

    /// <summary>
    /// All possible Hands
    /// </summary>
    public enum Hand
    {
        Nothing,
        OnePair,
        ThreeOfAKind,
        Flush,
        RoyalFlush
    }

    class EvaluateHand
    {
        private int heartsSum;
        private int diamondSum;
        private int clubsSum;
        private int spadesSum;

        private List<Card> cards;
        public int HighCard { get; set; }
        public Hand MyHand { get; private set; }

        public EvaluateHand(List<Card> Hand)
        {
            heartsSum = 0;
            diamondSum = 0;
            clubsSum = 0;
            spadesSum = 0;

            cards = Hand;
            MyHand = EvaluateMyHand();
        }


        public List<Card> Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }
        }

        private Hand EvaluateMyHand()
        {
            if (Flush())
                return Hand.Flush;
            else if (ThreeOfAKind())
                return Hand.ThreeOfAKind;
            else if (OnePair())
                return Hand.OnePair;

            //If it's none of these options, than the highest card wins
            HighCard = (int)cards[4].MyValue;
            return Hand.Nothing;


        }


        private void GetNumberOfSuit()
        {
            //Clear out any previous attempt
            heartsSum = 0;
            diamondSum = 0;
            clubsSum = 0;
            spadesSum = 0;

            //For each element in the cards list
            //Increase the specific suit
            foreach (var element in Cards)
            {
                if (element.MySuit == Card.SUIT.HEARTS)
                    heartsSum++;
                else if (element.MySuit == Card.SUIT.DIAMONDS)
                    diamondSum++;
                else if (element.MySuit == Card.SUIT.CLUBS)
                    clubsSum++;
                else if (element.MySuit == Card.SUIT.SPADES)
                    spadesSum++;

            }
        }


        /// <summary>
        /// Evaluates if there is a three of a kind
        /// </summary>
        /// <returns>If three of a kind is true or false</returns>
        private bool ThreeOfAKind()
        {

            //For each card in the hand (in reverse as the largest cards are at the end)
            for (int i = 4; i >= 2; i--)
            {
                //If the current card and the previous 2 in hand match, we have a three of a kind
                if (cards[i].MyValue == cards[i - 1].MyValue && cards[i].MyValue == cards[i - 2].MyValue)
                {
                    HighCard = (int)cards[i].MyValue;
                    return true;
                }
            }
            //No three of a kind was found
            return false;
        }

        /// <summary>
        /// Evaluate if there is pair
        /// </summary>
        /// <returns>If pair is true or false</returns>
        private bool OnePair()
        {
            //For each card in the hand (in reverse as the largest cards are at the end)
            for (int i = 4; i > 0; i--)
            {
                // if the current card and the card next to it are equal
                if (cards[i].MyValue == cards[i - 1].MyValue)
                {
                    HighCard = (int)cards[i].MyValue;
                    //The hand has a pair
                    return true;
                }
            }
            //No pair was found
            return false;
        }

        private bool Flush()
        {
            //get the number of each suit on hand
            GetNumberOfSuit();

            //set the high card in case of a tie
            HighCard = (int)cards[4].MyValue;

            //if all the suits are the same
            return heartsSum == 5 || diamondSum == 5 || clubsSum == 5 || spadesSum == 5;
        }

    }
}
