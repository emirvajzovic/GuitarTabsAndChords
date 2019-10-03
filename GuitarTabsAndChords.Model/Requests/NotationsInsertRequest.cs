using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GuitarTabsAndChords.Model.Requests
{
    public class NotationsInsertRequest
    {
        [Required]
        public string NotationContent { get; set; }
        [Required]
        public NotationType Type { get; set; }
        [Required]
        public int SongId { get; set; }
        [Required]
        public string Tuning { get; set; }
        [Required]
        public string TuningDescription { get; set; }
        [Required]
        public ReviewStatus Status { get; set; }
    }
}
