using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.Model
{
    public class Artists
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ReviewStatus Status { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
