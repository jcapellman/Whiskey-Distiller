using System.ComponentModel.DataAnnotations;

namespace WhiskeyDistiller.library.DAL.Tables
{
    public class Game : BaseTable
    {
        [Required]
        public string DistilleryName { get; set; }

        [Required]
        public string PlayerName { get; set; }

        [Required]
        public int GameYear { get; set; }

        [Required]
        public int GameQuarter { get; set; }

        [Required]
        public double Cash { get; set; }
    }
}