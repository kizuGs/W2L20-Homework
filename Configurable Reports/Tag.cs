using System;
using System.Collections.Generic;
using System.Text;

namespace Reports
{
    public class Tag
    {
        //typ referencyjny
        //Properties 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Unit { get; set; }
        public float EngZero { get; set; }
        public float EngFull { get; set; }

    }
}
