using Xunit;

namespace GarageGroup.Core.Test;

public sealed partial class NumberInWordsTest
{
    private static readonly string[] FractExpectedValues
        =
        [
            "десятая",
            "сотая",
            "тысячная",
            "десятитысячная",
            "стотысячная",
            "миллионная",
            "десятимиллионная",
            "стомиллионная",
            "миллиардная",
            "десятимиллиардная",
            "стомиллиардная"
        ];

    public static TheoryData<decimal, byte, string> GetMaxFractMemberData()
    {
        var data = new TheoryData<decimal, byte, string>();
        var number = 1m;

        for (var i = 0; i < FractExpectedValues.Length; i++)
        {
            number *= 0.1m;
            data.Add(number, (byte)(i + 1), $"ноль целых одна {FractExpectedValues[i]}");
        }

        return data;
    }
}