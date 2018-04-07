﻿using System;
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
                GameID = CurrentGame.ID
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