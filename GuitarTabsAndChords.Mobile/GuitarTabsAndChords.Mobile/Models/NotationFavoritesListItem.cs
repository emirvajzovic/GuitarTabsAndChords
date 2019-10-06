using GuitarTabsAndChords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.Mobile.Models
{
    public class NotationFavoritesListItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public int NotationId { get; set; }
        public Notations Notation { get; set; }

        public string StarImage
        {
            get
            {
                if (IsFavorite)
                    return "star_filled.png";
                else
                    return "star_empty.png";
            }
        }
        public bool IsFavorite { get; set; } = true;

    }

}
