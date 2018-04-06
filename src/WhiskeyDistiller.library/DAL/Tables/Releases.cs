using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhiskeyDistiller.library.DAL.Tables
{
    public class Releases : BaseTable
    {
        [Required]
        [ForeignKey("GameID")]
        public Game Game { get; set; }

        public int GameID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Inventory { get; set; }

        [Required]
        public int Revenue { get; set; }
    }
}