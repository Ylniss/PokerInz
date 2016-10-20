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
                PlayingCards.Add(player.HoleCards[0]);
                PlayingCards.Add(player.HoleCards[1]);
            }

            foreach (ICard card in Table.CommunityCards)
            {
                PlayingCards.Add(card);
            }
        }

        public override void SetBlinds()
        {
            foreach (IPlayer player in Players)
                player.Blind = Blind.None;

            IPlayer nextPlayer = GetNextPlayer(Players[Table.DealerPosition]);
            nextPlayer.Blind = Blind.Small;
            Table.PlayerBets[nextPlayer.Name] = nextPlayer.Bet = SmallBlind;

            nextPlayer = GetNextPlayer(nextPlayer);
            nextPlayer.Blind = Blind.Big;
            Table.PlayerBets[nextPlayer.Name] = nextPlayer.Bet = BigBlind;
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

                IPlayer player = GetNextActivePlayer(Players.Where(x => x.Blind == Blind.Big).First());

                for (int i = 0; i < Players.Count; ++i)
                {
                    //if(player.IsActive && Players.Where(x => x.IsActive).Count() > 1)
                        while (!takeAction(player)) ;

                    player = GetNextActivePlayer(player);
                }

                notify();

                Table.PlayerBets = Table.PlayerBets.ToDictionary(x => x.Key, x => 0);  
            }
        }

        public override void OnDealFinish()
        {
            foreach (IPlayer player in Players.Where(x => x.IsActive))
            {
                Table.Pot += player.Bet;
                player.Bet = 0;
            }

            ++Table.DealerPosition;

            if (Players.Where(x => x.IsActive).Count() == 1) //everyone except one player folded
                Players.Where(x => x.IsActive).First().Chips += Table.Pot;
            else //there are more active players, so hand ranking tells who win
            {
                EvaluableCards evaluableCards = new CommunityCards(new MyRankingEvaluator());
                IDictionary<IPlayer, int> playerHandRankings = new Dictionary<IPlayer, int>();

                foreach(IPlayer player in Players.Where(x => x.IsActive))
                {
                    foreach (ICard card in Table.CommunityCards)
                        evaluableCards.Add(card);

                    foreach (ICard card in player.HoleCards)
                        Table.CommunityCards.Add(card);

                    evaluableCards.EvaluateRanking();

                    playerHandRankings[player] = evaluableCards.HandRankingValue;
                }

                IPlayer winningPlayer = playerHandRankings.OrderBy(x => x.Value).Last().Key;
                winningPlayer.Chips += Table.Pot;
            }

            Table.Pot = 0;

            foreach (IPlayer player in Players)
                player.IsActive = true;
        }

        /// <summary>
        /// Takes action of given player and if successful returns true.
        /// In case of error/exception returns false.
        /// </summary>
        private bool takeAction(IPlayer player)
        {
            IGameAction gameAction;

            try
            {
                gameAction = player.TakeAction(Table);
            }
            catch (Exception)
            {
                return false;
            }

            if (gameAction == null)
                return false;

            if (gameAction is GameActionBet)
            {
                var gameActionBet = gameAction as GameActionBet;

                Table.PlayerBets[player.Name] = gameActionBet.Bet;
            }

            player = GetNextActivePlayer(player);

            return true;
        }
    }
}
