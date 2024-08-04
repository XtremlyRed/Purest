# Purest


> definition and writing of animations , converters , markup extensions in maui xaml


##  1. converters
  
1. BooleanReverseConverter  
1. BooleanToVisibilityConverter  
2. BooleanToVisibilityReverseConverter  
2. ColorStringConverter
2. BrushStringConverter
2. LengthConverter
2. NullOrEmptyConverter
2. NotNullOrEmptyConverter
2. NullOrWhiteSpaceConverter
2. NotNullOrWhiteSpaceConverter
2. NullConverter
2. NotNullConverter
2. CompositeConverter


``` XAML
<UserControl
    ...
    xmlns:purest="purest.maui"
    ...>
 
    <UserControl.Resources>
        <purest:CompositeConverter x:Key="converter">
            <purest:LengthConverter />
            <purest:CompareConverter
                Compare="{Int32 18}"
                Matched="{Double 11.11}"
                Mode="GreaterThan"
                Unmatched="{Double 600}" />
        </purest:CompositeConverter>
    </UserControl.Resources>

    <StackPanelLayout>
        <TextBox x:Name="text" />
        <TextBlock
            Text="{Binding ElementName=text, Path=Text, Converter={StaticResource converter}}" />
    </StackPanelLayout>


</UserControl>

```

##  2. markup extension

1. CharExtension
1. DecimalExtension
1. BooleanExtension
1. StringExtension
1. SByteExtension
1. ByteExtension
1. DoubleExtension
1. SingleExtension
1. UInt64Extension
1. Int64Extension
1. UInt16Extension
1. Int16Extension
1. UInt32Extension
1. Int32Extension
1. ColorExtension
1. SolidColorBrushExtension

``` XAML
<UserControl
    ...
    xmlns:purest="purest.maui"
    ...>
    
    ...
    ...

    <Border
        Width="{purest:Double 200}"
        Height="{purest:Int16 32}"
        Background="{purest:SolidColorBrush Color=Red,
                                     Opacity=0.3}">
        <Border.Tag>
            <purest:String>display_string</purest:String>
        </Border.Tag>
    </Border>
</UserControl>
```