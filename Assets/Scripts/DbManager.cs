using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;
using SQLiteNetExtensions.Extensions;

namespace ikromm
{
    [DisallowMultipleComponent]
    public class DbManager : PersistentUnitySingleton<DbManager>
    {
        private string dbPath;
        private SQLiteConnection connection;

        public void Awake()
        {
            dbPath = getDbPath(Config.Instance.Settings.Database.Name);
            Debug.LogFormat("Database path: {0}", dbPath);

            connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite);
        }

        private string getDbPath(string DatabaseName)
        {

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/{0}", DatabaseName);
#else
        // check if file exists in Application.dataPath
        var filepath = string.Format("{0}/{1}", Application.dataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.LogFormat("Database not in data path ({0})", filepath);
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif

            return dbPath;
        }

        /// <summary>
        /// Loads the requested object from the database. 
        /// This method will load all property fields that are marked with CascadeRead.
        /// </summary>
        /// <typeparam name="T">The type to cast the returned object to.</typeparam>
        /// <param name="id">The id of the object to fetch from the database.</param>
        /// <returns>The requested object of the defined type.</returns>
        public T Get<T>(int id) where T : class, new()
        {
            return connection.GetWithChildren<T>(id, true);
        }

        /// <summary>
        /// Loads a property field of an object.
        /// This method will recursively load data of all objects that are marked with CascadeRead.
        /// </summary>
        /// <typeparam name="T">The type of the property to cast the result to.</typeparam>
        /// <param name="element">The object whose property you want loaded.</param>
        /// <param name="property">The name of the property to load.</param>
        public void GetChild<T>(T element, string property)
        {
            connection.GetChild<T>(element, property, true);
        }

        /// <summary>
        /// Updates the database entry of an object.
        /// This method will recursively update all property fields that are marked with CascadeWrite.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="element">The object to update.</param>
        //public void Update<T>(T element)
        //{
        //    connection.UpdateWithChildren(element);
        //}

        /// <summary>
        /// Deletes an object entry from the database.
        /// This method will recursively delete all database entries of fields that are marked with CascadeDelete.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="element">The object to delete.</param>
        public void Delete<T>(T element) where T : IIdentifiable<int>
        {
            connection.Delete(element.ID, true);
        }

        /// <summary>
        /// Inserts an object into the database.
        /// This method will recursively insert entries for the fields that are marked with CascadeInsert,
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="element">The object to insert.</param>
        public void Insert<T>(T element)
        {
            connection.InsertWithChildren(element, true);
        }

        /// <summary>
        /// Get a list of the results from the database after casting them to the specified type
        /// </summary>
        /// <typeparam name="T">The type to cast each database row to.</typeparam>
        /// <param name="query">The query to run on the database.</param>
        /// <param name="args">Any additional arguments from the query.</param>
        /// <returns></returns>
        public List<T> Query<T>(string query, params object[] args) where T : class, new()
        {
            return connection.Query<T>(query, args);
        }

    }
}
