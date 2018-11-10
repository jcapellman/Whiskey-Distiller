using System;
using System.Collections.Generic;
using System.Linq;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;

namespace WhiskeyDistiller.library.Managers
{
    public class GameManager : BaseManager
    {
        private const double NewgameInitialCash = 100;
        private readonly int _newgameInitialGameyear = DateTime.Now.Year;
        private const int NewgameInitalGamequarter = 1;

        public Game CurrentGame { get; set; }

        public bool CreateNewGame(string distilleryName, string playerName)
        {
            var game = new Game
            {
                DistilleryName = distilleryName,
                PlayerName = playerName,
                Cash = NewgameInitialCash,
                GameYear = _newgameInitialGameyear,
                GameQuarter = NewgameInitalGamequarter
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

        public List<Game> GetSavedGames() => 
            IoC.DatabaseManager.Select<Game>(a => a != null).OrderByDescending(a => a.GameYear).ThenByDescending(a => a.GameQuarter).ToList();

        internal void SaveNewGame(string newSaveGameName)
        {
            throw new NotImplementedException();
        }

        internal void OverwriteSameGame(Game selectedGame)
        {
            throw new NotImplementedException();
        }

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