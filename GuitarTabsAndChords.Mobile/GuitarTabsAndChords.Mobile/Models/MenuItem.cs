using System;
using System.Collections.Generic;
using System.Text;

namespace GuitarTabsAndChords.Mobile.Models
{
    public class MenuItem
    {
        public string Image { get; set; }
        public string Text { get; set; }
        public Type Page { get; internal set; }
    }
}
