using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GarageGroup.Core.Test;

partial class NumberInWordsTest
{
    [Theory]
    [InlineData(0, 0, "zero")]
    [InlineData(0, 1, "zero")]
    [InlineData(0.0000021, 7, "zero whole twenty one ten-millionths")]
    [InlineData(0.0000021, 8, "zero whole two hundred ten hundred-millionths")]
    [InlineData(9223372036854775807, 0, "nine quintillion two hundred twenty three quadrillion three hundred seventy two trillion thirty six billion eight hundred fifty four million seven hundred seventy five thousand eight hundred seven")]
    [InlineData(18446744073709551615, 0, "eighteen quintillion four hundred forty six quadrillion seven hundred forty four trillion seventy three billion seven hundred nine million five hundred fifty one thousand six hundred fifteen")]
    [InlineData(1.0002, 4, "one whole two ten-thousandths")]
    [InlineData(9000000001, 0, "nine billion one")]
    [InlineData(7654003, 0, "seven million six hundred fifty four thousand three")]
    [InlineData(17890001011, 0, "seventeen billion eight hundred ninety million one thousand eleven")]
    [InlineData(15.03, 2, "fifteen whole three hundredths")]
    [InlineData(1.01, 2, "one whole one hundredth")]
    [InlineData(890167000002.01, 0, "eight hundred ninety billion one hundred sixty seven million two")]
    [InlineData(1000000010, 0, "one billion ten")]
    [InlineData(167008007, 0, "one hundred sixty seven million eight thousand seven")]
    [InlineData(1000000, 0, "one million")]
    [InlineData(1000, 0, "one thousand")]
    [InlineData(2007.890689108, 9, "two thousand seven whole eight hundred ninety million six hundred eighty nine thousand one hundred eight billionths")]
    [InlineData(5101, 0, "five thousand one hundred one")]
    [InlineData(-0.07, 2, "minus zero whole seven hundredths")]
    [InlineData(-17.17, 1, "minus seventeen whole one tenth")]
    [InlineData(1000000007.102, 3, "one billion seven whole one hundred two thousandths")]
    [InlineData(-1000080017.010, 2, "minus one billion eighty thousand seventeen whole one hundredth")]
    [InlineData(1000800813, 0, "one billion eight hundred thousand eight hundred thirteen")]
    [InlineData(60001501000002, 0, "sixty trillion one billion five hundred one million two")]
    [InlineData(3000030407, 0, "three billion thirty thousand four hundred seven")]
    [InlineData(1600000009, 0, "one billion six hundred million nine")]
    [InlineData(1008000515, 0, "one billion eight million five hundred fifteen")]
    [InlineData(-300, 3, "minus three hundred")]
    public void GetEnglish_DimensionIsDefault_ExpectCorrectText(decimal value, byte decimals, string expected)
    {
        var actual = NumberInWords.GetEnglish(value, decimals);
        Assert.Equal(expected: expected, actual: actual);
    }

    [Theory]
    [MemberData(nameof(GetEnglishMaxFractMemberData))]
    public void GetEnglish_MaxFractPart_ExpectCorrectText(decimal number, byte decimals, string expected)
    {
        var actual = NumberInWords.GetEnglish(number, decimals);
        Assert.Equal(expected: expected, actual: actual);
    }

    [Fact]
    public void GetEnglish_DecimalsAreTwelve_ExpectArgumentOutOfRangeException()
    {
        const byte decimals = 12;
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = NumberInWords.GetEnglish(0, decimals));

