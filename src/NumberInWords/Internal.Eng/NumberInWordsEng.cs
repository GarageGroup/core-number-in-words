namespace GarageGroup;

internal static partial class NumberInWordsEng
{
    private const string Minus = "minus";

    private const string ZeroText = "zero";

    private const string HundredText = "hundred";

    private static readonly EngWord EmptyEngWord
        =
        new(default, default);

    private static readonly EngWord DefaultIntWord
        =
        new("whole", "whole");

    private static readonly EngWord[] DefaultFractWords =
    [
        new("tenth", "tenths"),
        new("hundredth", "hundredths"),
        new("thousandth", "thousandths"),
        new("ten-thousandth", "ten-thousandths"),
        new("hundred-thousandth", "hundred-thousandths"),
        new("millionth", "millionths"),
        new("ten-millionth", "ten-millionths"),
        new("hundred-millionth", "hundred-millionths"),
        new("billionth", "billionths"),
        new("ten-billionth", "ten-billionths"),
        new("hundred-billionth", "hundred-billionths")
    ];

    private static readonly EngWord[] Words =
    [
        new("thousand", "thousand"),
        new("million", "million"),
        new("billion", "billion"),
        new("trillion", "trillion"),
        new("quadrillion", "quadrillion"),
        new("quintillion", "quintillion"),
        new("sextillion", "sextillion"),
        new("septillion", "septillion"),
        new("octillion", "octillion")
    ];

    private static readonly string[] Digits =
    [
        "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
    ];

    private static readonly string[] Teens =
    [
        "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
    ];

    private static readonly string[] Tens =
    [
        "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
    ];

    private static readonly byte MaxDecimals
        =
        (byte)DefaultFractWords.Length;
}
