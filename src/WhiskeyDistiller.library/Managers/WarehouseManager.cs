using System;
using System.Collections.Generic;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Enums;

namespace WhiskeyDistiller.library.Managers
{
    public class WarehouseManager : BaseManager
    { 
        public ReturnSet<bool> AddWarehouse(int gameId, string name, WarehouseTypes warehouseType)
        {
            var warehouse = new Warehouse
            {
                GameID = gameId,
                Name = name,
                WarehouseType = warehouseType
            };

            return IoC.DatabaseManager.Add(warehouse);
        }
        
        public ReturnSet<bool> RenameWarehouse(string newName, Warehouse warehouse)
        {
            try
            {
                if (warehouse == null)
                {
                    throw new ArgumentNullException(nameof(warehouse));
                }

                warehouse.Name = newName;

                return IoC.DatabaseManager.Update(warehouse);
            }
            catch (Exception ex)
            {
                return new ReturnSet<bool>(ex, "Renaming warehhouse");
            }
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

        public ReturnSet<bool> RemoveWarehouse(Warehouse warehouse) => IoC.DatabaseManager.Remove(warehouse);
    }
}