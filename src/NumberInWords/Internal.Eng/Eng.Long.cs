using System.Collections.Generic;
using System.Text;

namespace GarageGroup;

partial class NumberInWordsEng
{
    private static StringBuilder Append(
        this StringBuilder textBuilder, ulong number, IEnumerator<EngWord> dimensionsWords, bool isEnd)
    {
        var dimensionWord = dimensionsWords.MoveNext() ? dimensionsWords.Current : new(default, default);

        var threeDigitNumber = number % InternalNumberInWords.Thousand;
        var lostNumber = number / InternalNumberInWords.Thousand;

        if (lostNumber > 0)
        {
            textBuilder = textBuilder.Append(lostNumber, dimensionsWords, false);
        }

        return textBuilder.AppendThreeDigitsNumber((uint)threeDigitNumber, dimensionWord, isEnd);
    }
}
