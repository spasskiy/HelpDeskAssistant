using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskAssistant
{
    internal class Example
    {
        public string ANumber { get; set; }
        public string BNumber { get; set; }
        public string Time { get; set; }

        public Example(string aNumber, string bNumber, string time)
        {
            ANumber = aNumber;
            BNumber = bNumber;
            Time = time;
        }
    }
}
