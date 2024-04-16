using CounterChallenge;

//Console.WriteLine("Hello, World!");

class Program
{
    static void Main(string[] args)
    {
        // Loop through our program until user exits
        while (true)
        {
            Console.WriteLine("Enter sentence or phrase:");

            string? userInput = Console.ReadLine();

            // Make instance of class to then manipulate sentence and print output
            Sentence inputSentence = new Sentence(userInput);

            inputSentence.Manipulate();

            inputSentence.PrintInputOutput();

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}