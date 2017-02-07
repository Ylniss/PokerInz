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
        public TexasHoldem(IList<IPlayer> players, BettingRule bettingRule, int smallBlind, int bigBlind, IDictionary<IPlayer, int> playerPerformanceScores) : base(players, bettingRule, smallBlind, bigBlind, playerPerformanceScores)
        {
        }

        public TexasHoldem(IList<IPlayer> players, BettingRule bettingRule, int smallBlind, int bigBlind, IDictionary<IPlayer, int> playerPerformanceScores, Deck playingCards) : base(players, bettingRule, smallBlind, bigBlind, playerPerformanceScores, playingCards)
        {
        }

        protected override void handOutCardsToPlayers()
        {
            foreach (IPlayer player in Players)
            {
                player.HoleCards = new List<ICard>() { PlayingCards[0], PlayingCards[1] };
                PlayingCards.Remove(PlayingCards.First());
                PlayingCards.Remove(PlayingCards.First());
            }
        }

        protected override void returnCardsToDeck()
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

        protected override void setBlinds()
        {
            ++Table.DealerPosition;

            foreach (IPlayer player in Players)
            {
                player.Blind = Blind.None;
                player.Bet = 0;
            }

            IPlayer nextPlayer = GetNextPlayer(Players[Table.DealerPosition]);
            nextPlayer.Blind = Blind.Small;
            nextPlayer.SetBlindBet(SmallBlind);

            nextPlayer = GetNextPlayer(nextPlayer);
            nextPlayer.Blind = Blind.Big;
            nextPlayer.SetBlindBet(BigBlind);
        }

        protected override void onDealStart()
        {
            PlayingCards.Shuffle();

            PlayerHandScores.Clear();

            handOutCardsToPlayers();

            setBlinds();
        }

        protected override void onLicitation()
        {
            foreach (GameStage gameStage in Enum.GetValues(typeof(GameStage)))
            {
                IPlayer nextPlayer = null;

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

                if (gameStage == GameStage.Preflop)
                    nextPlayer = GetNextActivePlayer(Players.Where(x => x.Blind == Blind.Big).First());
                else
                    nextPlayer = Players.Where(x => x.Blind == Blind.Small).First();

                notify();

                while (nextPlayer != null && (!allPlayersTookAction() || !lastPlayerCalled()) && (!allPlayersTookAction() || !isOnePlayerActiveLeft()) && !allActivePlayersChecked() && !allButOnePlayerFolded())
                {
                    if(nextPlayer != null && nextPlayer.CanTakeAction)
                        while (!takeAction(nextPlayer));

                    notify();

                    nextPlayer = GetNextActivePlayer(nextPlayer);             
                }

                foreach (IPlayer activePlayer in Players.Where(x => x.PlayerState != PlayerState.Folded))
                {
                    Table.Pot += activePlayer.Bet;
                    activePlayer.Bet = 0;

                    if (activePlayer.CanTakeAction && Players.Where(x => x.CanTakeAction).Count() > 1)
                        activePlayer.PlayerState = PlayerState.Active;

                    if (Players.Where(x => x.PlayerState == PlayerState.Folded).Count() == Players.Count - 1)
                        return; //if everyone folded except one, stop licitation round.
                }
            }

        }

        protected override void onDealFinish()
        {
            List<IPlayer> winningPlayers = getDealWinners();

            foreach (var winningPlayer in winningPlayers)
            {
                int pot = Table.Pot / winningPlayers.Count;
                winningPlayer.Chips += pot;
            }

            Table.Pot = 0;

            foreach (IPlayer player in Players)
                player.PlayerState = PlayerState.Active;

            returnCardsToDeck();

            removeLostPlayers();
        }

        private List<IPlayer> getDealWinners()
        {
            List<IPlayer> winningPlayers = new List<IPlayer>();

            if (Players.Where(x => x.PlayerState == PlayerState.Folded).Count() == Players.Count - 1) //everyone except one player folded
            {
                winningPlayers.Add(Players.Where(x => x.PlayerState != PlayerState.Folded).First());
            }
            else //there are more active players, so hand ranking tells who win
            {
                foreach (IPlayer player in Players.Where(x => x.PlayerState != PlayerState.Folded))
                {
                    evaluatePlayerHand(player);
                }

                int distinct = PlayerHandScores.Distinct().Count();

                if (PlayerHandScores.Count == distinct)
                    winningPlayers.Add(PlayerHandScores.OrderBy(x => x.Value).First().Key);
                else
                {
                    for(int i = 0; i < Players.Count - distinct; ++i)
                        winningPlayers.Add(PlayerHandScores.OrderBy(x => x.Value).ElementAt(i).Key);
                }
            }

            return winningPlayers;
        }
    }
}
