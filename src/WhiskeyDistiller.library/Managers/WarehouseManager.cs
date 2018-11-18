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

        public List<Warehouse> GetWarehouses(int gameId)
        {
            var result = IoC.DatabaseManager.Select<Warehouse>(a => a.GameID == gameId);

            if (result.HasError)
            {
                throw result.Error;
            }

            return result.Object;
        }

        public void RemoveWarehouse(Warehouse warehouse)
        {
            IoC.DatabaseManager.Remove(warehouse);
        }
    }
}