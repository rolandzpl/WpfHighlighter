using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WpfHighlighter.Demo.Converters
{
    public class BindableInlinesExtensions
    {
        public static readonly DependencyProperty BindableInlinesProperty =
            DependencyProperty.RegisterAttached("BindableInlines", typeof(IEnumerable<Inline>), 
                typeof(BindableInlinesExtensions), new PropertyMetadata(OnInlinesPropertyChanged));

        public static void SetBindableInlines(DependencyObject obj, IEnumerable<Inline> inlines)
        {
            obj.SetValue(BindableInlinesProperty, inlines);
        }

        public static IEnumerable<Inline> GetBindableInlines(DependencyObject obj)
        {
            return (IEnumerable<Inline>)obj.GetValue(BindableInlinesProperty);
        }

        private static void OnInlinesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var tb = (TextBlock)d;
            tb.Inlines.Clear();
            tb.Inlines.AddRange((IEnumerable<Inline>)e.NewValue);
        }
    }
}
