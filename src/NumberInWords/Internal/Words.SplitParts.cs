using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GarageGroup;

internal static partial class InternalNumberInWords
{
    internal static (IEnumerator<uint> IntPart, ulong FractPart) SplitParts(decimal number, byte decimals)
    {
        var roundedNumber = number;
        if (decimals > 0)
        {
            roundedNumber = Math.Round(
                d: number,
                decimals: decimals,
                mode: MidpointRounding.ToZero);
        }

        var numberAsString = roundedNumber.ToString($"N{decimals}", CultureInfo.InvariantCulture);

        var fractionals = numberAsString.Split('.');
        var intPartAsString = fractionals[0];
        var fractPartAsString = string.Empty;
        if (fractionals.Length > 1)
        {
            fractPartAsString = fractionals[1];
        }

        var intPartsAsStrings = intPartAsString.Split(',');
        var intParts = new uint[intPartsAsStrings.Length];

        for (var i = 0; i < intPartsAsStrings.Length; i++)
        {
            intParts[intParts.Length - 1 - i] = uint.Parse(intPartsAsStrings[i], CultureInfo.InvariantCulture);
        }

        var fractPart = string.IsNullOrEmpty(fractPartAsString) ? 0 : ulong.Parse(fractPartAsString, CultureInfo.InvariantCulture);
        return (intParts.AsEnumerable().GetEnumerator(), fractPart);
    }
}
