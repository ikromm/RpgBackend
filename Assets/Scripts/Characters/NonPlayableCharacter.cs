using ikromm.Items;
using ikromm.Requirements;
using SQLite4Unity3d;
using System.Collections.Generic;
using System.Linq;

namespace ikromm.Characters
{
    [Table("Npc")]
    public class NonPlayableCharacter : IIdentifiable<int>
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Name { get; set; }
        public int Level { get; set; }

        public void Craft(Character character, Item itemToCraft)
        {
            if (itemToCraft.CanCraft(character))
            {
                List<ItemRequirement> requirements = itemToCraft.ItemRequirements.Where(x => x.Type == Requirements.Types.Craft).ToList();
                foreach (ItemRequirement itemRequirement in requirements)
                    itemRequirement.Deplete(character);
            }

            character.Inventory.Add(new InventorySlot() { CharacterID = character.ID, ItemID = itemToCraft.ID, Quantity = 1 });
            character.Update();
        }
    }
}
