using System;
using System.Collections.Generic;
using System.Text;

namespace GuitarTabsAndChords.Model.Requests
{
    public class AlbumsSearchRequest
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Decade { get; set; }
        public int ArtistId { get; set; }
        public int? Filter { get; set; }
    }
}
