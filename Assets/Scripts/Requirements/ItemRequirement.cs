using ikromm.Characters;
using ikromm.Inventory;
using ikromm.Items;
using SQLite4Unity3d;
using SQLiteNetExtensions.Attributes;

namespace ikromm.Requirements
{
    public class ItemRequirement : IRequirement
    {
        [PrimaryKey]
        public int ID { get; set; }

        public Types Type { get; set; }

        public int Level { get; set; }

        [Column("RequiredItem"), ForeignKey(typeof(Item))]
        public int RequiredItemID { get; set; }

        [OneToOne]
        public Item RequiredItem { get; set; }

        public int Quantity { get; set; }

        public bool CheckRequirements(Character character)
        {
            InventorySlot slot = character.Inventory.Find(item => item.ItemID == RequiredItemID);
            if (slot != null && slot.Quantity >= Quantity)
                return true;

            CommonInventorySlot commonSlot = CommonInventory.Instance.Slots.Find(item => item.ItemID == RequiredItemID);
            return commonSlot != null && commonSlot.Quantity >= Quantity;
        }

        public void Deplete(Character character)
        {
            InventorySlot slot = character.Inventory.Find(item => item.ItemID == RequiredItemID);
            if (slot != null)
            {
                slot.Quantity -= Quantity;
                character.Inventory.RemoveAll(x => x.Quantity == 0);
            }
            else
            {
                CommonInventorySlot commonSlot = CommonInventory.Instance.Slots.Find(item => item.ItemID == RequiredItemID);
                if (commonSlot != null)
                {
                    commonSlot.Quantity -= Quantity;
                    CommonInventory.Instance.Slots.RemoveAll(x => x.Quantity == 0);
                }
            }
        }
    }
}
