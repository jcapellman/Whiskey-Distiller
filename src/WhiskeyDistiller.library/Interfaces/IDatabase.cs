using System;

using WhiskeyDistiller.library.DAL.Tables;

namespace WhiskeyDistiller.library.Interfaces
{
    public interface IDatabase
    {
        bool InitializeDB();

        bool Add<T>(T obj) where T : BaseTable;

        bool CreateTable(Type tableType);
    }
}