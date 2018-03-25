using WhiskeyDistiller.library.DAL.Tables;

namespace WhiskeyDistiller.library.Interfaces
{
    public interface IDatabase
    {
        bool Add<T>(T obj) where T : BaseTable;
    }
}