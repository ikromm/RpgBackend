using UnityEngine;
using System.Collections;
using ikromm.Characters;

namespace ikromm
{
    [DisallowMultipleComponent]
    public class DummyParty : PersistentUnitySingleton<DummyParty>
    {
        public Character[] Party = new Character[3];

        public void Awake()
        {
            Party[0] = DbManager.Instance.Get<Character>(1);
            Party[1] = DbManager.Instance.Get<Character>(2);
            Party[2] = DbManager.Instance.Get<Character>(3);

        }


    }
}
