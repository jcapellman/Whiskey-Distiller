﻿using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.Enums;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class WarehousePageVM : BaseVM
    {
        public WarehousePageVM(INavigation navigation) : base(navigation)
        {
        }

        private string _gameName;

        public string GameName
        {
            get => _gameName;
            set { _gameName = value; OnPropertyChanged(nameof(GameName)); }
        }

        private WarehouseTypes _warehouseType;

        public WarehouseTypes WarehouseType
        {
            get => _warehouseType;
            set { _warehouseType = value; OnPropertyChanged(nameof(WarehouseType)); }
        }

        public void AddWarehouse()
        {
            IoC.WarehouseManager.AddWarehouse(IoC.GameManager.CurrentGame.ID, GameName, WarehouseType);
        }
    }
}