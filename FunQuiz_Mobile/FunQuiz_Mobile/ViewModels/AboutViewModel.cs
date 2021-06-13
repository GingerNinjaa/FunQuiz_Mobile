using System;
using System.Windows.Input;
using FunQuiz_Mobile.Common.Base;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FunQuiz_Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}