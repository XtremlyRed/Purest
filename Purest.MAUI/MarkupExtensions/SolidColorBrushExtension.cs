using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Purest.MAUI;

/// <summary>
/// a class of <see cref="SolidColorBrushExtension"/>
/// </summary>
public class SolidColorBrushExtension : IMarkupExtension
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SolidColorBrushExtension"/> class.
    /// </summary>
    public SolidColorBrushExtension() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SolidColorBrushExtension"/> class.
    /// </summary>
    /// <param name="color">The color.</param>
    public SolidColorBrushExtension(Color color)
    {
        Color = color;
    }

    /// <summary>
    /// color.
    /// </summary>
    public Color? Color { get; set; }

    /// <summary>
    /// provide value
    /// </summary>
    /// <param name="serviceProvider"> </param>
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return new SolidColorBrush(Color);
    }
}
