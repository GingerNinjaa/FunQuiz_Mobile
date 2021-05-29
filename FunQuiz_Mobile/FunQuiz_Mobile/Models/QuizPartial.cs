using System.Collections.Generic;

namespace FunQuiz_Mobile.Models
{
    public class QuizPartial
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Question> ingredients { get; set; }
    }
}
