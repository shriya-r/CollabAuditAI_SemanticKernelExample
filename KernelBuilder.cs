using Microsoft.SemanticKernel;
using Kernel = Microsoft.SemanticKernel.Kernel;

namespace CollabAuditAI.CollabQuiz.KernelBuilder
{
    public class KernelBuilder // Singleton pattern, but not a strict singleton
    {
        // API Key should not be accessible from the main file
        private static string apiKey = "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";
        private static Kernel kernel_;
        public static KernelPlugin pluginFunctions;
        // Build the kernel with the OpenAI API
        static KernelBuilder()
        {
            var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion("gpt-4o-mini", apiKey, serviceId: "gpt4o")
                                                .AddOpenAIChatCompletion("gpt-4.1-mini", apiKey, serviceId: "gpt4.1");
            kernel_ = builder.Build();
            var pluginDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
            pluginFunctions = kernel_.ImportPluginFromPromptDirectory(pluginDirectory);

        }
        // Make the kernel accessible
        public Kernel GetKernel()
        {
            return kernel_;
        }
    }
}