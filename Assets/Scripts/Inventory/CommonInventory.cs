using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ikromm.Inventory
{
    [DisallowMultipleComponent]
    public class CommonInventory : PersistentUnitySingleton<CommonInventory>
    {
        public List<CommonInventorySlot> Slots { get; set; }

        public void Awake()
        {
            Slots = DbManager.Instance.Query<CommonInventorySlot>("select * from CommonInventory");
        }

        public void DbUpdate()
        {
            //DbManager.Update()
        }
    }
}