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
using System.Threading;

namespace Poker.GuiApp
{
    public partial class Form1 : Form
    {
        private Dictionary<ICard, Image> cardImages = new Dictionary<ICard, Image>();
        private List<IPlayer> players;
        private ITable table;

        private Game game;

        private Dictionary<int, Control[]> playerControls = new Dictionary<int, Control[]>();

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;

            initializePlayerControls();

            setAllCardBacks();
            setCardsDictionary();

            players = new List<IPlayer>
            {
                new RandomAi("bagn000", 0, 1000),
                new RandomAi("sdff111", 1, 1000),
                new RandomAi("zrd222", 2, 1000),
                new RandomAi("pepe333", 3, 1000),
            };

            

            game = new TexasHoldem(players, BettingRule.NoLimit, 10, 20);

            table = game.Table;

            game.GameEvent += new Game.GameHandler(UpdateGui);


        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            while (!game.IsGameOver)
            {
                game.Licitation();

                foreach (var hand in game.PlayerHandScores)
                {
                    richTextBoxLog.Text += $"{hand.Key.Name}'s ranking: {hand.Value} ({game.GetHandRanking(hand.Value)})\n";
                }
                Application.DoEvents();
            }

            UpdateGui(game);
        }

        public void UpdateGui(object subject)
        {
            if (subject is Game)
            {
                setGuiInformations(players);

                Game game = subject as Game;
                string communityCardsMessage = "Community cards: ";
                foreach (ICard card in game.Table.CommunityCards)
                    communityCardsMessage += $"{card.ToString()}, ";

                if (communityCardsMessage.Length > 2) //remove last comma
                    communityCardsMessage = communityCardsMessage.Remove(communityCardsMessage.Length - 2);

                richTextBoxLog.Text += $"{communityCardsMessage}\n";
                richTextBoxLog.Text += "Name\tChips\tBet\tState\n";
                foreach (IPlayer player in game.Players)
                {       
                    string betsMessage = $"{player.Name}\t{player.Chips}\t{player.Bet}\t";

                    if (player.PlayerState == PlayerState.Active)
                        betsMessage += "[Active]";
                    else if (player.PlayerState == PlayerState.Folded)
                        betsMessage += "[Folded]";
                    else if (player.PlayerState == PlayerState.Checked)
                        betsMessage += "[Checked]";
                    else
                        betsMessage += "[All-in]";

                    richTextBoxLog.Text += betsMessage + '\n';
                }

                richTextBoxLog.Text += $"Pot: {game.Table.Pot}\n";

                //foreach (var hand in game.PlayerHandScores)
                //{
                //    richTextBoxLog.Text += $"{hand.Key.Name}'s ranking: {hand.Value} ({game.GetHandRanking(hand.Value)})\n";
                //}

            }
            Application.DoEvents();
        }



        private void setGuiInformations(List<IPlayer> players)
        {
            var playersArray = players.ToArray();

            int count = players.Count;

            foreach (var playerControl in playerControls)
            {
                if (count > playerControl.Key)
                {
                    playerControl.Value[0].Text = playersArray[playerControl.Key].Name;
                    playerControl.Value[1].Text = playersArray[playerControl.Key].Chips.ToString();
                    if (playersArray[playerControl.Key].HoleCards.Any())
                    {
                        (playerControl.Value[2] as PictureBox).Image = cardImages[playersArray[playerControl.Key].HoleCards[0]];
                        (playerControl.Value[3] as PictureBox).Image = cardImages[playersArray[playerControl.Key].HoleCards[1]];
                    }
                    playerControl.Value[4].Text = playersArray[playerControl.Key].Bet.ToString();
                    playerControl.Value[5].Text = playersArray[playerControl.Key].PlayerState.ToString();

                }
                else
                {
                    playerControl.Value[0].Text = "";
                    playerControl.Value[1].Text = "0";
                    (playerControl.Value[2] as PictureBox).Image = resources.cards_back;
                    (playerControl.Value[3] as PictureBox).Image = resources.cards_back;
                    playerControl.Value[4].Text = "0";
                    playerControl.Value[5].Text = "";
                }
            }

            if (table.CommunityCards.Any())
            {
                card1Flop.Image = cardImages[table.CommunityCards[0]];
                card2Flop.Image = cardImages[table.CommunityCards[1]];
                card3Flop.Image = cardImages[table.CommunityCards[2]];
            }
            else
            {
                card1Flop.Image = null;
                card2Flop.Image = null;
                card3Flop.Image = null;
            }

            if (table.CommunityCards.Count > 3)
                cardTurn.Image = cardImages[table.CommunityCards[3]];
            else
                cardTurn.Image = null;

            if (table.CommunityCards.Count > 4)
                cardRiver.Image = cardImages[table.CommunityCards[4]];
            else
                cardRiver.Image = null;

            pot.Text = table.Pot.ToString();

            //Thread.Sleep(1000);

        }

        private void initializePlayerControls()
        {
            playerControls[0] = new Control[6] { nameP0, cashP0, card1P0, card2P0, betP0, statusP0 };
            playerControls[1] = new Control[6] { nameP1, cashP1, card1P1, card2P1, betP1, statusP1 };
            playerControls[2] = new Control[6] { nameP2, cashP2, card1P2, card2P2, betP2, statusP2 };
            playerControls[3] = new Control[6] { nameP3, cashP3, card1P3, card2P3, betP3, statusP3 };
            playerControls[4] = new Control[6] { nameP4, cashP4, card1P4, card2P4, betP4, statusP4 };
            playerControls[5] = new Control[6] { nameP5, cashP5, card1P5, card2P5, betP5, statusP5 };
            playerControls[6] = new Control[6] { nameP6, cashP6, card1P6, card2P6, betP6, statusP6 };
            playerControls[7] = new Control[6] { nameP7, cashP7, card1P7, card2P7, betP7, statusP7 };
            playerControls[8] = new Control[6] { nameP8, cashP8, card1P8, card2P8, betP8, statusP8 };
            playerControls[9] = new Control[6] { nameP9, cashP9, card1P9, card2P9, betP9, statusP9 };
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
