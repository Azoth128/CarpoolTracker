using CarpoolTracker.Models;
using CarpoolTracker.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    public class TracksViewModel : BaseViewModel<Track>
    {
        public ObservableCollection<Track> Tracks { get; }

        public Command LoadTracksCommand { get; }
        public Command<Track> TrackTappedCommand { get; }
        public Command NewTrackCommand { get; }

        public TracksViewModel()
        {
            Title = "Traks";
            Tracks = new ObservableCollection<Track>();

            LoadTracksCommand = new Command(LoadTracks);
            TrackTappedCommand = new Command<Track>(OnTrackTapped);
            NewTrackCommand = new Command(OnNewTrack);
        }

        public void OnAppearing()
        {
            LoadTracks();
        }

        private void OnNewTrack(object obj)
        {
            Shell.Current.GoToAsync($"{nameof(TrackEditPage)}");
        }

        private void OnTrackTapped(Track track)
        {
            Shell.Current.GoToAsync($"{nameof(TrackDetailPage)}?{nameof(TrackDetailViewModel.TrackId)}={track.Id}");
        }

        private async void LoadTracks()
        {
            IsBusy = true;
            try
            {
                Tracks.Clear();
                var tracks = await DataStore.GetListAsync();
                foreach (var track in tracks)
                {
                    Tracks.Add(track);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}