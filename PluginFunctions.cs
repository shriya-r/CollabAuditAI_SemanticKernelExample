namespace CollabAuditAI.CollabQuiz.PluginFunctions
{
    public interface Plugin
    {
        Task<string> CallPluginFunction(string input);
    }
}