using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GuitarTabsAndChords.Model.Requests
{
    public class AlbumsInsertRequest
    {
        [Required]
        public string Name { get; set; }
        public byte[] AlbumCover { get; set; }
        [Required]
        public int Year { get; set; }

        [Required]
        public int ArtistId { get; set; }

        public Model.ReviewStatus Status { get; set; }
    }
}
