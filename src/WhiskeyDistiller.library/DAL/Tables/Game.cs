namespace WhiskeyDistiller.library.DAL.Tables
{
    public class Game : BaseTable
    {
        public string DistilleryName { get; set; }

        public int GameYear { get; set; }

        public int GameQuarter { get; set; }

        public double Cash { get; set; }
    }
}