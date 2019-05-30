using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker
{
    [TestClass]
    public class ProgramTests
    {
        // these are needed on every test
        List<Player> Players = new List<Player>();
        string Name = "Joe";


        // Before every test runs, clear the Players list
        [TestInitialize]
        public void TestInitialize()
        {
            Players.Clear();
        }


        [TestMethod]
        public void CanDetectFlush()
        {
            //Arrange
            var cards = "2h, 3h, 4h, 5h, 6h";

            // Act
            CreatePlayer(Name, cards);
            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Flush", result["hand"]);
        }

        [TestMethod]
        public void CanDetectThreeOfAKind()
        {
            //Arrange
            var cards = "2h, 2c, 2d, 7h, 7s";

            //Act
            CreatePlayer(Name, cards);
            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("ThreeOfAKind", result["hand"]);
        }


        [TestMethod]
        public void CanDetectOnePair()
        {
            //Arrange
            var cards = "2h, 2c, 3c, 6s, 7s";

            //Act
            CreatePlayer(Name, cards);
            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("OnePair", result["hand"]);
        }

        [TestMethod]
        public void CanDetectNothing()
        {
            //Arrange
            var cards = "5C, 7D, 8H, 9S, QD";

            //Act
            CreatePlayer(Name, cards);
            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Nothing", result["hand"]);
        }

        [TestMethod]
        public void CanDetermineHighCard()
        {
            //Arrange
            var cards = "5C, 7D, 8H, 9S, QD";

            //Act
            CreatePlayer(Name, cards);
            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("12", result["highCard"]);
        }

        [TestMethod]
        public void Example1()
        {
            //Arrange
            string[] playerNames = { "Joe", "Bob", "Sally" };
            string[] playerCards = {
                "8S, 8D, AD, QD, JH",
                "AS, QS, 8S, 6S, 4S",
                "4S, 4H, 3H, QC, 8C" };

            //Act
            CreatePlayers(playerNames, playerCards);
            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Bob", result["winner"]);
            Assert.AreEqual("Flush", result["hand"]);
            Assert.AreEqual("14", result["highCard"]);
        }

        [TestMethod]
        public void Example2()
        {
            //Arrange
            string[] playerNames = { "Joe", "Bob", "Sally" };
            string[] playerCards = { "QD, 8D, KD, 7D, 3D", "AS, QS, 8S, 6S, 4S", "4S, 4H, 3H, QC, 8C" };

            //Act
            CreatePlayers(playerNames, playerCards);
            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Bob", result["winner"]);
            Assert.AreEqual("Flush", result["hand"]);
            Assert.AreEqual("14", result["highCard"]);
        }

        [TestMethod]
        public void Example3()
        {
            //Arrange
            string[] playerNames = { "Joe", "Jen", "Bob" };
            string[] playerCards = {
                "3H, 5D, 9C, 9D, QH",
                "5C, 7D, 9H, 9S, QS",
                "2H, 2C, 5S, 10C, AH" };

            //Act
            CreatePlayers(playerNames, playerCards);
            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Jen", result["winner"]);
            Assert.AreEqual("OnePair", result["hand"]);
            Assert.AreEqual("9", result["highCard"]);
        }

        [TestMethod]
        public void Example4()
        {
            //Arrange
            string[] playerNames = { "Joe", "Jen", "Bob" };
            string[] playerCards = {
                "2H, 3D, 4C, 5D, 10H",
                "5C, 7D, 8H, 9S, QD",
                "2C, 4D, 5S, 10C, JH" };

            //Act
            CreatePlayers(playerNames, playerCards);
            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Jen", result["winner"]);
            Assert.AreEqual("Nothing", result["hand"]);
            Assert.AreEqual("12", result["highCard"]);
        }

        [TestMethod]
        public void CanDetermineTwoWayTie()
        {
            //Arrange
            string[] playerNames = { "Joe", "Jen", "Bob" };
            string[] playerCards = {
                "5D, 7C, 8D, 9C, QJ",
                "5C, 7D, 8H, 9S, QD",
                "2C, 4D, 5S, 10C, JH" };

            //Act
            CreatePlayers(playerNames, playerCards);
            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Joe and Jen split the pot", result["winner"]);
            Assert.AreEqual("Nothing", result["hand"]);
            Assert.AreEqual("12", result["highCard"]);
        }

        [TestMethod]
        public void CanDetermineThreeWayTie()
        {
            //Arrange
            string[] playerNames = { "Joe", "Jen", "Bob" };
            string[] playerCards = {
                "2h, 3h, 4h, 5h, 6h",
                "2d, 3d, 4d, 5d, 6d",
                "2c, 3c, 4c, 5c, 6c" };

            //Act
            CreatePlayers(playerNames, playerCards);
            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Joe and Jen and Bob split the pot", result["winner"]);
            Assert.AreEqual("Flush", result["hand"]);
            Assert.AreEqual("6", result["highCard"]);
        }

        /// <summary>
        /// Creates a single player and adds the player to the Players list
        /// </summary>
        /// <param name="playerName">Name of player</param>
        /// <param name="playerCards">Cards that the player has that will be turned into a Hand</param>
        private void CreatePlayer(string playerName, string playerCards)
        {
            var hand = new List<Card>();

            //Create player's hand from cards
            Program.CreateHand(playerCards, hand);

            //Sort player's cards
            Program.SortCards(hand);

            //Add player to list of players
            Players.Add(new Player(playerName, hand));


        }

        /// <summary>
        /// Creates multiple players and adds them to the Players list
        /// </summary>
        /// <param name="playerNames">Array of player names</param>
        /// <param name="playerCardsArray">Array of player cards</param>
        private void CreatePlayers(string[] playerNames, string[] playerCardsArray)
        {
            //For every player
            for (var i = 0; i < playerNames.Length; i++)
            {
                //Create a player for that name and cards 
                CreatePlayer(playerNames[i], playerCardsArray[i]);
            }
        }
    }


}
