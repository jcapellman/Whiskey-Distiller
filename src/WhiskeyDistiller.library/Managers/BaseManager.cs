using WhiskeyDistiller.library.Implementations;

namespace WhiskeyDistiller.library.Managers
{
    public class BaseManager
    {
        private SQLiteDatabase _database;

        public BaseManager(SQLiteDatabase database)
        {
            _database = database;
        }
    }
}