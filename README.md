# Journal Program

A C# console project targeting .NET 8. With a compatible .NET SDK installed, open a terminal in this folder and run:

```
dotnet run
```

Choose Write, Display, Load, Save, or Quit. Write supplies a random prompt and records the date, response, and optional mood. Entries stay in memory until you choose Save. Saving writes the complete journal and overwrites the chosen file. Loading replaces the current entries, including any unsaved entries. Relative filenames are resolved from the terminal's current folder.

Each major class has its own matching file: Program, Entry, Journal, and PromptGenerator. Journal hides its entry collection and provides methods for adding, displaying, saving, and loading. PromptGenerator hides prompt selection. Entry handles display of one entry.

Extra features are documented in Program.cs: JSON storage that handles punctuation correctly, optional mood tracking, and validation before loaded data replaces the current journal.

Manual verification:
1. Write two entries, one with a mood and one without; display them.
2. Include commas, quotation marks, a pipe, and a tilde in a response.
3. Save as journal.json, restart, load it, and display the entries.
4. Load an empty JSON array [] and confirm that Display reports an empty journal.
5. Attempt to load a missing file, malformed JSON, and [null]. Confirm that errors are reported and existing entries remain available.
6. Enter an invalid menu choice and a blank response; confirm helpful messages.

The .NET SDK was unavailable in the authoring environment, so this project has not been compiled or executed there. Run the checks above before submitting.

The companion PDF explains abstraction using code copied from Journal.cs. Add your genuine team meeting screenshot to complete the participation requirement, and review the explanation in your own words.
