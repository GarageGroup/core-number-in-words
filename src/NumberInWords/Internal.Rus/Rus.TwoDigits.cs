using System.Text;

namespace GarageGroup;

partial class NumberInWordsRus
{
    private static StringBuilder AppendTwoDigits(
        this StringBuilder textBuilder, ushort twoDigits, RusWordGender wordGender, bool isEnd)
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
            return textBuilder.AppendWithSpace(Elevens[twoDigits - InternalNumberInWords.Ten - 1]);
        }

        var highDigit = twoDigits / InternalNumberInWords.Ten;
        if (highDigit > 0)
        {
            textBuilder = textBuilder.AppendWithSpace(Tens[highDigit - 1]);
        }

        var lowDigit = twoDigits % InternalNumberInWords.Ten;
        if (lowDigit > 0)
        {
            textBuilder = textBuilder.AppendWithSpace(GetTextDigit(lowDigit, wordGender));
        }

        return textBuilder;
    }

    private static string GetDimensionText(ushort twoDigits, RusWord dimensionWord)
    {
        if (twoDigits >= InternalNumberInWords.Ten && twoDigits < InternalNumberInWords.Twenty)
        {
            return dimensionWord.GenitivePlural;
        }

        var lowDigit = twoDigits % InternalNumberInWords.Ten;
        if ((lowDigit >= 2) && (lowDigit <= 4))
        {
            return dimensionWord.GenitiveSingular;
        }

        if (lowDigit is 1)
        {
            return dimensionWord.Nominative;
        }

        return dimensionWord.GenitivePlural;
    }

    private static string GetTextDigit(int digit, RusWordGender gender)
        =>
        gender switch
        {
            RusWordGender.Feminine when digit <= FemDigits.Length  => FemDigits[digit - 1],
            RusWordGender.Neuter when digit <= NeuterDigits.Length => NeuterDigits[digit - 1],
            _ => Digits[digit - 1]
        };
}