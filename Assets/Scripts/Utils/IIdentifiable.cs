namespace ikromm
{
    /// <summary>
    /// This should be implented by objects that have unique IDs in the database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIdentifiable<T>
    {
        T ID { get; }
    }
}