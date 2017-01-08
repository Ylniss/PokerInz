using PokerAPI;
using PokerAPI.Cards;
using PokerAPI.Enums;
using PokerAPI.Game;
using PokerAPI.Ai;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.GuiApp.Properties;

namespace Poker.GuiApp
{
    public partial class Form1 : Form
    {
        private Dictionary<ICard, Image> cardImages = new Dictionary<ICard, Image>();
        private List<IPlayer> players;

        public Form1()
        {
            InitializeComponent();

            setAllCardBacks();
            setCardsDictionary();

            players = new List<IPlayer>
            {
                new RandomAi("bagn000", 0, 1000),
                new RandomAi("sdfsdf111", 1, 1000),
                new RandomAi("zrd222", 2, 1000),
                new RandomAi("pepe333", 3, 1000),
            };

            

            Game game = new TexasHoldem(players, BettingRule.NoLimit, 10, 20);

            game.GameEvent += new Game.GameHandler(UpdateGui);

            while (!game.IsGameOver)
            {
                game.Licitation();

                
                //foreach (var hand in game.PlayerHandScores)
                //{
                //    Console.WriteLine($"{hand.Key.Name}'s ranking: {hand.Value} ({game.GetHandRanking(hand.Value)})");
                //}
            }

            

        }

        public void UpdateGui(object subject)
        {
            if (subject is Game)
            {
                setGuiInformations(players);
                //Game game = subject as Game;
                //string communityCardsMessage = "Community cards:  ";
                //foreach (ICard card in game.Table.CommunityCards)
                //    communityCardsMessage += $"{card.ToString()}, ";

                //if (communityCardsMessage.Length > 2) //remove last comma
                //    communityCardsMessage = communityCardsMessage.Remove(communityCardsMessage.Length - 2);

                //Console.WriteLine($"{communityCardsMessage}\n");
                //Console.WriteLine("Bets:");
                //foreach (IPlayer player in game.Players)
                //{
                //    string betsMessage = $"{player.Name}  \t chips:\t {player.Chips}\t bet:{player.Bet}";

                //    if (player.PlayerState == PlayerState.Active)
                //        betsMessage += " [ACTIVE]";
                //    else if (player.PlayerState == PlayerState.Folded)
                //        betsMessage += " [FOLDED]";
                //    else if (player.PlayerState == PlayerState.Checked)
                //        betsMessage += " [CHECKED]";
                //    else
                //        betsMessage += " [ALL-IN]";

                //    Console.WriteLine(betsMessage);
                //}

                //Console.WriteLine($"Pot: {game.Table.Pot}");

            }
        }

        private void setGuiInformations(List<IPlayer> players)
        {
            var playersArray = players.ToArray();

            int count = players.Count;

            if (count > 0)
            {
                nameP0.Text = playersArray[0].Name;
                cashP0.Text = playersArray[0].Chips.ToString();
                card1P0.Image = cardImages[playersArray[0].HoleCards[0]];
                card2P0.Image = cardImages[playersArray[0].HoleCards[1]];
                betP0.Text = playersArray[0].Bet.ToString();
            }

            if (count > 1)
            {
                nameP1.Text = playersArray[1].Name;
                cashP1.Text = playersArray[1].Chips.ToString();
                card1P1.Image = cardImages[playersArray[1].HoleCards[0]];
                card2P1.Image = cardImages[playersArray[1].HoleCards[1]];
                betP1.Text = playersArray[1].Bet.ToString();
            }

            if (count > 2)
            {
                nameP2.Text = playersArray[2].Name;
                cashP2.Text = playersArray[2].Chips.ToString();
                card1P2.Image = cardImages[playersArray[2].HoleCards[0]];
                card2P2.Image = cardImages[playersArray[2].HoleCards[1]];
                betP2.Text = playersArray[2].Bet.ToString();
            }

            if (count > 3)
            {
                nameP3.Text = playersArray[3].Name;
                cashP3.Text = playersArray[3].Chips.ToString();
                card1P3.Image = cardImages[playersArray[3].HoleCards[0]];
                card2P3.Image = cardImages[playersArray[3].HoleCards[1]];
                betP3.Text = playersArray[3].Bet.ToString();
            }

            if (count > 4)
            {
                nameP4.Text = playersArray[4].Name;
                cashP4.Text = playersArray[4].Chips.ToString();
                card1P4.Image = cardImages[playersArray[4].HoleCards[0]];
                card2P4.Image = cardImages[playersArray[4].HoleCards[1]];
                betP4.Text = playersArray[4].Bet.ToString();
            }

            if (count > 5)
            {
                nameP5.Text = playersArray[5].Name;
                cashP5.Text = playersArray[5].Chips.ToString();
                card1P5.Image = cardImages[playersArray[5].HoleCards[0]];
                card2P5.Image = cardImages[playersArray[5].HoleCards[1]];
                betP5.Text = playersArray[5].Bet.ToString();
            }

            if (count > 6)
            {
                nameP6.Text = playersArray[6].Name;
                cashP6.Text = playersArray[6].Chips.ToString();
                card1P6.Image = cardImages[playersArray[6].HoleCards[0]];
                card2P6.Image = cardImages[playersArray[6].HoleCards[1]];
                betP6.Text = playersArray[6].Bet.ToString();
            }

            if (count > 7)
            {
                nameP7.Text = playersArray[7].Name;
                cashP7.Text = playersArray[7].Chips.ToString();
                card1P7.Image = cardImages[playersArray[7].HoleCards[0]];
                card2P7.Image = cardImages[playersArray[7].HoleCards[1]];
                betP7.Text = playersArray[7].Bet.ToString();
            }

            if (count > 8)
            {
                nameP8.Text = playersArray[8].Name;
                cashP8.Text = playersArray[8].Chips.ToString();
                card1P8.Image = cardImages[playersArray[8].HoleCards[0]];
                card2P8.Image = cardImages[playersArray[8].HoleCards[1]];
                betP8.Text = playersArray[8].Bet.ToString();
            }

            if (count > 9)
            {
                nameP9.Text = playersArray[9].Name;
                cashP9.Text = playersArray[9].Chips.ToString();
                card1P9.Image = cardImages[playersArray[9].HoleCards[0]];
                card2P9.Image = cardImages[playersArray[9].HoleCards[1]];
                betP9.Text = playersArray[9].Bet.ToString();
            }
        }

