namespace ikromm
{
    /// <summary>
    /// This interface should be implemented by any class that will need the ability to lazy load relationships from the database.
    /// </summary>
    public interface IDbObject : IIdentifiable<int>
    { }
}
