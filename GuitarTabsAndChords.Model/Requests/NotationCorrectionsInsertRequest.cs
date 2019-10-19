using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GuitarTabsAndChords.Model.Requests
{
    public class NotationCorrectionsInsertRequest
    {
        [Required]
        public string NotationContent { get; set; }
        [Required]
        public int NotationId { get; set; }
    }
}
