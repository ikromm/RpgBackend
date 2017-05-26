using UnityEngine;
using System.Collections;
using SQLite4Unity3d;
using SQLiteNetExtensions.Attributes;
using ikromm.Items;

namespace ikromm.Characters
{
    [Table("Inventory")]
    public class InventorySlot 
    {
        [ForeignKey(typeof(Item))]
        public int ItemID { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Item Item { get; set; }

        [ForeignKey(typeof(Character))]
        public int CharacterID { get; set; }

        public int Quantity { get; set; }
    }

}
