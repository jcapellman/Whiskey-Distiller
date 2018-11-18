using System;
using System.Collections.Generic;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Interfaces;

namespace WhiskeyDistiller.library.Managers
{
    public class DbManager : BaseManager
    {
        private readonly IDatabase _database;

        public DbManager(IDatabase database) { _database = database; }

        public void Add<T>(T obj) where T : BaseTable
        {
            obj.Modified = DateTime.Now;
            obj.Created = DateTime.Now;
            
            _database.Add(obj);
        }

        public List<T> Select<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : new() => _database.Select(expression);

        public void Remove<T>(T obj) where T: BaseTable
        {
            _database.Remove(obj);
        }

        public ReturnSet<bool> Update(Warehouse warehouse)
        {
            try
            {
                if (warehouse == null)
                {
                    throw new ArgumentNullException(nameof(warehouse));
                }

                warehouse.Modified = DateTime.Now;

                _database.Update(warehouse);

                return new ReturnSet<bool>(true);
            }
            catch (Exception ex)
            {
                return new ReturnSet<bool>(ex, "Warehouse exception");
            }
        }
    }
}