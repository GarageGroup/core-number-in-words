using System.Collections.Generic;
using System.Text;

namespace GarageGroup;

partial class NumberInWordsRus
{
    public static string BuildRusText(long number, RusWord? intWord)
    {
        var intTextBuilder = new StringBuilder();
        var isPositive = number >= 0;

        var unsignedNumber = GetAbsValue(number);
        var dimensionsWords = GetIntDimensions(hasFractional: false, intWord: intWord);

        var positiveText = intTextBuilder
            .Append(unsignedNumber, dimensionsWords, true)
            .ToString();

        return isPositive ? positiveText : $"{Minus} {positiveText}";
    }

    private static ulong GetAbsValue(long number)
    {
        if (number >= 0)
        {
            return (ulong)number;
        }

        var abs = -(number + 1);
        return (ulong)abs + 1UL;
    }

    private static StringBuilder Append(
        this StringBuilder textBuilder, ulong number, IEnumerator<RusWord> dimensionsWords, bool isEnd)
    {
        var dimensionWord = dimensionsWords.MoveNext() ? dimensionsWords.Current : new(default, default, default, default);

        var threeDigitNumber = number % InternalNumberInWords.Thousand;
        var lostNumber = number / InternalNumberInWords.Thousand;

        if (lostNumber > 0)
        {
            textBuilder = textBuilder.Append(lostNumber, dimensionsWords, false);
        }
        return textBuilder.AppendThreeDigitsNumber((uint)threeDigitNumber, dimensionWord, isEnd);
    }
}
