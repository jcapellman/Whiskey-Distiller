using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Interfaces;

namespace WhiskeyDistiller.library.Implementations
{
    public class LiteDBDatabase : IDatabase
    {
        private const string DB_FILE_NAME = "game.db";

        public bool InitializeDB()
        {
            return true;
        }

        public bool Add<T>(T obj) where T : BaseTable
        {
            using (var db = new LiteDB.LiteDatabase(DB_FILE_NAME))
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
            using (var db = new LiteDB.LiteDatabase(DB_FILE_NAME))
            {
                var collection = db.GetCollection<T>();

                return collection.Find(expression).ToList();
            }
        }

        public void Remove<T>(T obj) where T : BaseTable
        {
            using (var db = new LiteDB.LiteDatabase(DB_FILE_NAME))
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
            using (var db = new LiteDB.LiteDatabase(DB_FILE_NAME))
            {
                db.GetCollection<T>().Update(obj);
            }
        }
    }
}