using System;
using System.Linq;
using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Enums;

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

        public bool CreateNewGame(string distilleryName)
        {
            var game = new Game
            {
                DistilleryName = distilleryName,
                Cash = NEWGAME_INITIAL_CASH,
                GameYear = NEWGAME_INITIAL_GAMEYEAR,
                GameQuarter = NEWGAME_INITAL_GAMEQUARTER
            };

            IoC.DatabaseManager.Add(game);

            CurrentGame = game;

            return true;
        }

        public void AddNewWarehouse(string name, WarehouseTypes warehouseType)
        {
            var warehouse = new Warehouse
            {
                WarehouseType = warehouseType,
                Name = name,
                Game = CurrentGame
            };

            IoC.DatabaseManager.Add(warehouse);
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

        private void ProcessCosts()
        {
            var batches = IoC.DatabaseManager.Select<Batch>(a => a.Warehouse.GameID == CurrentGame.ID).ToList();

            var barrels = batches.Sum(a => a.NumberOfBarrels);

            var totalCost = barrels * Constants.COST_PER_BARREL;

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