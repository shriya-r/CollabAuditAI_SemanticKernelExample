using Microsoft.SemanticKernel;

namespace CollabAuditAI.CollabQuiz.Formatter
{
    public class Formatter
    {
        public async Task Presentation(Kernel kernel, string output)
        {
            PluginFunctions.Plugin pluginFunctions = new Validation.Validation(kernel);
            var isValid = await pluginFunctions.CallPluginFunction(output);
            if (isValid != "Yes")
            {
                Console.WriteLine("Invalid quiz was generated. Please try again.");
            }
            else
            {
                PluginFunctions.Plugin presentPlugin = new Presentation.Presentation(kernel); // Present the output in the desired format
                output = await presentPlugin.CallPluginFunction(output);
                var quizData = new QuizData.QuizData(output);
                Console.WriteLine(quizData.getQuestion());
                await Task.Delay(20000);
                var questionItem = new QuestionItem.QuestionItem(output);
                Console.WriteLine("ANSWER: " + questionItem.getAnswer());
            }
        }
    }
}
