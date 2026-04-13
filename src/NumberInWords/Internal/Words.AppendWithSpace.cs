using System.Text;

namespace GarageGroup;

internal static partial class InternalNumberInWords
{
    internal static StringBuilder AppendWithSpace(this StringBuilder textBuilder, string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return textBuilder;
        }

        if (textBuilder.Length > 0)
        {
            textBuilder = textBuilder.Append(' ');
        }

        return textBuilder.Append(text);
    }
}
