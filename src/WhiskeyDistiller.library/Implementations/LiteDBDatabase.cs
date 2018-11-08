using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Interfaces;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.Implementations
{
    public class LiteDBDatabase : IDatabase
    {
        private const string FILE_NAME = "game.db";

        private readonly string _dbFileName = Path.Combine(DependencyService.Get<IFileIO>().GamePath, FILE_NAME);

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

        public bool CreateTable(Type tableType)
        {
            throw new NotImplementedException();
        }

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