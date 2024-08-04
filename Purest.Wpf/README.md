# Purest


> definition and writing of animations , converters , markup extensions in wpf xaml

##  1. animation & transition
> animation
1. BrushPropertyAnimation
1. ThicknessPropertyAnimation
1. Int32PropertyAnimation
1. DoublePropertyAnimation
1. ColorPropertyAnimation
1. Point3DPropertyAnimation
1. QuaternionPropertyAnimation
1. Rotation3DPropertyAnimation
1. VectorPropertyAnimation
1. Vector3DPropertyAnimation
1. SizePropertyAnimation

> transition
1. Fade
1. Rotate
1. ScaleX
1. ScaleY
1. SlideX
1. SlideY


``` XAML
<Window
    ...
    xmlns:purest="purest.wpf"
    ...>

    ...
    ...

    <Grid Margin="0">
       <purest:Interaction.Animations>
           <purest:BrushPropertyAnimation
               BeginTime="0:0:2"
               Property="{x:Static Grid.BackgroundProperty}"
               From="Red"
               To="Green"
               Duration="0:0:0.3" />
    
           <purest:ThicknessPropertyAnimation
               BeginTime="0:0:2"
               Property="{x:Static Grid.MarginProperty}"
               From="0"
               To="150"
               Duration="0:0:0.3" />
       </purest:Interaction.Animations>
    
       <purest:Interaction.Transitions>
           <purest:SlideX
               BeginTime="0:0:2"
               From="-200"
               Duration="0:0:0.3" />
           <purest:SlideY
               BeginTime="0:0:2"
               From="-200"
               Duration="0:0:0.3" />
           <purest:Rotate
               BeginTime="0:0:2"
               From="-360"
               Duration="0:0:0.3" />
           <purest:Fade
               BeginTime="0:0:2"
               From="1"
               Duration="0:0:1" />
       </purest:Interaction.Transitions>
    
    
       <TextBlock Width="{purest:Double 200}" />
    
    
       <Button
           Width="{Double 200}"
           Height="{Double 20}"
           Command="{purest:Method Invoke}"
           Content="click" />
    
    </Grid>

</Window>

```

##  2. converters
  
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
<Window
    ...
    xmlns:purest="purest.wpf"
    ...>
 
    <Window.Resources>
        <purest:CompositeConverter x:Key="converter">
            <purest:LengthConverter />
            <purest:CompareConverter
                Compare="{Int32 18}"
                Matched="{Double 11.11}"
                Mode="GreaterThan"
                Unmatched="{Double 600}" />
        </purest:CompositeConverter>
    </Window.Resources>

    <StackPanel>
        <TextBox x:Name="text" />
        <TextBlock
            Text="{Binding ElementName=text, Path=Text, Converter={StaticResource converter}}" />
    </StackPanel>


</Window>

```

##  3. markup extension

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
<Window
    ...
    xmlns:purest="purest.wpf"
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
</Window>
```