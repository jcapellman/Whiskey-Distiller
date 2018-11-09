using System.Collections.Generic;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Enums;

namespace WhiskeyDistiller.library.Managers
{
    public class WarehouseManager : BaseManager
    { 
        public void AddWarehouse(int gameId, string name, WarehouseTypes warehouseType)
        {
            var warehouse = new Warehouse
            {
                GameID = gameId,
                Name = name,
                WarehouseType = warehouseType
            };

            IoC.DatabaseManager.Add(warehouse);
        }
        
        public void RenameWarehouse(string newName, Warehouse warehouse)
        {
            warehouse.Name = newName;
            IoC.DatabaseManager.Update(warehouse);
        }

        public List<Warehouse> GetWarehouses(int GameID)
        {
            return IoC.DatabaseManager.Select<Warehouse>(a => a.GameID == GameID);
        }

        public void RemoveWarehouse(Warehouse warehouse)
        {
            IoC.DatabaseManager.Remove(warehouse);
        }
    }
}