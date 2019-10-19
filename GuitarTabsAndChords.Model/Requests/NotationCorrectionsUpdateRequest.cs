using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GuitarTabsAndChords.Model.Requests
{
    public class NotationCorrectionsUpdateRequest
    {
        public string NotationContent { get; set; }
        [Required]
        public bool Approved { get; set; }
    }
}
