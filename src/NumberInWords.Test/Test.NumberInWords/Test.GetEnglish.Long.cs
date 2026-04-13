using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GarageGroup.Core.Test;

partial class NumberInWordsTest
{
    [Theory]
    [InlineData(0, "zero")]
    [InlineData(1, "one")]
    [InlineData(2, "two")]
    [InlineData(4, "four")]
    [InlineData(5, "five")]
    [InlineData(10, "ten")]
    [InlineData(11, "eleven")]
    [InlineData(20, "twenty")]
    [InlineData(40, "forty")]
    [InlineData(51, "fifty one")]
    [InlineData(92, "ninety two")]
    [InlineData(100, "one hundred")]
    [InlineData(101, "one hundred one")]
    [InlineData(-102, "minus one hundred two")]
    [InlineData(1000, "one thousand")]
    [InlineData(2001, "two thousand one")]
    [InlineData(1000000, "one million")]
    [InlineData(7654003, "seven million six hundred fifty four thousand three")]
    [InlineData(167008007, "one hundred sixty seven million eight thousand seven")]
    [InlineData(1000000010, "one billion ten")]
    [InlineData(17890001011, "seventeen billion eight hundred ninety million one thousand eleven")]
    [InlineData(60001501000002, "sixty trillion one billion five hundred one million two")]
    [InlineData(3000030407, "three billion thirty thousand four hundred seven")]
    [InlineData(1600000009, "one billion six hundred million nine")]
    [InlineData(1008000515, "one billion eight million five hundred fifteen")]
    [InlineData(9000000001, "nine billion one")]
    [InlineData(5101, "five thousand one hundred one")]
    [InlineData(-300, "minus three hundred")]
    [InlineData(9223372036854775807, "nine quintillion two hundred twenty three quadrillion three hundred seventy two trillion thirty six billion eight hundred fifty four million seven hundred seventy five thousand eight hundred seven")]
    [InlineData(-9223372036854775808, "minus nine quintillion two hundred twenty three quadrillion three hundred seventy two trillion thirty six billion eight hundred fifty four million seven hundred seventy five thousand eight hundred eight")]
    public void GetEnglishLong_DimensionIsDefault_ExpectCorrectText(long value, string expected)
    {
        var actual = NumberInWords.GetEnglish(value);
        Assert.Equal(expected: expected, actual: actual);
    }

    [Theory]
    [InlineData(0, "mile", "miles", "zero miles")]
    [InlineData(1, "mile", "miles", "one mile")]
    [InlineData(2, "mile", "miles", "two miles")]
    [InlineData(3, "mile", "miles", "three miles")]
    [InlineData(4, "mile", "miles", "four miles")]
    [InlineData(5, "mile", "miles", "five miles")]
    [InlineData(11, "mile", "miles", "eleven miles")]
    [InlineData(13, "mile", "miles", "thirteen miles")]
    [InlineData(13, "mile", EmptyString, "thirteen")]
    [InlineData(20, "mile", "miles", "twenty miles")]
    [InlineData(51, "mile", "miles", "fifty one miles")]
    [InlineData(51, null, "miles", "fifty one miles")]
    [InlineData(92, "mile", "miles", "ninety two miles")]
    [InlineData(92, "mile", EmptyString, "ninety two")]
    [InlineData(100, "mile", "miles", "one hundred miles")]
    [InlineData(100, "mile", null, "one hundred")]
    [InlineData(101, "mile", "miles", "one hundred one miles")]
    [InlineData(101, EmptyString, null, "one hundred one")]
    [InlineData(102, "mile", "miles", "one hundred two miles")]
    [InlineData(1000, "mile", "miles", "one thousand miles")]
    [InlineData(2001, "mile", "miles", "two thousand one miles")]
    [InlineData(1000000, "mile", "miles", "one million miles")]
    [InlineData(9223372036854775807, "mile", "miles", "nine quintillion two hundred twenty three quadrillion three hundred seventy two trillion thirty six billion eight hundred fifty four million seven hundred seventy five thousand eight hundred seven miles")]
    public void GetEnglishLong_DimensionWordIsCustom_ExpectCorrectText(
        long value, string? singular, string? plural, string expectedText)
    {
        var dimensionWord = new EngWord(
            singular: singular,
            plural: plural);

        var actual = NumberInWords.GetEnglish(value, dimensionWord);
        Assert.Equal(expected: expectedText, actual: actual);
    }

    [Theory]
    [InlineData(0, "point", "points", "zero points")]
    [InlineData(1, "point", "points", "one point")]
    [InlineData(2, "point", "points", "two points")]
    [InlineData(13, "point", "points", "thirteen points")]
    [InlineData(13, "point", EmptyString, "thirteen")]
    [InlineData(51, "point", "points", "fifty one points")]
    [InlineData(51, null, "points", "fifty one points")]
    [InlineData(100, "point", "points", "one hundred points")]
    [InlineData(100, "point", null, "one hundred")]
    [InlineData(101, "point", "points", "one hundred one points")]
    [InlineData(101, EmptyString, null, "one hundred one")]
    [InlineData(9223372036854775807, "point", "points", "nine quintillion two hundred twenty three quadrillion three hundred seventy two trillion thirty six billion eight hundred fifty four million seven hundred seventy five thousand eight hundred seven points")]
    public void GetEnglishLong_DimensionWordIsAnotherCustom_ExpectCorrectText(
        long value, string? singular, string? plural, string expectedText)
    {
        var dimensionWord = new EngWord(
            singular: singular,
            plural: plural);

        var actual = NumberInWords.GetEnglish(value, dimensionWord);
        Assert.Equal(expected: expectedText, actual: actual);
    }
}
