using Microsoft.SemanticKernel;
using CollabAuditAI.CollabQuiz.PluginFunctions;

namespace CollabAuditAI.CollabQuiz.QuizPlugin
{
    public class QuizPlugin : Plugin
    {
        protected Kernel kernel; // need the kernel to invoke the plugin functions
        public QuizPlugin(Kernel kernel)
        {
            this.kernel = kernel;
        }
        public async Task<string> CallPluginFunction(string topic)
        {
            var arguments = new KernelArguments() { ["input"] = topic };

            var AIplugin = new AIConnector.AIConnector(kernel);
            arguments = await AIplugin.ChooseLLM(arguments, "I need to create a quiz with this topic: " + topic);

            var result1 = await kernel.InvokeAsync(KernelBuilder.KernelBuilder.pluginFunctions["QA"], arguments);
            var result = result1.ToString();
            // For more specific results with those plugins
            if (topic.Contains("soccer", StringComparison.OrdinalIgnoreCase))
            {
                var soccerPlugin = new SoccerPlugin.SoccerPlugin(kernel);
                result = await soccerPlugin.CallSoccer(KernelBuilder.KernelBuilder.pluginFunctions); // get result, return at end
            }
            return result;
        }
    }
}