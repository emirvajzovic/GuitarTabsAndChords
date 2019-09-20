using GuitarTabsAndChords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Database
{
    public class Genres
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ReviewStatus Status { get; set; }
    }
}
