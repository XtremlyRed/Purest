using System.Windows;
using Microsoft.Maui.Graphics;

namespace Purest.MAUI;

/// <summary>
/// a class of <see cref="ColorStringConverter"/>
/// </summary>
public class ColorStringConverter : MediaConverter<string, Color>
{
    /// <summary>
    /// convert from
    /// </summary>
    /// <param name="from"></param>
    /// <returns></returns>
    protected override Color ConvertFrom(string from)
    {
        if (Microsoft.Maui.Graphics.Color.TryParse(from, out var color))
        {
            return color;
        }

        return Colors.Transparent;
    }
}
