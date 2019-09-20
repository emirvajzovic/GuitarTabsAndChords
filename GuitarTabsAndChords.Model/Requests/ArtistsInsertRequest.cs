using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GuitarTabsAndChords.Model.Requests
{
    public class ArtistsInsertRequest
    {
        [Required]
        public string Name { get; set; }
        public Model.ReviewStatus Status { get; set; }
    }
}
