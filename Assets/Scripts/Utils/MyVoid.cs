using System;

public sealed class MyVoid
{
    private MyVoid()
    {
        throw new InvalidOperationException("Don't instantiate MyVoid.");
    }
}
