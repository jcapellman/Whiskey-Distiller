using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhiskeyDistiller.library.DAL.Tables
{
    public class Warehouse : BaseTable
    {
        [Required]
        [ForeignKey("GameID")]
        public Game Game { get; set; }

        public int GameID { get; set; }

        public string Name { get; set; }

        public int BarrelCapacity { get; set; }
    }
}