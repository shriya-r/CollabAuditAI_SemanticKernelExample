using Microsoft.SemanticKernel;

namespace CollabAuditAI.CollabQuiz.ConnectorInterface
{
    public interface AIConnectorInterface
    {
        Task<KernelArguments> ChooseLLM(KernelArguments arguments, string input);
    }
}