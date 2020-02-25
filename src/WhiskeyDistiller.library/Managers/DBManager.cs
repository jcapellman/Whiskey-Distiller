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

        public ReturnSet<bool> Add<T>(T obj) where T : BaseTable
        {
            try
            {
                if (obj == null)
                {
                    throw new ArgumentNullException(nameof(obj));
                }

                obj.Modified = DateTime.Now;
                obj.Created = DateTime.Now;

                return _database.Add(obj);
            }
            catch (Exception ex)
            {
                return new ReturnSet<bool>(ex, "Attempting to add Object");
            }
        }

        public ReturnSet<List<T>> Select<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : new() => _database.Select(expression);

        public ReturnSet<bool> Remove<T>(T obj) where T : BaseTable
        {
            try
            {
                if (obj == null)
                {
                    throw new ArgumentNullException(nameof(obj));
                }

                _database.Remove(obj);

                return new ReturnSet<bool>(true);
            }
            catch (Exception ex)
            {
                return new ReturnSet<bool>(ex, "Failed to remove object");
            }
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