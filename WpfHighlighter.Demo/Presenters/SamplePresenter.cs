﻿using SearchHighlight.Wpf.Searching;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using WpfHighlighter.Demo.ViewModels;

namespace WpfHighlighter.Demo.Presenters
{
    class SamplePresenter
    {
        private readonly SampleViewModel viewModel;

        public SamplePresenter()
        {
            viewModel = new SampleViewModel();
            viewModel.Lines.Add(new ItemViewModel() { FirstName = "Bill", LastName = "Gates", BirthDate = DateTime.Parse("1955-10-28") });
            viewModel.Lines.Add(new ItemViewModel() { FirstName = "Steve", LastName = "Jobs", BirthDate = DateTime.Parse("1955-02-24") });
            viewModel.Lines.Add(new ItemViewModel() { FirstName = "Steve", LastName = "Wozniak", BirthDate = DateTime.Parse("1950-08-11") });
            viewModel.Lines.Add(new ItemViewModel() { FirstName = "Larry", LastName = "Page", BirthDate = DateTime.Parse("1973-03-26") });
            viewModel.Lines.Add(new ItemViewModel() { FirstName = "Sergey", LastName = "Brinn", BirthDate = DateTime.Parse("1973-08-21") });
            viewModel.Lines.Add(new ItemViewModel() { FirstName = "Robert, Cecil", LastName = "Martin", BirthDate = DateTime.Parse("1952-01-01") });
            viewModel.Lines.Add(new ItemViewModel() { FirstName = "Martin", LastName = "Fowler", BirthDate = DateTime.Parse("1963-01-01") });
            viewModel.Lines.Add(new ItemViewModel() { FirstName = "Bjarne", LastName = "Stroustrup", BirthDate = DateTime.Parse("1950-12-30") });
            viewModel.Lines.Add(new ItemViewModel() { FirstName = "Brian", LastName = "Kernighan", BirthDate = DateTime.Parse("1942-01-01") });
            viewModel.Lines.Add(new ItemViewModel() { FirstName = "Dennis", LastName = "Ritchie", BirthDate = DateTime.Parse("1941-09-09") });
            viewModel.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SampleViewModel.SearchText))
            {
                var matcher = new Matcher();
                var st = viewModel.SearchText;
                foreach (var l in viewModel.Lines)
                {
                    var matches = new List<LineMatch>();
                    if (!string.IsNullOrWhiteSpace(st))
                    {
                        matches.AddRange(matcher.GetMatches(nameof(l.FirstName), l.FirstName, st));
                        matches.AddRange(matcher.GetMatches(nameof(l.LastName), l.LastName, st));
                    }
                    l.Matches = matches;
                }
            }
        }

        public SampleViewModel ViewModel
        {
            get { return viewModel; }
        }
    }
}
