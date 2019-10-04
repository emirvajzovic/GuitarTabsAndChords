using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Database
{
    public class NotationViews
    {
        public int Id { get; set; }
        public int NotationId { get; set; }
        public Notations Notation { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
