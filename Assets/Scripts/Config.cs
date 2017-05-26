using UnityEngine;
using System.Collections;

namespace ikromm
{
    [DisallowMultipleComponent]
    public class Config : PersistentUnitySingleton<Config>
    {

        public GameSettings Settings;

    }
}
