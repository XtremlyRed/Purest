using System.Collections;

namespace Purest.Validate;

/// <summary>
/// input length attribute
/// </summary>
public class LengthAttribute : ValidateAttribute<IEnumerable>
{
    /// <summary>
    /// initialize a new instance of <see cref="LengthAttribute"/>
    /// </summary>
    public LengthAttribute() { }

    /// <summary>
    /// initialize a new instance of <see cref="LengthAttribute"/>
    /// </summary>
    public LengthAttribute(int maxLength, int minLength = 0)
    {
        this.MaxLength = maxLength;
        this.MinLength = minLength;
    }

    /// <summary>
    /// max length
    /// </summary>
    public int MaxLength { get; set; }

    /// <summary>
    /// min length
    /// </summary>
    public int MinLength { get; set; }

    /// <summary>
    /// validate member
    /// </summary>
    /// <param name="input"></param>
    /// <param name="displayName"></param>
    /// <exception cref="NotImplementedException"></exception>
    public override ValidateResult Validate(IEnumerable input, string displayName)
    {
        int count = 0;

        if (input is Array array)
        {
            count = array.Length;
        }
        else if (input is IList list)
        {
            count = list.Count;
        }
        else if (input is ICollection collection)
        {
            count = collection.Count;
        }
        else
        {
            foreach (var item in input)
            {
                count++;
            }
        }

        if (count < MinLength || count > MaxLength)
        {
            var msg = string.Format("The length of {0} is not within the range of ({1},{2})", displayName, MinLength, MaxLength);
            return new ValidateResult(false, this.ValidateMessage ?? msg);
        }

        return new ValidateResult(true, "");
    }
}
