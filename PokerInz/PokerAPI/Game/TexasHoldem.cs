using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerAPI.Cards;
using PokerAPI.Enums;

namespace PokerAPI.Game
{
    public class TexasHoldem : Game
    {
        public TexasHoldem(IList<IPlayer> players, BettingRule bettingRule, int smallBlind, int bigBlind) : base(players, bettingRule, smallBlind, bigBlind)
        {
        }

        public TexasHoldem(IList<IPlayer> players, BettingRule bettingRule, int smallBlind, int bigBlind, Deck playingCards) : base(players, bettingRule, smallBlind, bigBlind, playingCards)
        {
        }

        public override void HandOutCardsToPlayers()
        {
            foreach (IPlayer player in Players)
            {
                player.HoleCards = new List<ICard>() { PlayingCards[0], PlayingCards[1] };
                PlayingCards.Remove(PlayingCards.First());
                PlayingCards.Remove(PlayingCards.First());
            }
        }

        public override void ReturnCardsToDeck()
        {
            foreach (IPlayer player in Players)
            {
                foreach (ICard card in player.HoleCards)
                {
                    PlayingCards.Add(card);
                }

                player.HoleCards.Clear();
            }

            foreach (ICard card in Table.CommunityCards)
            {
                PlayingCards.Add(card);
            }

            Table.CommunityCards.Clear();
        }

        public override void SetBlinds()
        {
            foreach (IPlayer player in Players)
                player.Blind = Blind.None;

            IPlayer nextPlayer = GetNextPlayer(Players[Table.DealerPosition]);
            nextPlayer.Blind = Blind.Small;
            nextPlayer.Bet = SmallBlind;

            nextPlayer = GetNextPlayer(nextPlayer);
            nextPlayer.Blind = Blind.Big;
            nextPlayer.Bet = BigBlind;
        }

        public override void Licitation()
        {
            foreach (GameStage gameStage in Enum.GetValues(typeof(GameStage)))
            {
                if (gameStage == GameStage.Flop)
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        Table.CommunityCards.Add(PlayingCards.First());
                        PlayingCards.Remove(PlayingCards.First());
                    }
                }
                else if (gameStage != GameStage.Preflop)
                {
                    Table.CommunityCards.Add(PlayingCards.First());
                    PlayingCards.Remove(PlayingCards.First());
                }

                notify();

                IPlayer nextPlayer = GetNextActivePlayer(Players.Where(x => x.Blind == Blind.Big).First());

                while (nextPlayer != null && (!allPlayersTookAction() || !lastPlayerCalled()))// && !allActivePlayersChecked() && !isOnePlayerActiveLeft())
                {
                    if(nextPlayer != null && nextPlayer.CanTakeAction)
                        while (!takeAction(nextPlayer));

                    nextPlayer = GetNextActivePlayer(nextPlayer);             
                }

                notify();

                foreach (IPlayer activePlayer in Players.Where(x => x.PlayerState != PlayerState.Folded))
                {
                    Table.Pot += activePlayer.Bet;
                    activePlayer.Bet = 0;

                    if (activePlayer.PlayerState == PlayerState.Checked)
                        activePlayer.PlayerState = PlayerState.Active;
                }
            }
        }

        public override void OnDealFinish()
        {
            ++Table.DealerPosition;

            IPlayer winningPlayer;

            if (Players.Where(x => x.PlayerState == PlayerState.Folded).Count() == Players.Count - 1) //everyone except one player folded
            {
                winningPlayer = Players.Where(x => x.PlayerState != PlayerState.Folded).First();
            }   
            else //there are more active players, so hand ranking tells who win
            {
                IDictionary<IPlayer, int> playerHandRankings = new Dictionary<IPlayer, int>();

                foreach(IPlayer player in Players.Where(x => x.PlayerState != PlayerState.Folded))
                {
                    playerHandRankings[player] = evaluatePlayerHand(player);
                }

                winningPlayer = playerHandRankings.OrderBy(x => x.Value).Last().Key;
            }

            winningPlayer.Chips += Table.Pot;
            Table.Pot = 0;

            removeLostPlayers();

            foreach (IPlayer player in Players)
                player.PlayerState = PlayerState.Active;
        }
    }
}
