using SearchHighlight.Wpf.Searching;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfHighlighter.Demo.ViewModels
{
    class SampleViewModel : INotifyPropertyChanged
    {
        private string searchText;
        private readonly ObservableCollection<LineMatch> matches = new ObservableCollection<LineMatch>();
        private readonly ObservableCollection<ItemViewModel> lines = new ObservableCollection<ItemViewModel>();

        public string SearchText
        {
            get { return searchText; }

            set
            {
                searchText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchText)));
            }
        }

        public ICollection<ItemViewModel> Lines
        {
            get { return lines; }
        }

        public ICollection<LineMatch> Matches
        {
            get { return matches; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
