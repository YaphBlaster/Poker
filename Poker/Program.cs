using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Program
    {
        private const string SelectionInstructions =
            "\nPlease enter the number of the following options:" +
            "\n 1. Enter Player with Hand" +
            "\n 2. Run Game" +
            "\n 3. Quit";

        private static List<Player> Players = new List<Player>();

        /// <summary>
        /// Main function to run program
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var chosenOption = 0;
            Console.Clear();

            //Prompt user for input
            do
            {
                //Show instructions
                Console.WriteLine("\n" + SelectionInstructions);

                //Parse the option that the user entered
                chosenOption = int.Parse(Console.ReadLine());

                switch (chosenOption)
                {
                    case 1:
                        //Get player information
                        GetPlayerInfo();
                        break;
                    case 2:
                        //Evaluate the hands of the players
                        var winner = EvaluatePokerHands(Players);

                        //Display the winner and winning hand
                        Console.WriteLine("\n The winner is: " + winner["winner"]);
                        Console.WriteLine("\n With a hand of: " + winner["hand"]);
                        Console.WriteLine("\n And a high card of: " + winner["highCard"]);

                        break;
                }
            }//Exit if the user has chosen option 3
            while (chosenOption != 3);
        }

        /// <summary>
        /// Get players information (Name and Hand)
        /// 
        /// Information should be presented in this order:
        /// Name, Card1, Card2, Card3, Card4, Card5
        /// </summary>
        public static void GetPlayerInfo()
        {
            Console.Clear();
            Console.WriteLine("\n Please enter you name");

            //Split the user inputted information by each comma
            var name = Console.ReadLine();

            Console.WriteLine("\n Please enter your hand (Ex: 2h,3h,4h,5h,6h)");

            var cards = Console.ReadLine();


            //Create a new Hand of Cards
            var Hand = new List<Card>();


            //Create Hand
            CreateHand(cards, Hand);

            //Sort the hand
            SortCards(Hand);

            //Add the new player to the list of players
            Players.Add(new Player(name, Hand));

        }

        public static void CreateHand(string cards, List<Card> hand)
        {
            //Split the user inputted information by each comma
            var cardsArray = cards.Split(',');

            //For every section in the input array
            for (var i = 0; i < cardsArray.Length; i++)
            {
                //Trim each array item
                var item = cardsArray[i].Trim();

                //Get the suit index, which is the last character of the string
                var suitIndex = item.Length - 1;

                //Add the card to the hand
                hand.Add(new Card(item.Substring(0, suitIndex), item.Substring(suitIndex)));
            }
        }

        /// <summary>
        /// Sorts the hand of cards based on the value
        /// </summary>
        /// <param name="handOfCards">The hand of cards that will be sorted</param>
        public static void SortCards(List<Card> handOfCards)
        {
            //Query the handOfCards from ascending order
            var queryHand = from hand in handOfCards
                            orderby hand.MyValue
                            select hand;

            //Replace the card at the proper index
            var index = 0;
            foreach (var card in queryHand.ToList())
            {
                handOfCards[index] = card;
                index++;
            }
        }

        /// <summary>
        /// Evaluate the Player's hand
        /// </summary>
        public static Dictionary<string, string> EvaluatePokerHands(List<Player> players)
        {
            var currentWinner = "";

            //Set the winnerHand to Nothing
            EvaluateHand winnerHand = null;

            //For each player
            foreach (var player in players)
            {

                var tempEvaluateHand = new EvaluateHand(player.Cards);

                //If the current hand is greater than the current winning hand
                if (winnerHand == null || tempEvaluateHand.MyHand > winnerHand.MyHand)
                {
                    //Replace the current winning hand
                    winnerHand = tempEvaluateHand;
                    currentWinner = player.Name;
                }
                //If there is a tie with the current winning hand
                else if (tempEvaluateHand.MyHand == winnerHand.MyHand)
                {
                    //Check if the current player high card is equal to the winning player high card
                    if (tempEvaluateHand.HighCard == winnerHand.HighCard)
                    {
                        //both the players are the winners
                        currentWinner += " and " + player.Name;
                    }
                    //If the current player high card is greater than the winning player high card
                    else if (tempEvaluateHand.HighCard > winnerHand.HighCard)
                    {
                        //Replace the current winning hand
                        winnerHand = tempEvaluateHand;
                        currentWinner = player.Name;
                    }
                }
            }



            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("winner", currentWinner);
            dict.Add("hand", winnerHand.MyHand.ToString());
            dict.Add("highCard", winnerHand.HighCard.ToString());

            return dict;


        }
    }
}
