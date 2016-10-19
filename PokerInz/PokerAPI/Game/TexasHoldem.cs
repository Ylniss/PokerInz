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
        public TexasHoldem(IList<IPlayer> players, BettingRule bettingRule) : base(players, bettingRule)
        {
        }

        public TexasHoldem(IList<IPlayer> players, BettingRule bettingRule, Deck playingCards) : base(players, bettingRule, playingCards)
        {
        }

        public override void StartDeal()
        {
            PlayingCards.Shuffle();

            handOutCardsToPlayersAndSetBlinds();

            //return players hole cards to deck
            foreach (IPlayer player in Players)
            {
                PlayingCards.Add(player.HoleCards[0]);
                PlayingCards.Add(player.HoleCards[1]);
            }
        }

        private void handOutCardsToPlayersAndSetBlinds()
        {
            foreach (IPlayer player in Players)
            {
                player.Blind = Blind.None;

                player.HoleCards = new List<ICard>() { PlayingCards[0], PlayingCards[1] };
                PlayingCards.Remove(PlayingCards.First());
                PlayingCards.Remove(PlayingCards.First());
            }

            IPlayer nextPlayer = GetNextPlayer(Players[Table.DealerPosition]);
            nextPlayer.Blind = Blind.Small;
            GetNextPlayer(nextPlayer).Blind = Blind.Big;
        }

        private void licitation()
        {

        }

    }
}
