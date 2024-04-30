namespace StringParser.App;

public interface IStringParserService
{
    string Parse(string input);
}

public class StringParserService : IStringParserService
{
    /// <summary>
    /// Parses a sentence and replaces each word with the following: first letter, number of distinct characters between first and last character, and last letter.
    /// </summary>
    /// <param name="input">Sentence to parse</param>
    /// <returns>Parsed sentence</returns>
    public string Parse(string input)
    {
        // Clean input
        input = input.Trim();
        var output = string.Empty;
        while (input.Length > 0)
        {
            // Take chars until one is not a letter
            var word = input
                .TakeWhile(char.IsLetter)
                .ToArray();

            // Remove above chars from input
            input = input[word.Length..];

            // Take chars until one is a letter
            var nonLetters = input
                .TakeWhile(x => !char.IsLetter(x))
                .ToArray();

            // Remove chars accounted for from input
            input = input[nonLetters.Length..];

            // Add ParsedWord and non letters to output
            output += ParseWord(new(word));
            output += new string(nonLetters);
        }

        return output;
    }

    /// <summary>
    /// Parses a word into: first letter, number of distinct characters between first and last character, and last letter.
    /// </summary>
    /// <param name="input">Word to parse</param>
    /// <returns>Parsed word</returns>
    /// <example></example>
    private static string ParseWord(string input)
    {
        // If one letter, return that letter
        if (input.Length == 1)
            return input;

        // Takes the distinct middle chars and counts them
        var count = input
            .Skip(1)
            .Take(input.Length - 2)
            .Distinct()
            .Count();

        // Puts count in between first and last chars
        return $"{input[0]}{count}{input[^1]}";
    }
}
