namespace CollabAuditAI.CollabQuiz.QuestionItem
{
    public class QuestionItem
    {
        private string answer; // stores answers
        public QuestionItem(string output)
        {
            var Output = output.ToString().Split("ANSWER:");
            answer = Output[1].Trim();
        }
        public string getAnswer()
        {
            return answer;
        }
    }
}