using System;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;

namespace WhiskeyDistiller.library.Managers
{
    public class GameManager : BaseManager
    {
        private const double NEWGAME_INITIAL_CASH = 100;
        private int NEWGAME_INITIAL_GAMEYEAR = DateTime.Now.Year;
        private const int NEWGAME_INITAL_GAMEQUARTER = 1;

        public Game CreateNewGame(string distilleryName)
        {
            var game = new Game
            {
                DistilleryName = distilleryName,
                Cash = NEWGAME_INITIAL_CASH,
                GameYear = NEWGAME_INITIAL_GAMEYEAR,
                GameQuarter = NEWGAME_INITAL_GAMEQUARTER
            };

            IoC.DatabaseManager.Add(game);

            return game;
        }
    }
}