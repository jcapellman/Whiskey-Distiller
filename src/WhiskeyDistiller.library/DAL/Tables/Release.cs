using System.ComponentModel.DataAnnotations;

namespace WhiskeyDistiller.library.DAL.Tables
{
    public class Release : BaseTable
    {
        [Required]
        public int GameID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Inventory { get; set; }

        [Required]
        public int Revenue { get; set; }

        [Required]
        public int BatchID { get; set; }
    }
}