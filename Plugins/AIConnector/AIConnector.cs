using Microsoft.SemanticKernel;
using CollabAuditAI.CollabQuiz.PluginFunctions;
using CollabAuditAI.CollabQuiz.ConnectorInterface;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace CollabAuditAI.CollabQuiz.AIConnector
{
    public class AIConnector : Plugin, AIConnectorInterface
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
        public async Task<KernelArguments> ChooseLLM(KernelArguments arguments, string topic) // Choose the LLM based on the event
        {
            var model_name = await CallPluginFunction(topic);
            string modelID = "gpt4o";
            if (model_name.Contains("gpt-4.1-mini"))
            {
                modelID = "gpt4.1";
            }
            arguments.ExecutionSettings = new Dictionary<string, PromptExecutionSettings>()
            {
                [modelID] = new OpenAIPromptExecutionSettings { ServiceId = modelID }
            };
            return arguments;
        }
    }
}