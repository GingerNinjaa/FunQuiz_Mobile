using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FunQuiz_Mobile.Common.Base;
using FunQuiz_Mobile.Common.Navigation;
using FunQuiz_Mobile.Models;
using FunQuiz_Mobile.Services;
using Xamarin.Forms;

namespace FunQuiz_Mobile.Modules.ListOfQuiz
{
    public class ListOfQuizPageViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        public ObservableCollection<QuizPartial> QuizPartialColection { get; }
        public Command<QuizPartial> ItemTapped { get; }

        public ListOfQuizPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            QuizPartialColection = new ObservableCollection<QuizPartial>();
            ItemTapped = new Command<QuizPartial>(OnItemSelected);
            GetAll();
        }

        async void OnItemSelected(QuizPartial item)
        {
            if (item == null)
                return;
            await _navigationService.GoToAsyncWithParameters<ReadyToStart.ReadyToStart>(item.id.ToString());
            // await Shell.Current.GoToAsync($"{nameof(RecepieDetailPage)}?ItemId={item.id.ToString()}");
        }

        public async void GetAll()
        {
            try
            {
                //refresh user name
                // this.userName = Preferences.Get("userName", String.Empty);
                

                var recepies = await ApiService.GetAllQuizPartial(1,100);
                if (recepies.Count == 0)
                {
                    
                }
                foreach (var recepie in recepies)
                {
                    QuizPartialColection.Add(recepie);
                }
            }
            catch (Exception e)
            {

            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
