using System;

namespace WhiskeyDistiller.library.DAL.Tables
{
    public class BaseTable
    {
        public int Id { get; set; }
        
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}