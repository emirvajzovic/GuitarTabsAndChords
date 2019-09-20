using GuitarTabsAndChords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Database
{
    public class Songs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int AlbumId { get; set; }
        public Albums Album { get; set; }
        public int ArtistId { get; set; }
        public Artists Artist { get; set; }
        public int GenreId { get; set; }
        public Genres Genre { get; set; }
        public ReviewStatus Status { get; set; }
    }
}
