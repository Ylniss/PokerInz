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
        }

        private void handOutCardsToPlayersAndSetBlinds()
        {
            foreach (IPlayer player in Players)
            {
                player.Blind = Blind.None;

                player.HoleCards = new Tuple<ICard, ICard>(PlayingCards[0], PlayingCards[1]);
                PlayingCards.Remove(PlayingCards[0]);
                PlayingCards.Remove(PlayingCards[1]);
            }

            Players[0].Blind = Blind.Small;
            Players[1].Blind = Blind.Big;
        }
    }
}
