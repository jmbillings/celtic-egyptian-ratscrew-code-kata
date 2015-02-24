using System.Collections.Generic;
using CelticEgyptianRatscrewKata;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class RatscrewGame
    {
        private readonly IUserInterface m_UserInterface;

        public RatscrewGame(IUserInterface userInterface)
        {
            m_UserInterface = userInterface;
        }

        public void Play(ILog log)
        {
            var game = new GameFactory().Create(log);
            var actionManager = new ActionManager(game);

            SetUp(game, actionManager);
            StartGame(game, actionManager);
        }

        private void SetUp(IGameController game, ActionManager actionManager)
        {
            IEnumerable<PlayerInfo> playerInfos = m_UserInterface.GetPlayerInfoFromUser();

            foreach (PlayerInfo playerInfo in playerInfos)
            {
                game.AddPlayer(playerInfo);
                actionManager.Bind(playerInfo);
            }
        }

        private void StartGame(IGameController game, ActionManager actionManager)
        {
            game.StartGame(GameFactory.CreateFullDeckOfCards());

            char userInput;
            while (m_UserInterface.TryReadUserInput(out userInput))
            {
                actionManager.Process(userInput);

                if (HasWinner(game)) break;
            }
        }

        private static bool HasWinner(IGameController game)
        {
            IPlayer winner;
            return game.TryGetWinner(out winner);
        }
    }
}