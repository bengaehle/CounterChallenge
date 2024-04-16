using CounterChallenge;

namespace CounterChallengeTests;

[TestClass]
public class CounterChallengeTests
{
    [TestMethod]
    public void Sentence_WithEmptyInput_ReturnsEmpty()
    {
        // Arrange
        Sentence sentence = new Sentence(String.Empty);

        // Act
        sentence.Manipulate();

        // Assert
        Assert.AreEqual(String.Empty, sentence.Output);
    }

    [TestMethod]
    [DataRow("It was many and many a year ago", "I0t w1s m2y a1d m2y a y2r a1o")]
    [DataRow("Copyright,Microsoft:Corporation", "C7t,M6t:C6n")]
    [DataRow("--,,.Leading Characters", "--,,.L5g C6s")]
    [DataRow("Trailing Characters:{}", "T5g C6s:{}")]
    [DataRow("Sentence0With1Numbers2", "S4e0W2h1N5s2")]
    [DataRow("---This is.a RegEx;test  sen4tence EeeEEeeEEe. 123", "---T2s i0s.a R2x;t2t  s1n4t3e E1e. 123")]
    [DataRow("     ", "     ")] // whitespace
    public void Sentence_WithValidInput_ReturnsResult(string input, string output)
    {
        // Arrange
        Sentence sentence = new Sentence(input);

        // Act
        sentence.Manipulate();

        // Assert
        Assert.AreEqual(output, sentence.Output);
    }
}