using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.Model
{
    public class TabCorrections
    {
        public int Id { get; set; }
        public int TabId { get; set; }
        public Tabs Tab { get; set; }
        public string Notation { get; set; }
        public int TuningId { get; set; }
        public Tunings Tuning { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public DateTime DateSubmitted { get; set; }
        public bool Approved { get; set; }
    }
}
