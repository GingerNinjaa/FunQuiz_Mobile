using System.Collections.Generic;
using FunQuiz_Mobile.Settings;

namespace FunQuiz_Mobile.Models
{
    public class Question
    {
        public int id { get; set; }
        public string text { get; set; }
        public string imageUrl { get; set; }
        public string image => AppSetting.ApiUrlIMG + imageUrl;
        public string corectAnswer { get; set; }
        public List<Answer> answers { get; set; }
    }
}
