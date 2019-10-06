using System;
using System.Collections.Generic;
using System.Text;

namespace GuitarTabsAndChords.Model
{
    public class SearchResult
    {
        public int Id { get; set; }
        public string ResultText { get; set; }
        public Type ResultType { get; set; }
        public string ResultTypeName => ResultType?.Name.Substring(0, ResultType.Name.Length - 1);
    }
}
