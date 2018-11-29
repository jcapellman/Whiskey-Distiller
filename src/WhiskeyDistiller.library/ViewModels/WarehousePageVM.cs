using System;
using System.Collections.Generic;
using System.Linq;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.Enums;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class WarehousePageVm : BaseVm
    {
        public WarehousePageVm(INavigation navigation) : base(navigation)
        {
            WarehouseTypes = Enum.GetNames(typeof(WarehouseTypes)).OrderBy(a => a).ToList();

            SelectedWarehouseType = WarehouseTypes.FirstOrDefault();
        }

        private string _warehouseName;

        public string WarehouseName
        {
            get => _warehouseName;
            set {
                _warehouseName = value;
                OnPropertyChanged(nameof(WarehouseName));
                validateForm();
            }
        }

        private List<string> _warehouseTypes;

        public List<string> WarehouseTypes
        {
            get => _warehouseTypes;
            set
            {
                _warehouseTypes = value;

                OnPropertyChanged(nameof(WarehouseTypes));
            }
        }

        private string _selectedWarehouseType;

        public string SelectedWarehouseType
        {
            get => _selectedWarehouseType;
            set
            {
                _selectedWarehouseType = value;

                OnPropertyChanged(nameof(SelectedWarehouseType));

                validateForm();
            }
        }

        private double _warehouseCost;

        public double WarehouseCost
        {
            get => _warehouseCost;
            set { _warehouseCost = value; OnPropertyChanged(nameof(WarehouseCost)); }
        }

        private void validateForm()
        {
            EnableAddButton = (!string.IsNullOrEmpty(WarehouseName) &&
             WarehouseCost < IoC.GameManager.CurrentGame.Cash);
        }

        private bool _enableAddButton;

        public bool EnableAddButton
        {
            get => _enableAddButton;
            set { _enableAddButton = value; OnPropertyChanged(nameof(EnableAddButton)); }
        }

        public void AddWarehouse()
        {
            IoC.WarehouseManager.AddWarehouse(IoC.GameManager.CurrentGame.Id, WarehouseName, (WarehouseTypes)Enum.Parse(typeof(WarehouseTypes), SelectedWarehouseType));
        }
    }
}