using WhiskeyDistiller.library.Implementations;
using WhiskeyDistiller.library.Interfaces;
using WhiskeyDistiller.library.Managers;

namespace WhiskeyDistiller.library.Common
{
    public class IocModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<BaseManager>().ToConstructor(arg => new BaseManager(arg.Inject<SQLiteDatabase>()));
        }
    }
}