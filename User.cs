namespace CollabAuditAI.CollabQuiz.UserInput
{
    public class User
    {
        public EventData.EventData UserInput()
        {
            Console.Write("Enter the topic: "); // Ask the user for a topic
            string? input = Console.ReadLine();
            string topic = input ?? "Q&A"; // Q&A is the default topic if the input is null
            EventData.EventData newEvent = new EventData.EventData(topic);
            return newEvent;
        }
    }
}