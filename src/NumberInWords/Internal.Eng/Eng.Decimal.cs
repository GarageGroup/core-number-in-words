using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageGroup;

partial class NumberInWordsEng
{
    public static string BuildEngText(decimal number, byte decimals, EngWord? intWord, EngWord? fractWord, bool fractRequired)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(decimals, MaxDecimals, paramName: nameof(decimals));

        var intTextBuilder = new StringBuilder();
        var isPositive = number >= 0;

        if (isPositive is false)
        {
            number = -number;
        }

        var (intPart, fractPart) = InternalNumberInWords.SplitParts(number, decimals);

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
        this StringBuilder textBuilder, IEnumerator<uint> threeDigitNumbers, IEnumerator<EngWord> dimensionsWords, bool isEnd)
    {
        var dimensionWord = dimensionsWords.MoveNext() ? dimensionsWords.Current : EmptyEngWord;
        if (threeDigitNumbers.MoveNext() is false)
        {
            return textBuilder;
        }

        var threeDigitNumber = threeDigitNumbers.Current;
        return textBuilder.Append(threeDigitNumbers, dimensionsWords, false).AppendThreeDigitsNumber(threeDigitNumber, dimensionWord, isEnd);
    }

    private static IEnumerator<EngWord> GetIntDimensions(bool hasFractional, EngWord? intWord)
    {
        var dimensionsWords = new EngWord[Words.Length + 1];

        var word = intWord ?? EmptyEngWord;
        dimensionsWords[0] = word == EmptyEngWord && hasFractional ? DefaultIntWord : word;

        Array.Copy(Words, 0, dimensionsWords, 1, Words.Length);
        return dimensionsWords.AsEnumerable().GetEnumerator();
    }

    private static IEnumerator<EngWord> GetFractDimensions(byte decimals, EngWord? fractWord)
    {
        var fractDimensionsWords = new EngWord[Words.Length + 1];

        var word = fractWord ?? EmptyEngWord;
        fractDimensionsWords[0] = word == EmptyEngWord ? DefaultFractWords[decimals - 1] : word;

        Array.Copy(Words, 0, fractDimensionsWords, 1, Words.Length);
        return fractDimensionsWords.AsEnumerable().GetEnumerator();
    }
}
