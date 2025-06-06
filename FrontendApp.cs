using Microsoft.SemanticKernel;

namespace CollabAuditAI.CollabQuiz.FrontendApp
{
    public class FrontendApp
    {
        public async Task Display(QuizData.QuizData quizData, QuestionItem.QuestionItem questionItem)
        {
            Console.WriteLine(quizData.getQuestion());
            await Task.Delay(20000);
            Console.WriteLine("ANSWER: " + questionItem.getAnswer());
        }
    }
}