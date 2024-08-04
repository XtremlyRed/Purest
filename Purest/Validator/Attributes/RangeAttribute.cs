namespace Purest.Validate;

/// <summary>
/// a <see langword="class"/> of <see cref="RangeAttribute"/>
/// </summary>
public class RangeAttribute : ValidateAttribute<double>
{
    /// <summary>
    /// initialize a new instance of <see cref="RangeAttribute"/>
    /// </summary>
    public RangeAttribute() { }

    /// <summary>
    /// initialize a new instance of <see cref="RangeAttribute"/>
    /// </summary>
    public RangeAttribute(double minValue = double.MinValue, double maxValue = double.MaxValue)
    {
        this.MaxValue = maxValue;
        this.MinValue = minValue;
    }

    /// <summary>
    /// initialize a new instance of <see cref="RangeAttribute"/>
    /// </summary>
    public RangeAttribute(double maxValue = double.MaxValue)
    {
        this.MaxValue = maxValue;
        this.MinValue = 0;
    }

    /// <summary>
    /// max value
    /// </summary>
    public double MaxValue { get; set; }

    /// <summary>
    /// min value
    /// </summary>
    public double MinValue { get; set; }

    /// <summary>
    /// validate
    /// </summary>
    /// <param name="input"></param>
    /// <param name="displayName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public override ValidateResult Validate(object? input, string displayName)
    {
        if (MathExtensions.IsNumber(input, out var doubleValue) == false)
        {
            throw new ArgumentException($"input value {input} is not number");
        }
        if (doubleValue < MinValue || doubleValue > MaxValue)
        {
            var msg = string.Format("The value of {0} is not within the range of ( {1} , {2} )", displayName, MinValue, MaxValue);
            return new ValidateResult(false, this.ValidateMessage ?? msg);
        }

        return new ValidateResult(true, "");
    }

    /// <summary>
    /// validate
    /// </summary>
    /// <param name="input"></param>
    /// <param name="displayName"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override ValidateResult Validate(double input, string displayName)
    {
        throw new NotImplementedException();
    }
}
