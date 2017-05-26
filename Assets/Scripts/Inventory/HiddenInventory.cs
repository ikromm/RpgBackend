using System.Collections.Generic;
using UnityEngine;

namespace ikromm.Inventory
{
    [DisallowMultipleComponent]
    public class HiddenInventory : PersistentUnitySingleton<HiddenInventory>
    {
        public List<CommonInventorySlot> Slots { get; set; }

        public void Awake()
        {
            Slots = DbManager.Instance.Query<CommonInventorySlot>("select * from HiddenInventory");
        }

        public void DbUpdate()
        {
            //DbManager.Update()
        }
    }
}