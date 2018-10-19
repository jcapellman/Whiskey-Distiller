using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Interfaces;

namespace WhiskeyDistiller.library.Implementations
{
    public class LiteDBDatabase : IDatabase
    {
        public bool InitializeDB()
        {
            throw new NotImplementedException();
        }

        public bool Add<T>(T obj) where T : BaseTable
        {
            throw new NotImplementedException();
        }

        public bool CreateTable(Type tableType)
        {
            throw new NotImplementedException();
        }

        public List<T> Select<T>(Expression<Func<T, bool>> expression) where T : new()
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(T obj) where T : BaseTable
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T obj) where T : BaseTable
        {
            throw new NotImplementedException();
        }
    }
}