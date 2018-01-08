using SearchHighlight.Wpf.Searching;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WpfHighlighter.Demo.ViewModels
{
    internal class ItemViewModel : INotifyPropertyChanged
    {
        private IEnumerable<LineMatch> matches = Enumerable.Empty<LineMatch>();

        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public DateTime BirthDate { get; internal set; }
        public IEnumerable<LineMatch> Matches
        {
            get { return matches; }
            set
            {
                matches = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Matches)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}