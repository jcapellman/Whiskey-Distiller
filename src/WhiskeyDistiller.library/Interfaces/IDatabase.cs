using System;
using System.Collections.Generic;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;

namespace WhiskeyDistiller.library.Interfaces
{
    public interface IDatabase
    {
        ReturnSet<bool> InitializeDB();

        ReturnSet<bool> Add<T>(T obj) where T : BaseTable;

        ReturnSet<bool> CreateTable(Type tableType);

        ReturnSet<List<T>> Select<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : new();

        ReturnSet<bool> Remove<T>(T obj) where T : BaseTable;

        ReturnSet<bool> Update<T>(T obj) where T : BaseTable;
    }
}