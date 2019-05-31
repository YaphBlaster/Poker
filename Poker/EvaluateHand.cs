using System.Collections.Generic;

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
        Flush
    }

    class EvaluateHand
    {
        private int _HeartsSum;
        private int _DiamondSum;
        private int _ClubsSum;
        private int _SpadesSum;
        private List<Card> _Cards;

        public int HighCard { get; set; }
        public Hand MyHand { get; private set; }
        public List<int> cardNumbers = new List<int>();

        public EvaluateHand(List<Card> Hand)
        {
            _HeartsSum = 0;
            _DiamondSum = 0;
            _ClubsSum = 0;
            _SpadesSum = 0;

            _Cards = Hand;
            MyHand = EvaluateMyHand();
        }


        public List<Card> Cards
        {
            get { return _Cards; }
            set
            {
                _Cards[0] = value[0];
                _Cards[1] = value[1];
                _Cards[2] = value[2];
                _Cards[3] = value[3];
                _Cards[4] = value[4];
            }
        }

        private Hand EvaluateMyHand()
        {
            // Arrange the card numbers into a list to be used to determine tie breakers
            foreach (var card in _Cards)
            {
                cardNumbers.Add((int)card.MyValue);
            }

            if (Flush())
                return Hand.Flush;
            else if (ThreeOfAKind())
                return Hand.ThreeOfAKind;
            else if (OnePair())
                return Hand.OnePair;

            //If it's none of these options, than the highest card wins
            HighCard = (int)_Cards[4].MyValue;
            return Hand.Nothing;


        }

        /// <summary>
        /// Evaluates the number of specific suits in each hand
        /// </summary>
        private void NumberOfSuits()
        {
            //Clear out any previous attempt
            _HeartsSum = 0;
            _DiamondSum = 0;
            _ClubsSum = 0;
            _SpadesSum = 0;

            //For each element in the cards list
            //Increase the specific suit
            foreach (var element in Cards)
            {
                if (element.MySuit == Card.SUIT.HEARTS)
                    _HeartsSum++;
                else if (element.MySuit == Card.SUIT.DIAMONDS)
                    _DiamondSum++;
                else if (element.MySuit == Card.SUIT.CLUBS)
                    _ClubsSum++;
                else if (element.MySuit == Card.SUIT.SPADES)
                    _SpadesSum++;

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
                if (_Cards[i].MyValue == _Cards[i - 1].MyValue && _Cards[i].MyValue == _Cards[i - 2].MyValue)
                {
                    HighCard = (int)_Cards[i].MyValue;
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
                if (_Cards[i].MyValue == _Cards[i - 1].MyValue)
                {
                    HighCard = (int)_Cards[i].MyValue;
                    //The hand has a pair
                    return true;
                }
            }
            //No pair was found
            return false;
        }

        /// <summary>
        /// Evaluate if there is a flush
        /// </summary>
        /// <returns>If flush is true of false</returns>
        private bool Flush()
        {
            //get the number of each suit on hand
            NumberOfSuits();

            //set the high card in case of a tie
            HighCard = (int)_Cards[4].MyValue;

            //if all the suits are the same
            return _HeartsSum == 5 || _DiamondSum == 5 || _ClubsSum == 5 || _SpadesSum == 5;
        }

    }
}
