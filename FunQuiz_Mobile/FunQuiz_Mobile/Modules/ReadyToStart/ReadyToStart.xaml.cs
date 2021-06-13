
using System;
using Autofac;
using FunQuiz_Mobile.Common.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunQuiz_Mobile.Modules.ReadyToStart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadyToStart : ContentPage
    {
        public ReadyToStart()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<ReadyToStartViewModel>();
           //BindingContext = ReadyToStartViewModel();

        }

      
    }
}