using System;
using System.Collections.Generic;
using System.Text;

namespace GuitarTabsAndChords.Model.Requests
{
    public class NotationsSearchRequest
    {
        public string SearchTerm { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int SongId { get; set; }
        public int? Filter { get; set; }
        public string Tuning { get; set; }
    }
}
