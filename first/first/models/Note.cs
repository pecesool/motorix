using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace first.models
{
    public class Note
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Pal { get; set; }

        public string Ruka { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}
