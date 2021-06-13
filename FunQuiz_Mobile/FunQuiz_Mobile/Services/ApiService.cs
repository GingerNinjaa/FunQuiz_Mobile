using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FunQuiz_Mobile.Models;
using FunQuiz_Mobile.Settings;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace FunQuiz_Mobile.Services
{
    public static class ApiService
    {
        public static async Task<List<QuizPartial>> GetAllQuizPartial(int pageNuber, int pageSize)
        {
            var httpClient = new HttpClient();

           // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSetting.ApiUrl +
                                                           $"quizlist");
            //             var response = await httpClient.GetStringAsync(AppSetting.ApiUrl +
            // $"quizlist/?pageNumber={pageNuber}&pageSize={pageSize}");
            return JsonConvert.DeserializeObject<List<QuizPartial>>(response);
        }

        //www.gingerninjaaapiservice.pl/quiz/QuizAndQuestionAndAnswers/3

        public static async Task<QuizPartial> GetQuizWithQuestionsAndAnswers(int quizId)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(AppSetting.ApiUrl +
                                                           $"QuizAndQuestionAndAnswers/{quizId}");
            return JsonConvert.DeserializeObject<QuizPartial>(response);
        }
    }
}
