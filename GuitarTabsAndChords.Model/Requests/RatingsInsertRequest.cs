using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GuitarTabsAndChords.Model.Requests
{
    public class RatingsInsertRequest
    {
        public int NotationId { get; set; }
        public int Rating { get; set; }
    }
}
