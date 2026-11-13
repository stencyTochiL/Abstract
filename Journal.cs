using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new();

    public void AddEntry(Entry entry)
    {
        ArgumentNullException.ThrowIfNull(entry);
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty. Choose Write to begin.");
            return;
        }

        foreach (Entry entry in _entries)
            entry.Display();
    }

    public void SaveToFile(string filename)
    {
        string json = JsonSerializer.Serialize(_entries,
            new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
    }

    public void LoadFromFile(string filename)
    {
        string json = File.ReadAllText(filename);
        List<Entry>? loaded = JsonSerializer.Deserialize<List<Entry>>(json);

        // Validate everything before replacing the current journal.
        if (loaded is null || loaded.Any(entry => entry is null ||
            string.IsNullOrWhiteSpace(entry.Date) ||
            string.IsNullOrWhiteSpace(entry.Prompt) ||
            string.IsNullOrWhiteSpace(entry.Response)))
        {
            throw new InvalidDataException("The file contains invalid journal entries.");
        }

        _entries = loaded;
    }
}