        Assert.Equal("decimals", ex.ParamName);
    }

    [Fact]
    public void GetEnglish_DecimalMaxValue_DimensionIsDefault_ExpectCorrectText()
    {
        var actual = NumberInWords.GetEnglish(decimal.MaxValue, 0);
        const string expected = "seventy nine octillion two hundred twenty eight septillion one hundred sixty two sextillion five hundred fourteen quintillion two hundred sixty four quadrillion three hundred thirty seven trillion five hundred ninety three billion five hundred forty three million nine hundred fifty thousand three hundred thirty five";

        Assert.Equal(expected: expected, actual: actual);
    }

    [Fact]
    public void GetEnglish_DecimalMinValue_DimensionIsDefault_ExpectCorrectText()
    {
        var actual = NumberInWords.GetEnglish(decimal.MinValue, 0);
        const string expected = "minus seventy nine octillion two hundred twenty eight septillion one hundred sixty two sextillion five hundred fourteen quintillion two hundred sixty four quadrillion three hundred thirty seven trillion five hundred ninety three billion five hundred forty three million nine hundred fifty thousand three hundred thirty five";

        Assert.Equal(expected: expected, actual: actual);
    }

    [Theory]
    [InlineData(0, "zero dollars zero cents")]
    [InlineData(0.1, "zero dollars ten cents")]
    [InlineData(-0.05, "minus zero dollars five cents")]
    [InlineData(1, "one dollar zero cents")]
    [InlineData(2, "two dollars zero cents")]
    [InlineData(3, "three dollars zero cents")]
    [InlineData(4, "four dollars zero cents")]
    [InlineData(-5.02, "minus five dollars two cents")]
    [InlineData(6, "six dollars zero cents")]
    [InlineData(7, "seven dollars zero cents")]
    [InlineData(8, "eight dollars zero cents")]
    [InlineData(9, "nine dollars zero cents")]
    [InlineData(-10.125, "minus ten dollars twelve cents")]
    [InlineData(11.7, "eleven dollars seventy cents")]
    [InlineData(12, "twelve dollars zero cents")]
    [InlineData(13.999, "thirteen dollars ninety nine cents")]
    [InlineData(13, "thirteen dollars zero cents")]
    [InlineData(14, "fourteen dollars zero cents")]
    [InlineData(-15.917, "minus fifteen dollars ninety one cents")]
    [InlineData(16, "sixteen dollars zero cents")]
    [InlineData(17, "seventeen dollars zero cents")]
    [InlineData(18, "eighteen dollars zero cents")]
    [InlineData(19, "nineteen dollars zero cents")]
    [InlineData(20, "twenty dollars zero cents")]
    [InlineData(40, "forty dollars zero cents")]
    [InlineData(51, "fifty one dollars zero cents")]
    [InlineData(92, "ninety two dollars zero cents")]
    [InlineData(100, "one hundred dollars zero cents")]
    [InlineData(101, "one hundred one dollars zero cents")]
    [InlineData(-102, "minus one hundred two dollars zero cents")]
    [InlineData(1000, "one thousand dollars zero cents")]
    [InlineData(2001, "two thousand one dollars zero cents")]
    [InlineData(1000000, "one million dollars zero cents")]
    [InlineData(18446744073709551615, "eighteen quintillion four hundred forty six quadrillion seven hundred forty four trillion seventy three billion seven hundred nine million five hundred fifty one thousand six hundred fifteen dollars zero cents")]
    public void GetEnglish_DimensionIsNotDefaultAndFractionalIsRequired_ExpectCorrectText(decimal value, string expected)
    {
        var dimensionWord = new EngWord("dollar", "dollars");
        var fractWord = new EngWord("cent", "cents");

        var actual = NumberInWords.GetEnglish(value, 2, dimensionWord, fractWord, true);
        Assert.Equal(expected: expected, actual: actual);
    }

    [Theory]
    [InlineData(0, "mile", "miles", "zero miles")]
    [InlineData(1, "mile", "miles", "one mile")]
    [InlineData(2, "mile", "miles", "two miles")]
    [InlineData(3, "mile", "miles", "three miles")]
    [InlineData(4, "mile", "miles", "four miles")]
    [InlineData(5, "mile", "miles", "five miles")]
    [InlineData(6, "mile", "miles", "six miles")]
    [InlineData(7, "mile", "miles", "seven miles")]
    [InlineData(8, "mile", "miles", "eight miles")]
    [InlineData(9, "mile", "miles", "nine miles")]
    [InlineData(10, "mile", "miles", "ten miles")]
    [InlineData(11, "mile", "miles", "eleven miles")]
    [InlineData(12, "mile", "miles", "twelve miles")]
    [InlineData(13, "mile", "miles", "thirteen miles")]
    [InlineData(13, "mile", EmptyString, "thirteen")]
    [InlineData(14, "mile", "miles", "fourteen miles")]
    [InlineData(15, "mile", "miles", "fifteen miles")]
    [InlineData(16, "mile", "miles", "sixteen miles")]
    [InlineData(17, "mile", "miles", "seventeen miles")]
    [InlineData(18, "mile", "miles", "eighteen miles")]
    [InlineData(19, "mile", "miles", "nineteen miles")]
    [InlineData(20, "mile", "miles", "twenty miles")]
    [InlineData(40, "mile", "miles", "forty miles")]
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
    [InlineData(18446744073709551615, "mile", "miles", "eighteen quintillion four hundred forty six quadrillion seven hundred forty four trillion seventy three billion seven hundred nine million five hundred fifty one thousand six hundred fifteen miles")]
    public void GetEnglish_DimensionWordIsCustom_ExpectCorrectText(
        decimal value, string? singular, string? plural, string expectedText)
    {
        var dimensionWord = new EngWord(
            singular: singular,
            plural: plural);

        var actual = NumberInWords.GetEnglish(value, 0, dimensionWord);
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
    public void GetEnglish_DimensionWordIsAnotherCustom_ExpectCorrectText(
        decimal value, string? singular, string? plural, string expectedText)
    {
        var dimensionWord = new EngWord(
            singular: singular,
            plural: plural);

        var actual = NumberInWords.GetEnglish(value, 0, dimensionWord);
        Assert.Equal(expected: expectedText, actual: actual);
    }
}
