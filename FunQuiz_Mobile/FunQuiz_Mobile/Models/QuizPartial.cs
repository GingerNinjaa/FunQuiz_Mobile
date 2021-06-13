using System.Collections.Generic;
using FunQuiz_Mobile.Settings;

namespace FunQuiz_Mobile.Models
{
    public class QuizPartial
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public string image => AppSetting.ApiUrlIMG + imageUrl;
        public List<Question> questions { get; set; }
    }
}
