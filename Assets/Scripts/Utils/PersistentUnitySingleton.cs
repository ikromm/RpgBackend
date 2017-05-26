using UnityEngine;

/// <summary>
/// Careful when using this class. If you want fields defined on runtime, the corresponding class 
/// should be defined on a GameObject already appearing on the scene. If not, an object will be 
/// created automatically.
/// </summary>
/// <typeparam name="T">The Monobehaviour to wrap</typeparam>
public class PersistentUnitySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static object _lock = new object();

    protected PersistentUnitySingleton() { }

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarningFormat("[Singleton] Instance '{0}' already destroyed on application quit. Won't create again - returning null.", typeof(T));
                return null;
            }

            lock (_lock)
            {
                if (_instance == null)
                {
                    Object[] instances = FindObjectsOfType(typeof(T));

                    if (instances.Length > 1)
                    {
                        Debug.LogError("[Singleton] Something went really wrong - there should never be more than 1 singleton! Reopening the scene might fix it.");
                        return _instance;
                    }

                    if (instances.Length == 0)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton) " + typeof(T).ToString();

                        DontDestroyOnLoad(singleton);

                        Debug.LogFormat("[Singleton] An instance of {0} is needed in the scene, so '{1}' was created with DontDestroyOnLoad.", typeof(T), singleton);
                    }
                    else
                    {
                        _instance = (T)instances[0];
                        Debug.LogFormat("[Singleton] Using instance already created: {0}", _instance.gameObject.name);
                    }
                }

                return _instance;
            }
        }
    }

    private static bool applicationIsQuitting = false;
    /// <summary>
    /// When Unity quits, it destroys objects in a random order.
    /// In principle, a Singleton is only destroyed when application quits.
    /// If any script calls Instance after it have been destroyed, 
    ///   it will create a buggy ghost object that will stay on the Editor scene
    ///   even after stopping playing the Application. Really bad!
    /// So, this was made to be sure we're not creating that buggy ghost object.
    /// </summary>
    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}
