using System.Text;

namespace GarageGroup;

partial class NumberInWordsEng
{
    private static StringBuilder AppendTwoDigits(this StringBuilder textBuilder, ushort twoDigits, bool isEnd)
    {
        if (twoDigits is 0)
        {
            if (isEnd && textBuilder.Length is 0)
            {
                textBuilder = textBuilder.Append(ZeroText);
            }

            return textBuilder;
        }

        if ((twoDigits > InternalNumberInWords.Ten) && (twoDigits < InternalNumberInWords.Twenty))
        {
            return textBuilder.AppendWithSpace(Teens[twoDigits - InternalNumberInWords.Ten - 1]);
        }

        var highDigit = twoDigits / InternalNumberInWords.Ten;
        if (highDigit > 0)
        {
            textBuilder = textBuilder.AppendWithSpace(Tens[highDigit - 1]);
        }

        var lowDigit = twoDigits % InternalNumberInWords.Ten;
        if (lowDigit > 0)
        {
            textBuilder = textBuilder.AppendWithSpace(Digits[lowDigit - 1]);
        }

        return textBuilder;
    }

    private static string GetDimensionText(uint threeDigits, EngWord dimensionWord, bool hasHigherTriads, bool isEnd)
    {
        if (threeDigits is 1)
        {
            if (isEnd && hasHigherTriads)
            {
                return dimensionWord.Plural;
            }

            return dimensionWord.Singular;
        }

        return dimensionWord.Plural;
    }
}
