using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.BindingFlags;

namespace Purest.Validate;

/// <summary>
/// validator
/// </summary>
public static class Validator
{
    private static Type baseType = typeof(ValidateAttribute);

    /// <summary>
    /// validate object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="input"></param>
    /// <returns></returns>
    public static IEnumerable<ValidateResult> Validate<T>(T input)
        where T : class
    {
        var type = typeof(T);

        MemberInfo[] memberInfos = type.GetProperties(Public | Instance);

        var fields = type.GetFields(Public | Instance);

        if (fields is not null && fields.Length > 0)
        {
            memberInfos = memberInfos.Concat(fields).ToArray();
        }

        for (int i = 0; i < memberInfos.Length; i++)
        {
            var property = memberInfos[i];

            var attributes = property.GetCustomAttributes(true);

            for (int j = 0; j < attributes.Length; j++)
            {
                if (attributes[j] is ValidateAttribute validateAttribute)
                {
                    var value = GetValue(input, property);
                    var result = validateAttribute.Validate(value, property);

                    yield return result;
                    yield break;
                }
            }
        }
    }

    /// <summary>
    /// get member object
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="memberInfo"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    private static object? GetValue(object obj, MemberInfo memberInfo)
    {
        if (memberInfo is PropertyInfo property)
        {
            return property.GetValue(obj);
        }
        if (memberInfo is FieldInfo field)
        {
            return field.GetValue(obj);
        }

        throw new NotSupportedException("invalid member type");
    }
}
