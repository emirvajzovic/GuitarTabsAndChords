using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.Model
{
    public class NotationCorrections
    {
        public int Id { get; set; }
        public int NotationId { get; set; }
        public Notations Notation { get; set; }
        public string NotationContent { get; set; }
        public string Tuning { get; set; }
        public string TuningDescription { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public DateTime DateSubmitted { get; set; }
        public ReviewStatus Status { get; set; }
    }
}
