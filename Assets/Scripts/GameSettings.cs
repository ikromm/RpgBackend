using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameSettings : ScriptableObject {

    public SDatabase Database;

    [System.Serializable]
    public struct SDatabase
    {
        public string Name;

    }

}

