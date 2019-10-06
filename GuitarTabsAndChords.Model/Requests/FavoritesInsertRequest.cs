using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GuitarTabsAndChords.Model.Requests
{
    public class FavoritesInsertRequest
    {
        public int NotationId { get; set; }
    }
}
