using System.Collections.Generic;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Enums;

namespace WhiskeyDistiller.library.Managers
{
    public class WarehouseManager : BaseManager
    { 
        public void AddWarehouse(int GameID, string name, WarehouseTypes warehouseType)
        {
            var warehouse = new Warehouse
            {
                GameID = GameID,
                Name = name,
                WarehouseType = warehouseType
            };

            IoC.DatabaseManager.Add(warehouse);
        }
        
        public List<Warehouse> GetWarehouses(int GameID)
        {
            return IoC.DatabaseManager.Select<Warehouse>(a => a.GameID == GameID && a.Active);
        }

        public void RemoveWarehouse(Warehouse warehouse)
        {
            IoC.DatabaseManager.Remove(warehouse);
        }
    }
}