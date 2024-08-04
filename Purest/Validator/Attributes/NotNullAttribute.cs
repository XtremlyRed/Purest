using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Purest.Validate;

/// <summary>
/// not null attribute
/// </summary>
public class NotNullAttribute : ValidateAttribute
{
    /// <summary>
    /// validate member
    /// </summary>
    /// <param name="input"></param>
    /// <param name="displayName"></param>
    /// <exception cref="NotImplementedException"></exception>
    public override ValidateResult Validate(object? input, string displayName)
    {
        if (input is null)
        {
            return new ValidateResult(false, this.ValidateMessage ?? string.Format("{0} is null", displayName));
        }

        return new ValidateResult(true, "");
    }
}
