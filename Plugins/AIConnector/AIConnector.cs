using Microsoft.SemanticKernel;
using CollabAuditAI.CollabQuiz.PluginFunctions;

namespace CollabAuditAI.CollabQuiz.AIConnector
{
    public class AIConnector : Plugin
    {
        private Kernel kernel;
        private KernelPlugin pluginFunctions;
        public AIConnector(Kernel kernel)
        {
            this.kernel = kernel;
            pluginFunctions = KernelBuilder.KernelBuilder.pluginFunctions;
        }
        public async Task<string> CallPluginFunction(string context) // Call plugin to filter inputted topic
        {
            var arguments = new KernelArguments() { ["input"] = context };
            var result = await kernel.InvokeAsync(pluginFunctions["AIConnector"], arguments);
            return result.ToString();
        }
    }
}
