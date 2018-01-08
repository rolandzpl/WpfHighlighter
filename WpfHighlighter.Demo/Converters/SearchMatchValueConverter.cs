using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using WpfHighlighter.Demo.ViewModels;

namespace WpfHighlighter.Demo.Converters
{
    class SearchMatchValueConverter : IMultiValueConverter
    {
        public static DependencyProperty MatchesProperty =
            DependencyProperty.RegisterAttached("Matches", typeof(IEnumerable<LineMatch>),
                typeof(SearchMatchValueConverter), new PropertyMetadata(OnMatchesPropertyChanged));

        private static void OnMatchesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.All(v => v == null || v.Equals(DependencyProperty.UnsetValue)))
            {
                return DependencyProperty.UnsetValue;
            }
            var propertyName = (string)parameter;
            var matches = ((IEnumerable<LineMatch>)values[1])
                .Where(m => m.PropertyName == propertyName)
                .ToArray();
            if (!matches.Any())
            {
                var runs = new List<Inline>();
                runs.Add(new Run((string)values[0]));
                return runs.AsEnumerable();
            }
            if (values[0] is string)
            {
                var s = (string)values[0];
                var runs = new List<Inline>();
                var idx = 0;
                foreach (var m in matches)
                {
                    if (idx != m.Start)
                    {
                        runs.Add(new Run(s.Substring(idx, m.Start - idx)));
                    }
                    var r = new Run(s.Substring(m.Start, m.End - m.Start));
                    r.Background = Brushes.Yellow;
                    runs.Add(r);
                    idx = m.End;
                }
                if (idx < s.Length)
                {
                    runs.Add(new Run(s.Substring(idx, s.Length - idx)));
                }
                return runs.AsEnumerable();
            }
            else
            {
                throw new NotImplementedException($"Type {values[0].GetType().Name} is no supported");
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
