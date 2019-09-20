using GuitarTabsAndChords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Database
{
    public class Tunings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ReviewStatus Status { get; set; }
    }
}
