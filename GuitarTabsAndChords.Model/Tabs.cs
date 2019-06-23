using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.Model
{
    public class Tabs
    {
        public int Id { get; set; }
        public string Notation { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEditted { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public int LastEditorId { get; set; }
        public Users LastEditor { get; set; }
        public int SongId { get; set; }
        public Songs Song { get; set; }
        public int TuningId { get; set; }
        public Tunings Tuning { get; set; }
        public bool Approved { get; set; }
    }
}
