using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Interfaces;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.Implementations
{
    public class LiteDbDatabase : IDatabase
    {
        private readonly string _dbFileName = Path.Combine(DependencyService.Get<IFileIO>().GamePath, Constants.DB_FILENAME);

        public ReturnSet<bool> InitializeDB()
        {
            return new ReturnSet<bool>(true);
        }

        public ReturnSet<bool> Add<T>(T obj) where T : BaseTable
        {
            using (var db = new LiteDB.LiteDatabase(_dbFileName))
            {
                var collection = db.GetCollection<T>();

                return new ReturnSet<bool>(collection.Insert(obj));
            }
        }

        /// <summary>
        /// For LiteDB this method is not needed to be called
        /// </summary>
        /// <param name="tableType"></param>
        /// <returns></returns>
        public ReturnSet<bool> CreateTable(Type tableType) => new ReturnSet<bool>(true);

        public ReturnSet<List<T>> Select<T>(Expression<Func<T, bool>> expression) where T : new()
        {
            using (var db = new LiteDB.LiteDatabase(_dbFileName))
            {
                var collection = db.GetCollection<T>();

                return new ReturnSet<List<T>>(collection.Find(expression).ToList());
            }
        }

        public ReturnSet<bool> Remove<T>(T obj) where T : BaseTable
        {
            using (var db = new LiteDB.LiteDatabase(_dbFileName))
            {
                if (obj == null)
                {
                    return new ReturnSet<bool>(false);
                }

                var collection = db.GetCollection<T>();

                return new ReturnSet<bool>(collection.Delete(obj.Id));
            }
        }

        public ReturnSet<bool> Update<T>(T obj) where T : BaseTable
        {
            using (var db = new LiteDB.LiteDatabase(_dbFileName))
            {
                return new ReturnSet<bool>(db.GetCollection<T>().Update(obj));
            }
        }
    }
}