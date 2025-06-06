using CollabAuditAI.CollabQuiz.KernelBuilder; // namespaces
using CollabAuditAI.CollabQuiz.UserInput;
using CollabAuditAI.CollabQuiz.Formatter;
using CollabAuditAI.CollabQuiz.PluginFunctions;
using CollabAuditAI.CollabQuiz.EventData;
using CollabAuditAI.CollabQuiz.QuizPlugin;
using CollabAuditAI.CollabQuiz.QuizParams;
using CollabAuditAI.CollabQuiz.QuizContext;

var kernelBuilder = new KernelBuilder();
var kernel = kernelBuilder.GetKernel();

var user = new User();
EventData Event = user.UserInput(); // User inputs a topic
QuizParams quiz = new QuizParams(Event.GetTopic()); // Create quiz parameters

var quizContext = new QuizContext();
var topic = await quizContext.Filter(kernel, quiz.GetTopic()); // Filter the user input

Plugin pluginFunctions = new QuizPlugin(kernel);
var result = await pluginFunctions.CallPluginFunction(topic);

// To format the output for presentation and send to frontend application
var formatter = new Formatter();
await formatter.Presentation(kernel, result);