        private void setAllCardBacks()
        {
            card1P0.Image = resources.cards_back;
            card2P0.Image = resources.cards_back;
            card1P1.Image = resources.cards_back;
            card2P1.Image = resources.cards_back;
            card1P2.Image = resources.cards_back;
            card2P2.Image = resources.cards_back;
            card1P3.Image = resources.cards_back;
            card2P3.Image = resources.cards_back;
            card1P4.Image = resources.cards_back;
            card2P4.Image = resources.cards_back;
            card1P5.Image = resources.cards_back;
            card2P5.Image = resources.cards_back;
            card1P6.Image = resources.cards_back;
            card2P6.Image = resources.cards_back;
            card1P7.Image = resources.cards_back;
            card2P7.Image = resources.cards_back;
            card1P8.Image = resources.cards_back;
            card2P8.Image = resources.cards_back;
            card1P9.Image = resources.cards_back;
            card2P9.Image = resources.cards_back;
        }

        private void setCardsDictionary()
        {
            cardImages.Add(new Card(CardSuit.Clubs, CardRank.Ace), resources.cards_00_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.Ace), resources.cards_00_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.Ace), resources.cards_00_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.Ace), resources.cards_00_03);

            cardImages.Add(new Card(CardSuit.Clubs, CardRank.Two), resources.cards_01_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.Two), resources.cards_01_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.Two), resources.cards_01_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.Two), resources.cards_01_03);

            cardImages.Add(new Card(CardSuit.Clubs, CardRank.Three), resources.cards_02_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.Three), resources.cards_02_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.Three), resources.cards_02_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.Three), resources.cards_02_03);

            cardImages.Add(new Card(CardSuit.Clubs, CardRank.Four), resources.cards_03_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.Four), resources.cards_03_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.Four), resources.cards_03_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.Four), resources.cards_03_03);

            cardImages.Add(new Card(CardSuit.Clubs, CardRank.Five), resources.cards_04_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.Five), resources.cards_04_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.Five), resources.cards_04_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.Five), resources.cards_04_03);

            cardImages.Add(new Card(CardSuit.Clubs, CardRank.Six), resources.cards_05_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.Six), resources.cards_05_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.Six), resources.cards_05_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.Six), resources.cards_05_03);

            cardImages.Add(new Card(CardSuit.Clubs, CardRank.Seven), resources.cards_06_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.Seven), resources.cards_06_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.Seven), resources.cards_06_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.Seven), resources.cards_06_03);

            cardImages.Add(new Card(CardSuit.Clubs, CardRank.Eight), resources.cards_07_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.Eight), resources.cards_07_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.Eight), resources.cards_07_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.Eight), resources.cards_07_03);

            cardImages.Add(new Card(CardSuit.Clubs, CardRank.Nine), resources.cards_08_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.Nine), resources.cards_08_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.Nine), resources.cards_08_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.Nine), resources.cards_08_03);

            cardImages.Add(new Card(CardSuit.Clubs, CardRank.Ten), resources.cards_09_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.Ten), resources.cards_09_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.Ten), resources.cards_09_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.Ten), resources.cards_09_03);

            cardImages.Add(new Card(CardSuit.Clubs, CardRank.Jack), resources.cards_10_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.Jack), resources.cards_10_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.Jack), resources.cards_10_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.Jack), resources.cards_10_03);

            cardImages.Add(new Card(CardSuit.Clubs, CardRank.Queen), resources.cards_11_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.Queen), resources.cards_11_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.Queen), resources.cards_11_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.Queen), resources.cards_11_03);

            cardImages.Add(new Card(CardSuit.Clubs, CardRank.King), resources.cards_12_00);
            cardImages.Add(new Card(CardSuit.Spades, CardRank.King), resources.cards_12_01);
            cardImages.Add(new Card(CardSuit.Hearts, CardRank.King), resources.cards_12_02);
            cardImages.Add(new Card(CardSuit.Diamonds, CardRank.King), resources.cards_12_03);
        } 

    }
}
