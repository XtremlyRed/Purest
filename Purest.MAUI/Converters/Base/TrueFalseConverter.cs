using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace Purest.MAUI;

/// <summary>
/// a class of <see cref="TrueFalseConverter{T}"/>
/// </summary>
/// <seealso cref="IValueConverter" />

[EditorBrowsable(EditorBrowsableState.Never)]
public abstract class TrueFalseConverter<T> : ValueConverterBase<T>, IValueConverter
{
    /// <summary>
    /// true value
    /// </summary>
    public object True
    {
        get => GetValue(TrueProperty)!;
        set => SetValue(TrueProperty, value);
    }

    /// <summary>
    ///  false value
    /// </summary>
    public object False
    {
        get => GetValue(FalseProperty)!;
        set => SetValue(FalseProperty, value);
    }

    /// <summary>
    /// The true property
    /// </summary>
    private static readonly BindableProperty TrueProperty = BindableProperty.Create("True", typeof(object), typeof(TrueFalseConverter<T>), (null));

    /// <summary>
    /// The false property
    /// </summary>
    private static readonly BindableProperty FalseProperty = BindableProperty.Create("False", typeof(object), typeof(TrueFalseConverter<T>), (null));
}
