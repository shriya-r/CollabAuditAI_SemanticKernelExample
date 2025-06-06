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
                var questionItem = new QuestionItem.QuestionItem(output);
                FrontendApp.FrontendApp frontendApp = new FrontendApp.FrontendApp();
                await frontendApp.Display(quizData, questionItem);
            }
        }
    }
}