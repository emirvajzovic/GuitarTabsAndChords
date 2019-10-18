using GuitarTabsAndChords.Model;

namespace GuitarTabsAndChords.Mobile.Models
{
    public class NotationSortPickerItem
    {
        public NotationSort Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}