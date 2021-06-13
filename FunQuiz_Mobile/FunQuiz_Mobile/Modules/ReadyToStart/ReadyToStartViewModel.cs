using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FunQuiz_Mobile.Common.Base;
using FunQuiz_Mobile.Common.Navigation;
using FunQuiz_Mobile.Models;
using FunQuiz_Mobile.Services;
using Xamarin.Forms;

namespace FunQuiz_Mobile.Modules.ReadyToStart
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ReadyToStartViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
       // public ObservableCollection<QuizPartial> QuizPartialColection { get; }
        public ObservableCollection<Question> QuizPartialColection { get; }

        public Command<string> ButtonTapped { get; }

        public ReadyToStartViewModel(INavigationService navigationService)
        {
            QuizPartialColection = new ObservableCollection<Question>();
            _navigationService = navigationService;
            ButtonTapped = new Command<string>(NextQuestion);
            //LoadQuiz(ItemId);
        }

        #region Property
        private string itemId = "";
        public string ItemId
        {
            get { return itemId; }
            set
            {
                //itemId = value;
                itemId = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged();
                //  LoadItemId(value);
                LoadQuiz();
            }
        }
        private string _Answer1;
        private string _Answer2;
        private string _Answer3;
        private string _Answer4;
        private int _Points;
        private int _Index = 0;
        public string Answer1
        {
            get => _Answer1;
            set => SetProperty(ref _Answer1, value);
        }
        public string Answer2
        {
            get => _Answer2;
            set => SetProperty(ref _Answer2, value);
        }
        public string Answer3
        {
            get => _Answer3;
            set => SetProperty(ref _Answer3, value);
        }
        public string Answer4
        {
            get => _Answer4;
            set => SetProperty(ref _Answer4, value);
        }
        public int Points
        {
            get => _Points;
            set => SetProperty(ref _Points, value);
        }
        private string _question;
        public string Question
        {
            get => _question;
            set => SetProperty(ref _question, value);
        }
        private string _corectAnswer;
        public string CorectAnswer
        {
            get => _corectAnswer;
            set => SetProperty(ref _corectAnswer, value);
        }
        private string _fullimage;
        public string imageUrl
        {
            get => _fullimage;
            set => SetProperty(ref _fullimage, value);
        }
        #endregion


        public async void LoadQuiz()
        {
            try
            {
                var quiz = await ApiService.GetQuizWithQuestionsAndAnswers(Int32.Parse(itemId));

                if (quiz.questions.Count == 0)
                {
                }
                foreach (var element in quiz.questions)
                {
                    if (QuizPartialColection.Count == 0)
                    {
                        imageUrl = element.image;
                        Question = element.text;
                        CorectAnswer = element.corectAnswer;
                        Answer1 = element.answers[0].text;
                        Answer2 = element.answers[1].text;
                        Answer3 = element.answers[2].text;
                        Answer4 = element.answers[3].text;
                    }
                    QuizPartialColection.Add(element);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public  void NextQuestion(string selectedAnswer)
        {
            //porównanie odpoweidzi z właściwą
            if (QuizPartialColection.ElementAt(_Index).corectAnswer == selectedAnswer)
            {  //dodanie punktu
                Points++;
            }
          
            //przeładowanie tekstu i obrazków
            if (_Index == 3)
            {
                //Points
                 Application.Current.MainPage.DisplayAlert("Sukces!", $"Uzyskałeś {Points}/4", "OK");
                 _navigationService.GoBackAsync();
            }
            else
            {
                _Index++;
                var nextElement = QuizPartialColection.ElementAt(_Index);
                imageUrl = nextElement.image;
                Question = nextElement.text;
                CorectAnswer = nextElement.corectAnswer;
                Answer1 = nextElement.answers[0].text;
                Answer2 = nextElement.answers[1].text;
                Answer3 = nextElement.answers[2].text;
                Answer4 = nextElement.answers[3].text;
                
            }
        
        }

    }
}

