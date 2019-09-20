using System;
using System.Collections.Generic;
using System.Text;

namespace GuitarTabsAndChords.Model.Requests
{
    public class SongsSearchRequest
    {
        public string SearchTerm { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int Year { get; set; }
        public int? Filter { get; set; }
    }
}
