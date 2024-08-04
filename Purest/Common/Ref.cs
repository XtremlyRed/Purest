using System.Diagnostics;

namespace Purest;

/// <summary>
/// a <see langword="class"/> of <see cref="Ref{T}"/>
/// </summary>
[DebuggerDisplay("{value}")]
public sealed class Ref<T>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private T? value;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int interlocked;

    /// <summary>
    /// initialize a new instance of <see cref="Ref{T}"/>
    /// </summary>
    public Ref() { }

    /// <summary>
    ///  initialize a new instance of <see cref="Ref{T}"/> by <paramref name="refValue"/>
    /// </summary>
    /// <param name="refValue"></param>
    public Ref(T refValue)
    {
        this.value = refValue;
    }

    /// <summary>
    /// current value.
    /// </summary>
    public T Value
    {
        get
        {
            try
            {
                while (Interlocked.CompareExchange(ref interlocked, 1, 0) == 1) { }
                return value!;
            }
            finally
            {
                Interlocked.Exchange(ref interlocked, 0);
            }
        }
    }

    /// <summary>
    /// Swaps the specified new value.
    /// </summary>
    /// <param name="newValue">The new value.</param>
    public void Swap(T newValue)
    {
        while (Interlocked.CompareExchange(ref interlocked, 1, 0) == 1) { }

        value = newValue;

        Interlocked.Exchange(ref interlocked, 0);
    }

    /// <summary>
    /// Performs an implicit conversion from <typeparamref name="T"/> to <see cref="Ref{T}"/>.
    /// </summary>
    /// <param name="targetValue">The target value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    /// <exception cref="ArgumentNullException">targetValue</exception>
    public static implicit operator Ref<T>(T targetValue)
    {
        _ = targetValue ?? throw new ArgumentNullException(nameof(targetValue));

        return new Ref<T> { value = targetValue };
    }
}
