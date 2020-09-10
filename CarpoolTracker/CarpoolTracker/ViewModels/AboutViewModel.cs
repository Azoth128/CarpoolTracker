﻿using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CarpoolTracker.ViewModels
{
    public class AboutViewModel : BaseViewModel<object>
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}