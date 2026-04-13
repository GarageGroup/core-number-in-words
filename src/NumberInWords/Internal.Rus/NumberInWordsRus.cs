namespace GarageGroup;

internal static partial class NumberInWordsRus
{
    private const string Minus = "минус";

    private const string ZeroText = "ноль";

    private static readonly RusWord EmptyRusWord
        =
        new(default, default, default, RusWordGender.Masculine);

    private static readonly RusWord DefaultIntWord
        =
        new("целая", "целых", "целых", RusWordGender.Feminine);

    private static readonly RusWord[] DefaultFractWords =
    [
        new("десятая", "десятые", "десятых", RusWordGender.Feminine),
        new("сотая", "сотые", "сотых", RusWordGender.Feminine),
        new("тысячная", "тысячные", "тысячных", RusWordGender.Feminine),
        new("десятитысячная", "десятитысячные", "десятитысячных", RusWordGender.Feminine),
        new("стотысячная", "стотысячные", "стотысячных", RusWordGender.Feminine),
        new("миллионная", "миллионные", "миллионных", RusWordGender.Feminine),
        new("десятимиллионная", "десятимиллионные", "десятимиллионных", RusWordGender.Feminine),
        new("стомиллионная", "стомиллионные", "стомиллионных", RusWordGender.Feminine),
        new("миллиардная", "миллиардные", "миллиардных", RusWordGender.Feminine),
        new("десятимиллиардная", "десятимиллиардные", "десятимиллиардных", RusWordGender.Feminine),
        new("стомиллиардная", "стомиллиардные", "стомиллиардных", RusWordGender.Feminine)
    ];

    private static readonly RusWord[] Words =
    [
        new("тысяча", "тысячи", "тысяч", RusWordGender.Feminine),
        new("миллион", "миллиона", "миллионов", RusWordGender.Masculine),
        new("миллиард", "миллиарда", "миллиардов", RusWordGender.Masculine),
        new("триллион", "триллиона", "триллионов", RusWordGender.Masculine),
        new("квадриллион", "квадриллиона", "квадриллионов", RusWordGender.Masculine),
        new("квинтиллион", "квинтиллиона", "квинтиллионов", RusWordGender.Masculine),
        new("секстиллион", "секстиллиона", "секстиллионов", RusWordGender.Masculine),
        new("септиллион", "септиллиона", "септиллионов", RusWordGender.Masculine),
        new("октиллион", "октиллиона", "октиллионов", RusWordGender.Masculine)
    ];

    private static readonly string[] Digits =
    [
        "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять"
    ];

    private static readonly string[] FemDigits =
    [
        "одна", "две"
    ];

    private static readonly string[] NeuterDigits =
    [
        "одно"
    ];

    private static readonly string[] Elevens =
    [
        "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать"
    ];

    private static readonly string[] Tens =
    [
        "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто"
    ];

    private static readonly string[] Hundreds =
    [
        "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот"
    ];

    private static readonly byte MaxDecimals
        =
        (byte)DefaultFractWords.Length;
}
