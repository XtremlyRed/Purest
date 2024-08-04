using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Purest.Validate;

/// <summary>
/// a <see langword="class"/> of <see cref="ValidateAttribute"/>
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public abstract class ValidateAttribute : Attribute
{
    /// <summary>
    /// validate fail message
    /// </summary>
    public string? ValidateMessage { get; set; }

    /// <summary>
    /// inner validate
    /// </summary>
    /// <param name="input"></param>
    /// <param name="memberInfo"></param>
    /// <returns></returns>
    internal ValidateResult Validate(object? input, MemberInfo memberInfo)
    {
        var displayName =
            memberInfo.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName
            ?? memberInfo.GetCustomAttribute<DescriptionAttribute>()?.Description
            ?? memberInfo.Name;

        var validateResult = Validate(input, displayName);

        validateResult.MemberInfo = memberInfo;

        return validateResult;
    }

    /// <summary>
    /// validate
    /// </summary>
    /// <param name="input"></param>
    /// <param name="displayName"></param>
    /// <returns></returns>
    public abstract ValidateResult Validate(object? input, string displayName);
}

/// <summary>
/// a <see langword="class"/> of <see cref="ValidateAttribute{T}"/>
/// </summary>

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public abstract class ValidateAttribute<T> : ValidateAttribute
{
    /// <summary>
    /// validate
    /// </summary>
    /// <param name="input"></param>
    /// <param name="displayName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public override ValidateResult Validate(object? input, string displayName)
    {
        if (TypeConverterExtensions.TryConvertTo<T>(input, out var value) == false)
        {
            throw new ArgumentException($"input value {input} is not {typeof(T).FullName}");
        }

        return this.Validate((T)value, displayName);
    }

    /// <summary>
    /// validate
    /// </summary>
    /// <param name="input"></param>
    /// <param name="displayName"></param>
    public abstract ValidateResult Validate(T input, string displayName);
}
