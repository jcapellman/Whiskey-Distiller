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

        public bool InitializeDB()
        {
            return true;
        }

        public bool Add<T>(T obj) where T : BaseTable
        {
            using (var db = new LiteDB.LiteDatabase(_dbFileName))
            {
                var collection = db.GetCollection<T>();

                return collection.Insert(obj);
            }
        }

        /// <summary>
        /// For LiteDB this method is not needed to be called
        /// </summary>
        /// <param name="tableType"></param>
        /// <returns></returns>
        public bool CreateTable(Type tableType) => true;

        public List<T> Select<T>(Expression<Func<T, bool>> expression) where T : new()
        {
            using (var db = new LiteDB.LiteDatabase(_dbFileName))
            {
                var collection = db.GetCollection<T>();

                return collection.Find(expression).ToList();
            }
        }

        public void Remove<T>(T obj) where T : BaseTable
        {
            using (var db = new LiteDB.LiteDatabase(_dbFileName))
            {
                if (obj == null)
                {
                    return;
                }

                var collection = db.GetCollection<T>();

                collection.Delete(obj.ID);
            }
        }

        public void Update<T>(T obj) where T : BaseTable
        {
            using (var db = new LiteDB.LiteDatabase(_dbFileName))
            {
                db.GetCollection<T>().Update(obj);
            }
        }
    }
}