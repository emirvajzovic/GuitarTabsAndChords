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
        public int TuningId { get; set; }
        [Required]
        public ReviewStatus Status { get; set; }
    }
}
