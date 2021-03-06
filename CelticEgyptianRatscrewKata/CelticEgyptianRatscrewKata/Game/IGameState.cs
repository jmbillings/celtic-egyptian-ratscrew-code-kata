﻿using System;

namespace CelticEgyptianRatscrewKata.Game
{
    public interface IGameState
    {
        /// <summary>
        /// Gets a copy of the current stack of cards.
        /// </summary>
        Cards Stack { get; }

        /// <summary>
        /// Add the given player to the game with the given deck.
        /// </summary>
        /// <exception cref="ArgumentException">If the given player already exists</exception>
        void AddPlayer(string playerId, Cards deck);

        /// <summary>
        /// Play the top card of the given player's deck.
        /// </summary>
        Card PlayCard(string playerId);

        /// <summary>
        /// Wins the stack for the given player.
        /// </summary>
        void WinStack(string playerId);

        /// <summary>
        /// Returns true if the given player has any cards in their hand.
        /// </summary>
        bool HasCards(string playerId);

        /// <summary>
        /// Resets the game state back to its default values.
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns the number of cards the given player has in their hand
        /// </summary>
        int NumberOfCards(string playerId);

        /// <summary>
        /// Applies the snap penalty to the given player
        /// </summary>
        void PenalisePlayer(string playerId);

        /// <summary>
        /// Returns whether or not the given player has the snap penalty applied
        /// </summary>
        bool IsPlayerPenalised(string playerId);

        /// <summary>
        /// Resets the snap penalty from all players
        /// </summary>
        void ResetPenalties();

        /// <summary>
        /// Returns whether or not all players have a penalised state
        /// </summary>
        bool AreAllPlayersPenalised();
    }
}