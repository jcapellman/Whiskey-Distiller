using System;

namespace WhiskeyDistiller.library.DAL.Tables
{
    public class BaseTable
    {
        public int ID { get; set; }
        
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}