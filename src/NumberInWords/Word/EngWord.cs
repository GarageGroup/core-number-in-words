using System.Diagnostics.CodeAnalysis;

namespace GarageGroup;

public sealed record class EngWord
{
    public EngWord(
        [AllowNull] string singular,
        [AllowNull] string plural)
    {
        Singular = singular ?? string.Empty;
        Plural = plural ?? string.Empty;
    }

    public string Singular { get; }

    public string Plural { get; }
}