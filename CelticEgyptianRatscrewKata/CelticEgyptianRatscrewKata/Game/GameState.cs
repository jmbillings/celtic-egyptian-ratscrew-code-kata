using System;
using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.SnapRules;
using CelticEgyptianRatscrewKata.Tests;

namespace CelticEgyptianRatscrewKata.Game
{
    /// <summary>
    /// Represents the state of the game at any point.
    /// </summary>
    public class GameState : IGameState, ISnapRuleData
    {
        private readonly Cards _stack;
        private readonly IDictionary<string, Cards> _decks;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameState()
            : this(Cards.Empty(), new Dictionary<string, Cards>()) {}

        /// <summary>
        /// Constructor to allow setting the central stack.
        /// </summary>
        public GameState(Cards stack, IDictionary<string, Cards> decks)
        {
            _stack = stack;
            _decks = decks;
        }


        public Cards Stack { get {return new Cards(_stack);} }

        public Card CurrentCallout
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Add the given player to the game with the given deck.
        /// </summary>
        /// <exception cref="ArgumentException">If the given player already exists</exception>
        public void AddPlayer(string playerId, Cards deck)
        {
            if (_decks.ContainsKey(playerId)) throw new ArgumentException("Can't add the same player twice");
            _decks.Add(playerId, deck);
        }

        /// <summary>
        /// Play the top card of the given player's deck.
        /// </summary>
        public Card PlayCard(string playerId)
        {
            if (!_decks.ContainsKey(playerId)) throw new ArgumentException("The selected player doesn't exist");
            if (!_decks[playerId].Any()) throw new ArgumentException("The selected player doesn't have any cards left");

            var topCard = _decks[playerId].Pop();
            _stack.AddToTop(topCard);
            return topCard;
        }

        /// <summary>
        /// Wins the stack for the given player.
        /// </summary>
        public void WinStack(string playerId)
        {
            if (!_decks.ContainsKey(playerId)) throw new ArgumentException("The selected player doesn't exist");

            foreach (var card in _stack.Reverse())
            {
                _decks[playerId].AddToBottom(card);
            }

            ClearStack();
        }

        private void ClearStack()
        {
            while (_stack.HasCards)
            {
                _stack.RemoveCardAt(0);
            }
        }

        public bool HasCards(string playerId)
        {
            if (!_decks.ContainsKey(playerId)) throw new ArgumentException("The selected player doesn't exist");
            return _decks[playerId].Any();
        }

        public int NumberOfCards(string playerId)
        {
            if (!_decks.ContainsKey(playerId)) throw new ArgumentException("The selected player doesn't exist");
            return _decks[playerId].Count();
        }

        public ISnapRuleData GetSnapRuleData()
        {
            return this;
        }

        Rank IGameState.CurrentCallout { get; set; }

        public void Clear()
        {
            ClearStack();
            _decks.Clear();
        }
    }
}
