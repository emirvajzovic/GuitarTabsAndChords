using GuitarTabsAndChords.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuitarTabsAndChords.Mobile.Services
{
    public class NotationSortHelper
    {
        public static List<NotationSortPickerItem> GetSortPickerItems()
        {
            var dict = new Dictionary<Model.NotationSort, string>
            {
                { Model.NotationSort.RECENTLY_ADDED, "Recently added" },
                { Model.NotationSort.SONG_ASC, "Songs (A-Z)" },
                { Model.NotationSort.SONG_DESC, "Songs (Z-A)" },
                { Model.NotationSort.ARTIST_ASC, "Artists (A-Z)" },
                { Model.NotationSort.ARTIST_DESC, "Artists (Z-A)" },
                { Model.NotationSort.RATING, "Rating" }
            };

            var list = new List<NotationSortPickerItem>();
            foreach (var item in dict)
            {
                list.Add(new NotationSortPickerItem
                {
                    Text = item.Value,
                    Value = item.Key
                });
            }


            return list;
        }
    }
}
