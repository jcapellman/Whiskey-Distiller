using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using SQLite;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Interfaces;

namespace WhiskeyDistiller.library.Implementations
{
    public class SQLiteDatabase : IDatabase
    {
        public bool Add<T>(T obj) where T : BaseTable
        {
            using (var sqlConnection = new SQLiteConnection(Constants.DB_FILENAME))
            {
                sqlConnection.Insert(obj);

                return true;
            }
        }

        public void Update<T>(T obj) where T : BaseTable
        {
            using(var sqlConnection = new SQLiteConnection(Constants.DB_FILENAME))
            {
                sqlConnection.Update(obj);
            }
        }

        public bool CreateTable(Type tableType)
        {
            using (var sqlConnection = new SQLiteConnection(Constants.DB_FILENAME))
            {
                sqlConnection.CreateTable(tableType);

                return true;
            }
        }

        public bool InitializeDB()
        {
            var tables = Assembly.GetAssembly(typeof(IDatabase)).GetTypes().Where(a => a.BaseType == typeof(BaseTable)).ToList();

            // No Tables found
            if (!tables.Any())
            {
                return true;
            }

            foreach (var table in tables)
            {
                CreateTable(table);
            }

            return true;
        }

        public void Remove<T>(T objectToDelete) where T : BaseTable
        {
            using (var sqlConnection = new SQLiteConnection(Constants.DB_FILENAME))
            {
                objectToDelete.Active = false;
                objectToDelete.Modified = DateTime.Now;

                sqlConnection.Update(objectToDelete);
            }
        }

        public List<T> Select<T>(Expression<Func<T, bool>> expression) where T : new()
        {
            using (var sqlConnection = new SQLiteConnection(Constants.DB_FILENAME))
            {
                return sqlConnection.Table<T>().Where(expression).ToList();
            }
        }
    }
}