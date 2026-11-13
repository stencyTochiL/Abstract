public class Entry
{
    public string Date { get; set; } = "";
    public string Prompt { get; set; } = "";
    public string Response { get; set; } = "";
    public string Mood { get; set; } = "";

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Prompt: {Prompt}");
        Console.WriteLine(Response);
        if (!string.IsNullOrWhiteSpace(Mood))
            Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine();
    }
}
