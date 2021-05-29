using FunQuiz_Mobile.Common.Base;
using FunQuiz_Mobile.Common.Navigation;

namespace FunQuiz_Mobile.Modules.ListOfQuiz
{
    public class ListOfQuizPageViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public ListOfQuizPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}
