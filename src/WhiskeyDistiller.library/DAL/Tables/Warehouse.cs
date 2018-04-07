using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using WhiskeyDistiller.library.Enums;

namespace WhiskeyDistiller.library.DAL.Tables
{
    public class Warehouse : BaseTable
    {
        [Required]
        [ForeignKey("GameID")]
        public Game Game { get; set; }

        public int GameID { get; set; }

        public string Name { get; set; }
        
        public WarehouseTypes WarehouseType { get; set; }
    }
}