namespace CollabAuditAI.CollabQuiz.QuizParams
{
    public class QuizParams
    {
        private string topic;
        // Quiz parameters (i.e. topic, difficulty, etc...)
        public QuizParams(string topic)
        {
            this.topic = topic;
        }
        public string GetTopic()
        {
            return topic; // Return the topic
        }
    }
}