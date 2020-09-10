using CarpoolTracker.Models;
using System;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    [QueryProperty(nameof(TrackId), nameof(TrackId))]
    public class TrackEditViewModel : BaseViewModel<Track>
    {
        private int distance;
        private string name;
        private string trackid;

        public TrackEditViewModel()
        {
            Title = "Track";

            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
        }

        private bool IsInsert { get => TrackId == null || TrackId == ""; }
        public Command CancelCommand { get; }
        public int Distance { get => distance; set => SetProperty(ref distance, value); }
        public string Name { get => name; set => SetProperty(ref name, value); }
        public Command SaveCommand { get; }

        public string TrackId
        {
            get => trackid;
            set
            {
                SetProperty(ref trackid, value);
                LoadTrack();
            }
        }

        private void GoBack()
        {
            if (IsInsert)
                Shell.Current.GoToAsync($"..");
            else
                Shell.Current.GoToAsync($"..?{nameof(TrackDetailViewModel.TrackId)}={TrackId}");
        }

        private async void LoadTrack()
        {
            IsBusy = true;
            try
            {
                var track = await DataStore.GetAsync(TrackId);
                Name = track.Name;
                Distance = track.Distance;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void OnCancel(object obj)
        {
            GoBack();
        }

        private async void OnSave(object obj)
        {
            Track track;
            if (IsInsert)
                track = new Track() { Id = Guid.NewGuid().ToString() };
            else
                track = await DataStore.GetAsync(TrackId);

            track.Name = Name;
            track.Distance = Distance;

            if (IsInsert)
                await DataStore.AddAsync(track);
            else
                await DataStore.UpdateAsync(track);

            GoBack();
        }
    }
}