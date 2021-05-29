using System.Threading.Tasks;
using FunQuiz_Mobile.Common.Base;
using Xamarin.Forms;

namespace FunQuiz_Mobile.Common.Navigation
{

    public interface INavigationService
    {
        Task PushAsync<TViewModel>(string parameters = null) where TViewModel : BaseViewModel;
        Task PopAsync();
        Task InsertAsRoot<TViewModel>(string parameters = null) where TViewModel : BaseViewModel;
        Task GoBackAsync();
        Task GoToAsyncWithParameters<TViewModel>(string param) where TViewModel : ContentPage;
        void GoToMainFlow();
        void GoToLoginFlow();
    }

    class ShellRoutingService : INavigationService
    {
        public void GoToMainFlow()
        {
            Application.Current.MainPage = new AppShell();
        }

        public void GoToLoginFlow()
        {
            //Application.Current.MainPage = new LoginShell();
        }

        public Task PopAsync()
        {
            return Shell.Current.Navigation.PopAsync();
        }

        public Task GoBackAsync()
        {
            return Shell.Current.GoToAsync("..");
        }

        public Task InsertAsRoot<TViewModel>(string parameters = null) where TViewModel : BaseViewModel
        {
            return GoToAsync<TViewModel>("//", parameters);
        }

        public Task PushAsync<TViewModel>(string parameters = null) where TViewModel : BaseViewModel
        {
            return GoToAsync<TViewModel>("", parameters);
        }

        public Task GoToAsync<TViewModel>(string routePrefix, string parameters) where TViewModel : BaseViewModel
        {
            var route = routePrefix + typeof(TViewModel).Name;
            if (!string.IsNullOrWhiteSpace(parameters))
            {
                route += $"?{parameters}";
            }
            return Shell.Current.GoToAsync(route);
        }

        public Task GoToAsyncWithParameters<TViewModel>(string param) where TViewModel : ContentPage
        {
            return Shell.Current.GoToAsync($"{typeof(TViewModel).Name}?ItemId={param}");
        }

    }
}
