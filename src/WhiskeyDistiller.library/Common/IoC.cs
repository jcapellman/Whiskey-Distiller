using Ninject;

using WhiskeyDistiller.library.Implementations;
using WhiskeyDistiller.library.Managers;

namespace WhiskeyDistiller.library.Common
{
    public static class IoC
    {
        private static IKernel Kernel { get; } = new StandardKernel();

        public static DbManager DatabaseManager => Kernel.Get<DbManager>();

        public static GameManager GameManager => Kernel.Get<GameManager>();

        public static WarehouseManager WarehouseManager => Kernel.Get<WarehouseManager>();

        public static EventManager EventManager => Kernel.Get<EventManager>();

        public static void Setup()
        {
            var liteDbDatabase = new LiteDbDatabase();

            liteDbDatabase.InitializeDB();

            Kernel.Bind<DbManager>().ToSelf().InSingletonScope().WithConstructorArgument("database", liteDbDatabase);
            Kernel.Bind<GameManager>().ToSelf().InSingletonScope();
            Kernel.Bind<WarehouseManager>().ToSelf().InSingletonScope();
            Kernel.Bind<EventManager>().ToSelf().InSingletonScope();
        }
    }
}