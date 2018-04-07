using System.ComponentModel.DataAnnotations;

using WhiskeyDistiller.library.Enums;

namespace WhiskeyDistiller.library.DAL.Tables
{
    public class Warehouse : BaseTable
    {
        [Required]
        public int GameID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public WarehouseTypes WarehouseType { get; set; }
    }
}