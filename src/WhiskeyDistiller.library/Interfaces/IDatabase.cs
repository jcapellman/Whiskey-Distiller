using System;
using System.Collections.Generic;

using WhiskeyDistiller.library.DAL.Tables;

namespace WhiskeyDistiller.library.Interfaces
{
    public interface IDatabase
    {
        bool InitializeDB();

        bool Add<T>(T obj) where T : BaseTable;

        bool CreateTable(Type tableType);

        List<T> Select<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : new();
    }
}