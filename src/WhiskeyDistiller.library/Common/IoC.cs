using Ninject;

using WhiskeyDistiller.library.Implementations;
using WhiskeyDistiller.library.Managers;

namespace WhiskeyDistiller.library.Common
{
    public static class IoC
    {
        private static IKernel Kernel { get; set; } = new StandardKernel();

        public static DBManager DatabaseManager => Kernel.Get<DBManager>();

        public static GameManager GameManager => Kernel.Get<GameManager>();

        public static WarehouseManager WarehouseManager => Kernel.Get<WarehouseManager>();

        public static EventManager EventManager => Kernel.Get<EventManager>();

        public static void Setup()
        {
            var liteDbDatabase = new LiteDBDatabase();

            liteDbDatabase.InitializeDB();

            Kernel.Bind<DBManager>().ToSelf().InSingletonScope().WithConstructorArgument("database", liteDbDatabase);
            Kernel.Bind<GameManager>().ToSelf().InSingletonScope();
            Kernel.Bind<WarehouseManager>().ToSelf().InSingletonScope();
            Kernel.Bind<EventManager>().ToSelf().InSingletonScope();
        }
    }
}