using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GarageGroup.Core.Test;

partial class NumberInWordsTest
{
    [Theory]
    [InlineData(0, "ноль")]
    [InlineData(1, "один")]
    [InlineData(2, "два")]
    [InlineData(4, "четыре")]
    [InlineData(5, "пять")]
    [InlineData(10, "десять")]
    [InlineData(11, "одиннадцать")]
    [InlineData(20, "двадцать")]
    [InlineData(40, "сорок")]
    [InlineData(51, "пятьдесят один")]
    [InlineData(92, "девяносто два")]
    [InlineData(100, "сто")]
    [InlineData(101, "сто один")]
    [InlineData(-102, "минус сто два")]
    [InlineData(1000, "одна тысяча")]
    [InlineData(2001, "две тысячи один")]
    [InlineData(1000000, "один миллион")]
    [InlineData(7654003, "семь миллионов шестьсот пятьдесят четыре тысячи три")]
    [InlineData(167008007, "сто шестьдесят семь миллионов восемь тысяч семь")]
    [InlineData(1000000010, "один миллиард десять")]
    [InlineData(17890001011, "семнадцать миллиардов восемьсот девяносто миллионов одна тысяча одиннадцать")]
    [InlineData(60001501000002, "шестьдесят триллионов один миллиард пятьсот один миллион два")]
    [InlineData(3000030407, "три миллиарда тридцать тысяч четыреста семь")]
    [InlineData(1600000009, "один миллиард шестьсот миллионов девять")]
    [InlineData(1008000515, "один миллиард восемь миллионов пятьсот пятнадцать")]
    [InlineData(9000000001, "девять миллиардов один")]
    [InlineData(5101, "пять тысяч сто один")]
    [InlineData(-300, "минус триста")]
    [InlineData(9223372036854775807, "девять квинтиллионов двести двадцать три квадриллиона триста семьдесят два триллиона тридцать шесть миллиардов восемьсот пятьдесят четыре миллиона семьсот семьдесят пять тысяч восемьсот семь")]
    [InlineData(-9223372036854775808, "минус девять квинтиллионов двести двадцать три квадриллиона триста семьдесят два триллиона тридцать шесть миллиардов восемьсот пятьдесят четыре миллиона семьсот семьдесят пять тысяч восемьсот восемь")]
    public void GetRussianLong_DimensionIsDefault_ExpectCorrectText(long value, string expected)
    {
        var actual = NumberInWords.GetRussian(value);
        Assert.Equal(expected: expected, actual: actual);
    }

    [Theory]
    [InlineData(0, "миля", "мили", "миль", "ноль миль")]
    [InlineData(1, "миля", "мили", "миль", "одна миля")]
    [InlineData(2, "миля", "мили", "миль", "две мили")]
    [InlineData(3, "миля", "мили", "миль", "три мили")]
    [InlineData(4, "миля", "мили", "миль", "четыре мили")]
    [InlineData(5, "миля", "мили", "миль", "пять миль")]
    [InlineData(11, "миля", "мили", "миль", "одиннадцать миль")]
    [InlineData(13, "миля", "мили", "миль", "тринадцать миль")]
    [InlineData(13, "миля", "мили", EmptyString, "тринадцать")]
    [InlineData(20, "миля", "мили", "миль", "двадцать миль")]
    [InlineData(51, "миля", "мили", "миль", "пятьдесят одна миля")]
    [InlineData(51, null, "мили", "миль", "пятьдесят одна")]
    [InlineData(92, "миля", "мили", "миль", "девяносто две мили")]
    [InlineData(92, "миля", EmptyString, "миль", "девяносто две")]
    [InlineData(100, "миля", "мили", "миль", "сто миль")]
    [InlineData(100, null, "мили", null, "сто")]
    [InlineData(101, "миля", "мили", "миль", "сто одна миля")]
    [InlineData(101, EmptyString, null, null, "сто одна")]
    [InlineData(102, "миля", "мили", "миль", "сто две мили")]
    [InlineData(1000, "миля", "мили", "миль", "одна тысяча миль")]
    [InlineData(2001, "миля", "мили", "миль", "две тысячи одна миля")]
    [InlineData(1000000, "миля", "мили", "миль", "один миллион миль")]
    [InlineData(9223372036854775807, "миля", "мили", "миль", "девять квинтиллионов двести двадцать три квадриллиона триста семьдесят два триллиона тридцать шесть миллиардов восемьсот пятьдесят четыре миллиона семьсот семьдесят пять тысяч восемьсот семь миль")]
    public void GetRussianLong_DimensionIsFeminine_ExpectCorrectText(
        long value, string? nominative, string? genitiveSingular, string? genitivePlural, string expectedText)
    {
        var dimensionWord = new RusWord(
            nominative: nominative,
            genitiveSingular: genitiveSingular,
            genitivePlural: genitivePlural,
            gender: RusWordGender.Feminine);

        var actual = NumberInWords.GetRussian(value, dimensionWord);
        Assert.Equal(expected: expectedText, actual: actual);
    }

    [Theory]
    [InlineData(0, "очко", "очка", "очков", "ноль очков")]
    [InlineData(1, "очко", "очка", "очков", "одно очко")]
    [InlineData(2, "очко", "очка", "очков", "два очка")]
    [InlineData(3, "очко", "очка", "очков", "три очка")]
    [InlineData(4, "очко", "очка", "очков", "четыре очка")]
    [InlineData(5, "очко", "очка", "очков", "пять очков")]
    [InlineData(11, "очко", "очка", "очков", "одиннадцать очков")]
    [InlineData(13, "очко", "очка", "очков", "тринадцать очков")]
    [InlineData(13, "очко", "очка", EmptyString, "тринадцать")]
    [InlineData(20, "очко", "очка", "очков", "двадцать очков")]
    [InlineData(51, "очко", "очка", "очков", "пятьдесят одно очко")]
    [InlineData(51, null, "очка", "очков", "пятьдесят одно")]
    [InlineData(92, "очко", "очка", "очков", "девяносто два очка")]
    [InlineData(92, "очко", EmptyString, "очков", "девяносто два")]
    [InlineData(100, "очко", "очка", "очков", "сто очков")]
    [InlineData(100, null, "очка", null, "сто")]
    [InlineData(101, "очко", "очка", "очков", "сто одно очко")]
    [InlineData(101, EmptyString, null, null, "сто одно")]
    [InlineData(102, "очко", "очка", "очков", "сто два очка")]
    [InlineData(1000, "очко", "очка", "очков", "одна тысяча очков")]
    [InlineData(2001, "очко", "очка", "очков", "две тысячи одно очко")]
    [InlineData(1000000, "очко", "очка", "очков", "один миллион очков")]
    [InlineData(9223372036854775807, "очко", "очка", "очков", "девять квинтиллионов двести двадцать три квадриллиона триста семьдесят два триллиона тридцать шесть миллиардов восемьсот пятьдесят четыре миллиона семьсот семьдесят пять тысяч восемьсот семь очков")]
    public void GetRussianLong_DimensionIsNeuter_ExpectCorrectText(
        long value, string? nominative, string? genitiveSingular, string? genitivePlural, string expectedText)
    {
        var dimensionWord = new RusWord(
            nominative: nominative,
            genitiveSingular: genitiveSingular,
            genitivePlural: genitivePlural,
            gender: RusWordGender.Neuter);

        var actual = NumberInWords.GetRussian(value, dimensionWord);
        Assert.Equal(expected: expectedText, actual: actual);
    }
}
