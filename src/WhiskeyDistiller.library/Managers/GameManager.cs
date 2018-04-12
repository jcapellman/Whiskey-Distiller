using System;
using System.Linq;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;

namespace WhiskeyDistiller.library.Managers
{
    public class GameManager : BaseManager
    {
        private const double NEWGAME_INITIAL_CASH = 100;
        private int NEWGAME_INITIAL_GAMEYEAR = DateTime.Now.Year;
        private const int NEWGAME_INITAL_GAMEQUARTER = 1;

        private Game _currentGame;

        public Game CurrentGame
        {
            get { return _currentGame; }
            set { _currentGame = value; }
        }
        
        public bool CreateNewGame(string distilleryName, string playerName)
        {
            var game = new Game
            {
                DistilleryName = distilleryName,
                PlayerName = playerName,
                Cash = NEWGAME_INITIAL_CASH,
                GameYear = NEWGAME_INITIAL_GAMEYEAR,
                GameQuarter = NEWGAME_INITAL_GAMEQUARTER
            };

            IoC.DatabaseManager.Add(game);

            CurrentGame = game;

            return true;
        }
        
        private void IncrementTime()
        {
            if (CurrentGame.GameQuarter == 4)
            {
                CurrentGame.GameQuarter = 1;
                CurrentGame.GameYear++;

                return;
            }

            CurrentGame.GameQuarter++;
        }

        public List<Game> GetSavedGames() => IoC.DatabaseManager.Select<Game>(a => a.Active).OrderByDescending(a => a.GameYear).ThenByDescending(a => a.GameQuarter).ToList();
        
        private void ProcessCosts()
        {
            var warehouses = IoC.DatabaseManager.Select<Warehouse>(a => a.GameID == CurrentGame.ID).Select(a => a.ID).ToList();

            var numberBarrels = IoC.DatabaseManager.Select<Batch>(a => warehouses.Contains(a.WarehouseID)).Sum(a => a.NumberOfBarrels);

            var totalCost = numberBarrels * Constants.COST_PER_BARREL;

            CurrentGame.Cash -= totalCost;
        }

        public bool ComputeTurn()
        {
            IncrementTime();

            ProcessCosts();
            
            return true;
        }
    }
}