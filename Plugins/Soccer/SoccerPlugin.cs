using Microsoft.SemanticKernel;

namespace CollabAuditAI.CollabQuiz.SoccerPlugin
{
    public class SoccerPlugin : QuizPlugin.QuizPlugin // extends QuizPlugin
    {
        public SoccerPlugin(Kernel kernel)
            : base(kernel)
        { // initialize base class
        }
        public async Task<string> CallSoccer(KernelPlugin pluginFunctions) // Call the soccer plugin with more specific information
        {
            // Call the soccer plugin with more specific information
            var arguments = new KernelArguments() { ["input"] = "top soccer players and important game results" };
            var result = await kernel.InvokeAsync(pluginFunctions["Soccer"], arguments);
            return result.ToString();
        }
    }
}
