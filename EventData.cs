namespace CollabAuditAI.CollabQuiz.EventData
{
    public class EventData
    {
        private string topic;
        // Store variables with information from the input (i.e. topic, difficulty, any other data...)
        public EventData(string input)
        {
            topic = input;
        }
        public string GetTopic()
        {
            return topic; // Return the topic
        }
    }
}