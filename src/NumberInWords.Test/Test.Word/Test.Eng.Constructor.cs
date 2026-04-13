using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GarageGroup.Core.Test;

partial class WordTest
{
    [Theory]
    [InlineData(EmptyString, EmptyString)]
    [InlineData(null, null)]
    [InlineData("dollar", "Dollars")]
    [InlineData(EmptyString, null)]
    [InlineData(null, "Dollars")]
    [InlineData("dollar", null)]
    [InlineData("dollar", EmptyString)]
    public void Eng_Constructor_AllFormsAreCorrect(string? singular, string? plural)
    {
        var engWord = new EngWord(
            singular: singular,
            plural: plural);

        Assert.Equal(singular ?? string.Empty, engWord.Singular);
        Assert.Equal(plural ?? string.Empty, engWord.Plural);
    }
}