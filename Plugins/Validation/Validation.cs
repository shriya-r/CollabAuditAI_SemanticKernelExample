using Microsoft.SemanticKernel;
using CollabAuditAI.CollabQuiz.PluginFunctions;

namespace CollabAuditAI.CollabQuiz.Validation
{
    public class Validation : Plugin
    {
        private Kernel kernel;
        private KernelPlugin pluginFunctions;
        public Validation(Kernel kernel)
        {
            this.kernel = kernel;
            pluginFunctions = KernelBuilder.KernelBuilder.pluginFunctions;
        }
        public async Task<string> CallPluginFunction(string output) // Validate the quiz accuracy
        {
            var arguments = new KernelArguments() { ["input"] = output };

            var AIplugin = new AIConnector.AIConnector(kernel); // Choose the LLM to validate the quiz
            arguments = await AIplugin.ChooseLLM(arguments, "I need to validate the accuracy of this quiz: " + output);

            var result = await kernel.InvokeAsync(pluginFunctions["Validation"], arguments);
            return result.ToString();
        }
    }
}