using System;
using System.Collections.Generic;

namespace SearchHighlight.Wpf.Searching
{
    public class Matcher
    {
        public IEnumerable<LineMatch> GetMatches(string propertyName, string text, string searchText)
        {
            var startFrom = 0;
            while (true)
            {
                var idx = text.IndexOf(searchText, startFrom, StringComparison.InvariantCultureIgnoreCase);
                if (idx == -1)
                {
                    break;
                }
                yield return new LineMatch()
                {
                    PropertyName = propertyName,
                    Start = idx,
                    End = idx + searchText.Length
                };
                startFrom = idx + searchText.Length;
            }
        }
    }
}
