using UnityEngine;
using System.Collections;
using SQLite4Unity3d;

namespace ikromm.Items
{
    public class ItemEffect 
    {
        [PrimaryKey]
        public int ItemID { get; set; }

        [PrimaryKey]
        public int EffectID { get; set; }

        public float Modifier { get; set; }
    }
}
