using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace InlamningsApp
{
    public class Delay
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double TimeDelay { get; set; }
        //public string TextMsg { get; set; }
    }
}
