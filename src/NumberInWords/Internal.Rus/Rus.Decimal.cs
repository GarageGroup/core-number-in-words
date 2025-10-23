using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GarageGroup;

partial class NumberInWordsRus
{
    public static string BuildRusText(decimal number, byte decimals, RusWord? intWord, RusWord? fractWord, bool fractRequired)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(decimals, MaxDecimals, paramName: nameof(decimals));

        var intTextBuilder = new StringBuilder();
        var isPositive = number >= 0;

        if (isPositive is false)
        {
            number = -number;
        }

        var (intPart, fractPart) = SplitParts(number, decimals);

        var hasFractional = fractRequired || (decimals > 0) && (fractPart > 0);
        var dimensionsWords = GetIntDimensions(hasFractional, intWord);

        intTextBuilder = intTextBuilder.Append(intPart, dimensionsWords, true);
        if (decimals > 0)
        {
            var fractDimensionsWords = GetFractDimensions(decimals, fractWord);

            if (hasFractional)
            {
                var fractTextBuilder = new StringBuilder().Append(fractPart, fractDimensionsWords, true);
                intTextBuilder = intTextBuilder.AppendWithSpace(fractTextBuilder.ToString());
            }
        }

        var positiveText = intTextBuilder.ToString();
        return isPositive ? positiveText : $"{Minus} {positiveText}";
    }

    private static StringBuilder Append(
        this StringBuilder textBuilder, IEnumerator<uint> threeDigitNumbers, IEnumerator<RusWord> dimensionsWords, bool isEnd)
    {
        var dimensionWord = dimensionsWords.MoveNext() ? dimensionsWords.Current : EmptyRusWord;
        if (threeDigitNumbers.MoveNext() is false)
        {
            return textBuilder;
        }

        var threeDigitNumber = threeDigitNumbers.Current;
        return textBuilder.Append(threeDigitNumbers, dimensionsWords, false).AppendThreeDigitsNumber(threeDigitNumber, dimensionWord, isEnd);
    }

    private static IEnumerator<RusWord> GetIntDimensions(bool hasFractional, RusWord? intWord)
    {
        var dimensionsWords = new RusWord[Words.Length + 1];

        var word = intWord ?? EmptyRusWord;
        dimensionsWords[0] = word == EmptyRusWord && hasFractional ? DefaultIntWord : word;

        Array.Copy(Words, 0, dimensionsWords, 1, Words.Length);
        return dimensionsWords.AsEnumerable().GetEnumerator();
    }

    private static IEnumerator<RusWord> GetFractDimensions(byte decimals, RusWord? fractWord)
    {
        var fractDimensionsWords = new RusWord[Words.Length + 1];

        var word = fractWord ?? EmptyRusWord;
        fractDimensionsWords[0] = word == EmptyRusWord ? DefaultFractWords[decimals - 1] : word;

        Array.Copy(Words, 0, fractDimensionsWords, 1, Words.Length);
        return fractDimensionsWords.AsEnumerable().GetEnumerator();
    }

    private static (IEnumerator<uint> IntPart, ulong FractPart) SplitParts(decimal number, byte decimals)
    {
        var roundedNumber = number;
        if (decimals > 0)
        {
            roundedNumber = Math.Round(
                d: number,
                decimals: decimals,
                mode: MidpointRounding.ToZero);
        }

        var numberAsString = roundedNumber.ToString($"N{decimals}", CultureInfo.InvariantCulture);

        var fractionals = numberAsString.Split('.');
        var intPartAsString = fractionals[0];
        var fractPartAsString = string.Empty;
        if (fractionals.Length > 1)
        {
            fractPartAsString = fractionals[1];
        }

        var intPartsAsStrings = intPartAsString.Split(',');
        var intParts = new uint[intPartsAsStrings.Length];

        for (var i = 0; i < intPartsAsStrings.Length; i++)
        {
            intParts[intParts.Length - 1 - i] = uint.Parse(intPartsAsStrings[i]);
        }

        var fractPart = string.IsNullOrEmpty(fractPartAsString) ? 0 : ulong.Parse(fractPartAsString);
        return (intParts.AsEnumerable().GetEnumerator(), fractPart);
    }
}