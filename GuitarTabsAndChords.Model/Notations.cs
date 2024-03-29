﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.Model
{
    public class Notations
    {
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

        public override string ToString()
        {
            return Song.Name;
        }
    }

    public enum NotationType { Tab, Chord }
}
