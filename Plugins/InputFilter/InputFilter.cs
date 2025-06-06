using Microsoft.SemanticKernel;
using CollabAuditAI.CollabQuiz.PluginFunctions;

namespace CollabAuditAI.CollabQuiz.InputFilter
{
    public class InputFilter : Plugin
    {
        private Kernel kernel;
        private KernelPlugin pluginFunctions;
        public InputFilter(Kernel kernel)
        {
            this.kernel = kernel;
            pluginFunctions = KernelBuilder.KernelBuilder.pluginFunctions;
        }
        public async Task<string> CallPluginFunction(string topic) // Call plugin to filter inputted topic
        {
            var arguments = new KernelArguments() { ["input"] = topic };
            var AIplugin = new AIConnector.AIConnector(kernel);
            arguments = await AIplugin.ChooseLLM(arguments, "I need to filter this input: " + topic);
            var result = await kernel.InvokeAsync(pluginFunctions["InputFilter"], arguments);
            return result.ToString();
        }
    }
}