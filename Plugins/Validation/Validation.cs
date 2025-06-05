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
        public async Task<string> CallPluginFunction(string output) // Formatter plugin to pass the result into LLM for desired formatting
        {
            var arguments = new KernelArguments() { ["input"] = output };
            var result = await kernel.InvokeAsync(pluginFunctions["Validation"], arguments);
            return result.ToString();
        }
    }
}
