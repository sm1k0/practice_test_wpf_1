using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_test_wpf_1
{
    public class DaySelect
    {
        // это model
        public string date { get; set; }
        public List<Punct> puncts { get; set; }

        public DaySelect(string date, List<Punct> puncts)
        {
            this.date = date;
            this.puncts = puncts;
        }
    }
}
