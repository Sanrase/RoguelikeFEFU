using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeFEFU
{
    internal class Record
    {
        public int Level { get; set; }
        public int CountKills { get; set; }
        public string Name { get; set; }

        public Record()
        {
            Name = "Ace";
            Level = 1;
            CountKills = 0;
        }



    }
}
