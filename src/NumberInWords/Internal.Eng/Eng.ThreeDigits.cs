using System.Text;

namespace GarageGroup;

partial class NumberInWordsEng
{
    private static StringBuilder AppendThreeDigitsNumber(
        this StringBuilder textBuilder, uint threeDigitsNumber, EngWord dimensionWord, bool isEnd)
    {
        if ((threeDigitsNumber is 0) && isEnd is false)
        {
            return textBuilder;
        }

        var hundredDigit = threeDigitsNumber / InternalNumberInWords.Hundred;
        if (hundredDigit > 0)
        {
            textBuilder = textBuilder
                .AppendWithSpace(Digits[hundredDigit - 1])
                .AppendWithSpace(HundredText);
        }

        var hasHigherTriads = textBuilder.Length > 0;
        var twoDigits = (ushort)(threeDigitsNumber % InternalNumberInWords.Hundred);
        var dimensionText = GetDimensionText(threeDigitsNumber, dimensionWord, hasHigherTriads, isEnd);

        return textBuilder.AppendTwoDigits(twoDigits, isEnd).AppendWithSpace(dimensionText);
    }
}
