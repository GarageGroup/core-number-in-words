using System.Text;

namespace GarageGroup;

partial class NumberInWordsRus
{
    private static StringBuilder AppendThreeDigitsNumber(
        this StringBuilder textBuilder, uint threeDigitsNumber, RusWord dimensionWord, bool isEnd)
    {
        if ((threeDigitsNumber is 0) && isEnd is false)
        {
            return textBuilder;
        }

        var hundredDigit = threeDigitsNumber / Hundred;
        if (hundredDigit > 0)
        {
            textBuilder.AppendWithSpace(Hundreds[hundredDigit - 1]);
        }

        var twoDigitNumber = (ushort)(threeDigitsNumber % Hundred);
        var dimensionText = GetDimensionText(twoDigitNumber, dimensionWord);

        return textBuilder.AppendTwoDigits(twoDigitNumber, dimensionWord.Gender, isEnd).AppendWithSpace(dimensionText);
    }
}