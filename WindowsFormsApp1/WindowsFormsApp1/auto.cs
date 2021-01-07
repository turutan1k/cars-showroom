using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    class auto
    {
        
        public string name { get; set; }
        public string mark { get; set; }
        public int year { get; set; }
        public string model { get; set; }
        public string vin { get; set; }
        public string colour { get; set; }
        public string nomer { get; set; }
        [NonSerialized]
        public DateTime Creation;

    }
}
