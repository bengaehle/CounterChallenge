using System.Text.RegularExpressions;

namespace CounterChallenge;

public class Sentence
{
    private readonly string _pattern = @"[A-Za-z]+";

    public string? Input { get; set; } = String.Empty;
    public string Output { get; set; } = String.Empty;

    public Sentence(string? input)
    {
        Input = input ?? String.Empty;
    }

    public void PrintInputOutput()
    {
        Console.WriteLine();
        Console.WriteLine($"**");
        Console.WriteLine($"** Input Sentence  : {Input}");
        Console.WriteLine($"** Output Sentence : {Output}");
        Console.WriteLine($"**");
    }

    public void Manipulate()
    {
        if (String.IsNullOrWhiteSpace(Input))
        {
            Output = Input ?? String.Empty;
            return;
        }

        int currIdx = 0;

        try
        {
            MatchCollection matches = Regex.Matches(Input, _pattern);

            if (matches.Count == 0) // no matches found, so copy all non-alphabetic characters to output
            {
                Output = Input;
                return;
            }

            foreach (Match match in matches)
            {
                // Add any leading non-alphabetic characters 
                Output += Input.Substring(currIdx, match.Index - currIdx);

                string word = match.Value;

                if (match.Length < 2)
                {
                    // Append entire word since there is nothing to change
                    Output += word;
                }
                else
                {
                    // Append first letter, number of distict letters between first and last letters, and last letter
                    Output += word[0];
                    Output += CountDistinctLetters(TrimFirstLastLetters(word));
                    Output += word[match.Length - 1];
                }
                // Update our current index to where we 'left off' in our input sentence
                currIdx = match.Index + match.Length;
            }

            // Add any trailing non-alphabetic characters
            if (currIdx < Input.Length)
            {
                Output += Input.Substring(currIdx, Input.Length - currIdx);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("There was an exception while parsing this sentence, so it was not manipulated");
            Console.WriteLine($"Error: {e}");
            Output = Input;
            return;
        }
    }

    private string TrimFirstLastLetters(string inputStr)
    {
        if (inputStr.Length < 2)
            return String.Empty;

        return inputStr.Substring(1, inputStr.Length - 2); // or: inputStr[1..^1];
    }

    private string CountDistinctLetters(string inputStr)
    {
        // Count Distinct letters in this string, ignoring case
        int distinctCount = inputStr.ToLower().Distinct().Count();

        return distinctCount.ToString();
    }
}
