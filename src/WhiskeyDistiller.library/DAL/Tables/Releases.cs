using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WhiskeyDistiller.library.Enums;

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

        [Required]
        public int YearsAged { get; set; }

        [Required]
        public double Proof { get; set; }

        [Required]
        public WhiskeyTypes Type { get; set; }
    }
}