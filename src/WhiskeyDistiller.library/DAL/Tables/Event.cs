namespace WhiskeyDistiller.library.DAL.Tables
{
    public class Event : BaseTable
    {
        public string Date { get; set; }

        public string Description { get; set; }

        public int GameID { get; set; }

        public bool Read { get; set; }
    }
}