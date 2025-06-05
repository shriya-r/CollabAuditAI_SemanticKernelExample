namespace CollabAuditAI.CollabQuiz.QuizData
{
    public class QuizData
    {
        private string question; // stores questions
        public QuizData(string output)
        {
            var Output = output.ToString().Split("ANSWER:");
            question = Output[0].Trim();
        }
        public string getQuestion()
        {
            return question;
        }
    }
}