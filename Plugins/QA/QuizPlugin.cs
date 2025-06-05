using Microsoft.SemanticKernel;
using CollabAuditAI.CollabQuiz.PluginFunctions;
using Microsoft.SemanticKernel.Connectors.OpenAI;

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

            Plugin pluginFunctions = new AIConnector.AIConnector(kernel);
            var model_name = await pluginFunctions.CallPluginFunction("Need to create a quiz about " + topic);
            string modelID = "gpt4o";
            if (model_name.Contains("gpt-4.1-mini"))
            {
                modelID = "gpt4.1";
            }
            arguments.ExecutionSettings = new Dictionary<string, PromptExecutionSettings>()
            {
                [modelID] = new OpenAIPromptExecutionSettings { ServiceId = modelID }
            };

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
