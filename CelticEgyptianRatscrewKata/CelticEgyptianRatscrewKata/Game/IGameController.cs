using System;
using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata.Game
{
    public interface IGameController
    {
        bool AddPlayer(IPlayer player);
        PlayedCardAndCallout PlayCard(IPlayer player);
        bool AttemptSnap(IPlayer player);

        /// <summary>
        /// Starts a game with the currently added players
        /// </summary>
        void StartGame(Cards deck);

        bool TryGetWinner(out IPlayer winner);
        IEnumerable<IPlayer> Players { get; }
        int StackSize { get; }
        Card TopOfStack { get; }
        int NumberOfCards(IPlayer player);
    }

    public class PlayedCardAndCallout
    {
        public readonly Card Card;
        public readonly Rank Callout;

        public PlayedCardAndCallout(Card card, Rank callout)
        {
            Card = card;
            Callout = callout;
        }
    }
}