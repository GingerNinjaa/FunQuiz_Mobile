using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunQuiz_Mobile.Modules.ListOfQuiz
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfQuizPage : ContentPage
    {
        public ListOfQuizPage()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<ListOfQuizPageViewModel>();
        }
    }
}