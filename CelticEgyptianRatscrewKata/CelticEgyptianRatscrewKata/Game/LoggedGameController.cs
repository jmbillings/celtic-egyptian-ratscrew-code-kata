﻿using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata.Game
{
    public class LoggedGameController : IGameController
    {
        private readonly IGameController _gameController;
        private readonly ILog _log;

        public LoggedGameController(IGameController gameController, ILog log)
        {
            _gameController = gameController;
            _log = log;
        }

        public bool AddPlayer(IPlayer player)
        {
            return _gameController.AddPlayer(player);
        }

        public Card PlayCard(IPlayer player)
        {
            var playedCard = _gameController.PlayCard(player);
            _log.Log(string.Format("{0} has played the {1}", player.Name, playedCard));
            LogGameState();
            return playedCard;
        }

        public bool AttemptSnap(IPlayer player)
        {
            var wasValidSnap = _gameController.AttemptSnap(player);

            var snapLogMessage = wasValidSnap ? "won the stack" : "did not win the stack";
            _log.Log(string.Format("{0} {1}", player.Name, snapLogMessage));
            LogGameState();
            return wasValidSnap;
        }

        public void StartGame(Cards deck)
        {
            _gameController.StartGame(deck);
            LogGameState();
        }

        public bool TryGetWinner(out IPlayer winner)
        {
            var hasWinner = _gameController.TryGetWinner(out winner);
            if (hasWinner)
            {
                _log.Log(string.Format("{0} won the game!", winner.Name));
            }
            return hasWinner;
        }

        public IEnumerable<IPlayer> Players
        {
            get { return _gameController.Players; }
        }

        public int StackSize
        {
            get { return _gameController.StackSize; }
        }

        public Card TopOfStack
        {
            get { return _gameController.TopOfStack; }
        }

        public int NumberOfCards(IPlayer player)
        {
            return _gameController.NumberOfCards(player);
        }

        public bool IsPenalised(IPlayer player)
        {
            return _gameController.IsPenalised(player);
        }

        private void LogGameState()
        {
            _log.Log(string.Format("Stack ({0}): {1} ", _gameController.StackSize, _gameController.StackSize > 0 ? _gameController.TopOfStack.ToString() : ""));
            foreach (var player in _gameController.Players)
            {
                _log.Log(string.Format("{0}: {1} cards{2}", 
                    player.Name, 
                    _gameController.NumberOfCards(player), 
                    _gameController.IsPenalised(player) ? " (PENALISED)" : ""));
            }
        }
    }
}