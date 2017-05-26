namespace ikromm
{
    public static class DbObjectExtensions
    {
        /// <summary>
        /// Loads a property of an object recursively.
        /// </summary>
        /// <param name="element">The objec to update.</param>
        /// <param name="propertyName">The name of property to load.</param>
        public static void LoadProperty<T>(this T element, string propertyName) where T : IDbObject
        {
            DbManager.Instance.GetChild(element, propertyName);
        }

        /// <summary>
        /// Updates the database entry of an object recursively.
        /// </summary>
        /// <param name="element">The object to update.</param>
        public static void Update<T>(this T element) where T : IDbObject
        {
            //DbManager.Instance.Update(element);
        }

        /// <summary>
        /// Inserts a database entry for the specific object recursively.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="element">The objec to update.</param>
        public static void Insert<T>(this T element) where T : IDbObject
        {
            DbManager.Instance.Insert(element);
        }

        /// <summary>
        /// Deletes the database entry from the specific object recursively.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="element">The object to delete</param>
        public static void Delete<T>(this T element) where T : IDbObject
        {
            DbManager.Instance.Delete(element);
        }
    }
}
