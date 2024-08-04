using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Purest.Validate;

/// <summary>
/// validate result
/// </summary>

[DebuggerDisplay("{MemberInfo.Name,nq} : {Result}  {Message,nq}")]
public struct ValidateResult
{
    /// <summary>
    /// validate result
    /// </summary>
    public readonly bool Result;

    /// <summary>
    /// validate fail message
    /// </summary>
    public readonly string Message;

    /// <summary>
    /// validate member
    /// </summary>
    public MemberInfo? MemberInfo { get; internal set; }

    /// <summary>
    /// initialize a new instance of <see cref="ValidateResult"/>
    /// </summary>
    /// <param name="result"></param>
    /// <param name="message"></param>
    public ValidateResult(bool result, string message)
        : this()
    {
        Result = result;
        Message = message;
    }
}
