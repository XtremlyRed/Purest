global using System;
global using System.Linq;
global using BF = System.Reflection.BindingFlags;
global using Button = Microsoft.Maui.Controls.Button;
global using Color = Microsoft.Maui.Graphics.Color;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Markup;
using XmlnsPrefixAttribute = Microsoft.Maui.Controls.XmlnsPrefixAttribute;

[assembly: XmlnsDefinition("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Purest.MAUI")]
[assembly: XmlnsDefinition("purest.maui", "Purest.MAUI")]
[assembly: XmlnsPrefix("purest.maui", "purest")]

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit { }
}
