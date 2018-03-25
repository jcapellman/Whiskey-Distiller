﻿using SQLite;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Implementations;

namespace WhiskeyDistiller.library.Managers
{
    public class DBManager : BaseManager
    {
        public DBManager(SQLiteDatabase database) : base(database) { }

        public bool Add<T>(T obj) where T : BaseTable
        {
            using (var sqlConnection = new SQLiteConnection(Constants.DB_FILENAME))
            {
                sqlConnection.Insert(obj);
                
                return true;
            }
        }
    }
}