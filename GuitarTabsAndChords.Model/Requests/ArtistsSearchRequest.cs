using System;
using System.Collections.Generic;
using System.Text;

namespace GuitarTabsAndChords.Model.Requests
{
    public class ArtistsSearchRequest
    {
        public string Name { get; set; }
        public int? Filter { get; set; }
    }
}
