using GuitarTabsAndChords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuitarTabsAndChords.Mobile.Models
{
    public class NotationBrowseListItem
    {
        public NotationBrowseListItem()
        {
            Star1 = new Star();
            Star2 = new Star();
            Star3 = new Star();
            Star4 = new Star();
            Star5 = new Star();
        }

        public int Id { get; set; }
        public string NotationContent { get; set; }
        public NotationType Type { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEditted { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public int LastEditorId { get; set; }
        public Users LastEditor { get; set; }
        public int SongId { get; set; }
        public Songs Song { get; set; }
        public string Tuning { get; set; }
        public string TuningDescription { get; set; }
        public ReviewStatus Status { get; set; }

        public int Views { get; set; }
        public int Favorites { get; set; }
        public double Rating { get; set; }

        public Star Star1 { get; set; }
        public Star Star2 { get; set; }
        public Star Star3 { get; set; }
        public Star Star4 { get; set; }
        public Star Star5 { get; set; }

        public int Counter { get; set; }
    }
}
