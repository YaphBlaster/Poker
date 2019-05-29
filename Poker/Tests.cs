using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker
{
    [TestClass]
    public class ProgramTests
    {

        // these are needed on every test
        List<Player> Players = new List<Player>();
        List<Card> Hand = new List<Card>();


        [TestInitialize]
        public void TestInitialize()
        {
            Players.Clear();
            Hand.Clear();
        }


        [TestMethod]
        public void Flush()
        {
            var name = "Joe";
            var cards = "2h, 3h, 4h, 5h, 6h";

            CreatePlayer(name, cards);

            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Joe", result["winner"]);
            Assert.AreEqual("Flush", result["hand"]);
            Assert.AreEqual("6", result["highCard"]);
        }

        [TestMethod]
        public void ThreeOfAKind()
        {
            //Arrange
            var name = "Joe";
            var cards = "2h, 2c, 2d, 7h, 7s";

            //Act
            Program.CreateHand(cards, Hand);
            Program.SortCards(Hand);
            Players.Add(new Player(name, Hand));

            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Joe", result["winner"]);
            Assert.AreEqual("ThreeOfAKind", result["hand"]);
            Assert.AreEqual("2", result["highCard"]);
        }


        [TestMethod]
        public void OnePair()
        {
            //Arrange
            var name = "Joe";
            var cards = "2h, 2c, 3c, 6s, 7s";

            //Act
            Program.CreateHand(cards, Hand);
            Program.SortCards(Hand);
            Players.Add(new Player(name, Hand));

            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Joe", result["winner"]);
            Assert.AreEqual("OnePair", result["hand"]);
            Assert.AreEqual("2", result["highCard"]);
        }

        [TestMethod]
        public void Nothing()
        {
            var name = "Joe";
            var cards = "5C, 7D, 8H, 9S, QD";

            //Act
            Program.CreateHand(cards, Hand);
            Program.SortCards(Hand);
            Players.Add(new Player(name, Hand));

            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Joe", result["winner"]);
            Assert.AreEqual("Nothing", result["hand"]);
            Assert.AreEqual("12", result["highCard"]);
        }

        [TestMethod]
        public void Example1()
        {

            string[] playerNames = { "Joe", "Bob", "Sally" };
            string[] playerCards = {
                "8S, 8D, AD, QD, JH",
                "AS, QS, 8S, 6S, 4S",
                "4S, 4H, 3H, QC, 8C" };


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

            string[] playerNames = { "Joe", "Bob", "Sally" };
            string[] playerCards = { "QD, 8D, KD, 7D, 3D", "AS, QS, 8S, 6S, 4S", "4S, 4H, 3H, QC, 8C" };


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

            string[] playerNames = { "Joe", "Jen", "Bob" };
            string[] playerCards = {
                "3H, 5D, 9C, 9D, QH",
                "5C, 7D, 9H, 9S, QS",
                "2H, 2C, 5S, 10C, AH" };


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
            string[] playerNames = { "Joe", "Jen", "Bob" };
            string[] playerCards = {
                "2H, 3D, 4C, 5D, 10H",
                "5C, 7D, 8H, 9S, QD",
                "2C, 4D, 5S, 10C, JH" };


            CreatePlayers(playerNames, playerCards);


            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Jen", result["winner"]);
            Assert.AreEqual("Nothing", result["hand"]);
            Assert.AreEqual("12", result["highCard"]);
        }

        [TestMethod]
        public void SameCards()
        {
            string[] playerNames = { "Joe", "Jen", "Bob" };
            string[] playerCards = {
                "5D, 7C, 8D, 9C, QJ",
                "5C, 7D, 8H, 9S, QD",
                "2C, 4D, 5S, 10C, JH" };


            CreatePlayers(playerNames, playerCards);


            var result = Program.EvaluatePokerHands(Players);

            //Assert
            Assert.AreEqual("Joe and Jen and Bob split the pot", result["winner"]);
            Assert.AreEqual("Nothing", result["hand"]);
            Assert.AreEqual("12", result["highCard"]);
        }


        private void CreatePlayer(string playerName, string playerCards, List<Card> hand = null)
        {
            var handTemp = hand == null ? Hand : hand;
            //Act
            Program.CreateHand(playerCards, handTemp);
            Program.SortCards(handTemp);
            Players.Add(new Player(playerName, handTemp));


        }

        private void CreatePlayers(string[] playerNames, string[] playerHands)
        {
            //For every section in the input array
            for (var i = 0; i < playerNames.Length; i++)
            {
                var hand = new List<Card>();

                CreatePlayer(playerNames[i], playerHands[i], hand);
            }


        }
    }


}
