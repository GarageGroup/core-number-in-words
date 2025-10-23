using System.Collections.Generic;
using System.Text;

namespace GarageGroup;

partial class NumberInWordsRus
{
    private static StringBuilder Append(
        this StringBuilder textBuilder, ulong number, IEnumerator<RusWord> dimensionsWords, bool isEnd)
    {
        var dimensionWord = dimensionsWords.MoveNext() ? dimensionsWords.Current : new(default, default, default, default);

        var threeDigitNumber = number % Thousand;
        var lostNumber = number / Thousand;

        if (lostNumber > 0)
        {
            textBuilder = textBuilder.Append(lostNumber, dimensionsWords, false);
        }
        return textBuilder.AppendThreeDigitsNumber((uint)threeDigitNumber, dimensionWord, isEnd);
    }

    private static StringBuilder AppendWithSpace(this StringBuilder textBuilder, string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return textBuilder;
        }

        if (textBuilder.Length > 0)
        {
            textBuilder = textBuilder.Append(Space);
        }

        return textBuilder.Append(text);
    }
}