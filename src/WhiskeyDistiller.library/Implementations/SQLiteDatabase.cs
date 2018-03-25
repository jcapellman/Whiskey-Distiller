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
    }
}