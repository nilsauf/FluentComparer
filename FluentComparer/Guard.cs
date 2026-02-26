namespace FluentComparer;

using System;
using System.Runtime.CompilerServices;

internal static class Guard
{
    public static void ThrowIfNull(object value, [CallerMemberName] string parameterName = "")
    {
		if (value is null)
        {
            throw new ArgumentNullException(parameterName);
        }
    }
}
