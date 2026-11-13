using System.Text.Json;

// Exceeding requirements: Entries include an optional mood field, helping users
// reflect on their feelings as well as events. The journal uses JSON storage,
// which safely preserves commas, quotation marks, and other punctuation.
// Invalid files are checked before replacing the current journal.
public class Program
{
    public static void Main()
    {
        Journal journal = new();
        PromptGenerator promptGenerator = new();
        Console.WriteLine("Welcome to the Journal Program!");

        while (true)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string? choice = Console.ReadLine();
            if (choice is null || choice.Trim() == "5")
                break;

            try
            {
                switch (choice.Trim())
                {
                    case "1":
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine(prompt);
                        Console.Write("> ");
                        string? response = Console.ReadLine();
                        if (response is null) return;
                        if (string.IsNullOrWhiteSpace(response))
                        {
                            Console.WriteLine("Entry not added: please write a response.");
                            break;
                        }
                        Console.Write("How are you feeling? (optional): ");
                        string mood = Console.ReadLine() ?? "";
                        journal.AddEntry(new Entry
                        {
                            Date = DateTime.Now.ToString("yyyy-MM-dd"),
                            Prompt = prompt,
                            Response = response,
                            Mood = mood
                        });
                        Console.WriteLine("Entry added. Choose Save to keep it in a file.");
                        break;
                    case "2":
                        journal.DisplayAll();
                        break;
                    case "3":
                        Console.Write("Filename to load (replaces current entries): ");
                        string? loadFilename = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(loadFilename))
                        {
                            Console.WriteLine("Please enter a filename.");
                            break;
                        }
                        journal.LoadFromFile(loadFilename);
                        Console.WriteLine("Journal loaded.");
                        break;
                    case "4":
                        Console.Write("Filename to save (for example journal.json): ");
                        string? saveFilename = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(saveFilename))
                        {
                            Console.WriteLine("Please enter a filename.");
                            break;
                        }
                        journal.SaveToFile(saveFilename);
                        Console.WriteLine("Journal saved.");
                        break;
                    default:
                        Console.WriteLine("Please choose a number from 1 to 5.");
                        break;
                }
            }
            catch (Exception ex) when (ex is IOException ||
                ex is UnauthorizedAccessException || ex is JsonException ||
                ex is InvalidDataException ||
                ex is ArgumentException || ex is NotSupportedException)
            {
                Console.WriteLine($"Unable to complete the action: {ex.Message}");
            }
        }
        Console.WriteLine("Goodbye!");
    }
}
