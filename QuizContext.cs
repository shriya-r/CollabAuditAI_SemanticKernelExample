using Microsoft.SemanticKernel;

namespace CollabAuditAI.CollabQuiz.QuizContext
{
    public class QuizContext
    {
        public async Task<string> Filter(Kernel kernel, string topic)
        {
            PluginFunctions.Plugin pluginFunctions = new InputFilter.InputFilter(kernel);
            var filtered = await pluginFunctions.CallPluginFunction(topic);
            // Console.WriteLine("Filtered topic: " + filtered);
            return filtered.ToString();
        }
    }
}