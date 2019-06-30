using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public static class TimeSpanExt
{
    public static TaskAwaiter GetAwaiter( this TimeSpan self )
    {
        return Task.Delay( self ).GetAwaiter();
    }
}
