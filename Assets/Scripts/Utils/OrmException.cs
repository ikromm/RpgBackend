using System;

public class OrmException : Exception
{

    public OrmException(string message)
        : base(message)
    { }

    public OrmException(string format, params object[] obj)
        : base(string.Format(format, obj))
    { }

    public OrmException(string message, Exception innerException)
        : base(message, innerException)
    { }

    public OrmException(Exception innerException, string format, params object[] obj)
        : base(string.Format(format, obj), innerException)
    { }
}