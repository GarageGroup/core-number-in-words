namespace GarageGroup;

public static class NumberInWords
{
    public static string GetRussian(
        decimal number,
        byte decimals,
        RusWord? integerWord = default,
        RusWord? fractionalWord = default,
        bool isFractionalRequired = false)
        =>
        NumberInWordsRus.BuildRusText(number, decimals, integerWord, fractionalWord, isFractionalRequired);

    public static string GetEnglish(
        decimal number,
        byte decimals,
        EngWord? integerWord = default,
        EngWord? fractionalWord = default,
        bool isFractionalRequired = false)
        =>
        NumberInWordsEng.BuildEngText(number, decimals, integerWord, fractionalWord, isFractionalRequired);
}
