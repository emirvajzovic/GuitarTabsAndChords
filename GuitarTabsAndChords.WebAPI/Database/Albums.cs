using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Database
{
    public class Albums
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] AlbumCover { get; set; }
        public int Year { get; set; }

        public int ArtistId { get; set; }
        public Artists Artist { get; set; }

        public ICollection<Songs> Songs { get; set; }
        public List<Genres> Genres
        {
            get
            {
                var temp = new List<Genres>();
                foreach (var song in Songs)
                {
                    bool add = true;
                    foreach (var genre in temp)
                    {
                        if (genre.Id == song.GenreId)
                            add = false;

                    }
                    if(add)
                    temp.Add(song.Genre);
                }
                return temp;
            }
        }

        public bool Approved { get; set; }

    }

}
