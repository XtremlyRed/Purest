namespace Purest.MAUI;

using System.Windows;

/// <summary>
/// a class of <see cref="BrushStringConverter"/>
/// </summary>
public class BrushStringConverter : MediaConverter<string, Brush>
{
    /// <summary>
    /// convert from
    /// </summary>
    /// <param name="from"></param>
    /// <returns></returns>
    protected override Brush ConvertFrom(string from)
    {
        if (Microsoft.Maui.Graphics.Color.TryParse(from, out var color))
        {
            return new SolidColorBrush() { Color = color };
        }

        return new SolidColorBrush() { Color = Colors.Transparent };
    }
}
