using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Interfaces;

namespace WhiskeyDistiller.library.Managers
{
    public class DBManager : BaseManager
    {
        private IDatabase _database;

        public DBManager(IDatabase database) { _database = database; }

        public void Add<T>(T obj) where T : BaseTable
        {
            _database.Add(obj);
        }
    }
}