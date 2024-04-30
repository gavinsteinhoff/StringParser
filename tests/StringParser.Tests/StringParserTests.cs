using StringParser.App;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;
using Xunit.Sdk;

namespace StringParser.Tests;

public class StringParserTests : TestBed<StringParserFixture>
{
    private readonly IStringParserService? _parserService;

    public StringParserTests(ITestOutputHelper testOutputHelper, StringParserFixture stringParserFixture)
        : base(testOutputHelper, stringParserFixture)
    {
        _parserService = stringParserFixture.GetService<IStringParserService>(_testOutputHelper);
    }

    [Theory]
    [InlineData("It was many and many a year ago", "I0t w1s m2y a1d m2y a y2r a1o")]
    [InlineData("Copyright,Microsoft:Corporation", "C7t,M6t:C6n")]
    public void ValidSentenceTests(string input, string desiredOutput) => Assert.Equal(_parserService?.Parse(input), desiredOutput);

    [Theory]
    [InlineData("a", "a")]
    [InlineData("aa", "a0a")]
    [InlineData("aaa", "a1a")]
    [InlineData("aaaa", "a1a")]
    [InlineData("aaba", "a2a")]
    [InlineData("aabb", "a2b")]
    [InlineData("aabcdefghijklmnopqrstuvwxyzz", "a26z")]
    public void ValidWordTests(string input, string desiredOutput) => Assert.Equal(_parserService?.Parse(input), desiredOutput);

    [Theory]
    [InlineData("aaa bbb", "a1a b1b")]
    [InlineData("aaa.bbb", "a1a.b1b")]
    [InlineData("aaa;bbb", "a1a;b1b")]
    [InlineData("aaa:bbb", "a1a:b1b")]
    [InlineData("aaa!bbb", "a1a!b1b")]
    [InlineData("aaa@bbb", "a1a@b1b")]
    [InlineData("aaa`bbb", "a1a`b1b")]
    [InlineData("aaa'bbb", "a1a'b1b")]
    [InlineData("aaa\"bbb", "a1a\"b1b")]
    public void ValidSeperatorTests(string input, string desiredOutput) => Assert.Equal(_parserService?.Parse(input), desiredOutput);
}
