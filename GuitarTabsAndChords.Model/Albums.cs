using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.Model
{
    public class Albums
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] AlbumCover { get; set; }
        public int Year { get; set; }

        public int ArtistId { get; set; }
        public Artists Artist { get; set; }
        
        public List<Genres> Genres  { get; set; }

        public ReviewStatus Status { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public string GenresStr { get => string.Join(", ", Genres.Select(x=>x.Name).ToArray()); }

    }

}
