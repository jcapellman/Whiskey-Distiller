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

        public static void Setup()
        {
            var sqliteDatabase = new SQLiteDatabase();

            sqliteDatabase.InitializeDB();

            Kernel.Bind<DBManager>().ToSelf().InSingletonScope().WithConstructorArgument("database", sqliteDatabase);
            Kernel.Bind<GameManager>().ToSelf().InSingletonScope();
            Kernel.Bind<WarehouseManager>().ToSelf().InSingletonScope();
        }
    }
}