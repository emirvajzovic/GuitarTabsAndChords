﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.Model
{
    public class Ratings
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public int NotationId { get; set; }
        public Notations Notation { get; set; }

    }
}
