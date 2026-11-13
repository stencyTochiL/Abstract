public class PromptGenerator
{
    private readonly List<string> _prompts = new()
    {
        "What small moment made you smile today?",
        "What challenge did you face, and how did you respond?",
        "What did you learn today that you want to remember?",
        "Who helped you today, and how did their help matter?",
        "What is one thing you are grateful for today?",
        "When did you feel close to the Lord today?",
        "What kind action did you take today?",
        "What is one small thing you want to do differently tomorrow?"
    };

    public string GetRandomPrompt()
    {
        return _prompts[Random.Shared.Next(_prompts.Count)];
    }
}
