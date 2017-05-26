using ikromm.Characters;
using ikromm.Items;
using SQLite4Unity3d;
using SQLiteNetExtensions.Attributes;

namespace ikromm.Inventory
{
    public class CommonInventorySlot
    {
        [ForeignKey(typeof(Item))]
        public int ItemID { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Item Item { get; set; }
        
        public int Quantity { get; set; }
    }
}
