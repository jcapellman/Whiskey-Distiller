using System.ComponentModel.DataAnnotations;

using WhiskeyDistiller.library.Enums;

namespace WhiskeyDistiller.library.DAL.Tables
{
    public class Batch : BaseTable
    {
        [Required]
        public int WarehouseId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public int NumberOfBarrels { get; set; }

        [Required]
        public int MonthsAged { get; set; }

        [Required]
        public double Proof { get; set; }

        [Required]
        public WhiskeyTypes Type { get; set; }

        [Required]
        public int Quality { get; set; }
    }
}