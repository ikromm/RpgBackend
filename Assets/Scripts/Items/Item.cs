using ikromm.Characters;
using ikromm.Requirements;
using SQLite4Unity3d;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace ikromm.Items
{
    /// <summary>
    /// The base class that contains data for all items found in the game
    /// </summary>
    public class Item : IDbObject, IEquipable, IUsable, IUpgradeable, ILoadableResources
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Name { get; set; }
        public Types Type { get; set; }
        public string Lore { get; set; }
        public int Level { get; set; }

        public float Rank { get; set; }
        public int Rarity { get; set; }
        public float Droprate { get; set; }

        public int OriginID { get; set; }

        public bool Upgradable { get; set; }
        public bool Rechargable { get; set; }
        public bool Cooldown { get; set; }
        public int Uses { get; set; }

        public float Price { get; set; }

        [ManyToMany(typeof(ItemItemRequirement))]
        public List<ItemRequirement> ItemRequirements { get; set; }
        [ManyToMany(typeof(ItemNpcRequirement))]
        public List<NpcRequirement> NpcRequirements { get; set; }
        [ManyToMany(typeof(ItemStatRequirement))]
        public List<StatRequirement> StatRequirements { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public List<ItemEffect> Effects { get; set; }

        private List<Recipe> craftedItems;
        /// <summary>
        /// A list of recipes that can be crafted by the player. May be null incase the item is not a recipe book
        /// </summary>
        [OneToMany("ItemID")]
        public List<Recipe> CraftedItems
        {
            get
            {
                if (craftedItems == null && Type == Types.Recipe)
                    this.LoadProperty("CraftedItems"); // Lazy load the property when needed to prevent db overhead

                return craftedItems;
            }
            set { craftedItems = value; }
        }

        public bool CanUse(Character character) { return checkRequirementsByType(Requirements.Types.Use, character); }
        public bool CanEquip(Character character) { return checkRequirementsByType(Requirements.Types.Equip, character); }
        public bool CanUpgrade(Character character) { return checkRequirementsByType(Requirements.Types.Upgrade, character); }
        public bool CanCraft(Character character) { return checkRequirementsByType(Requirements.Types.Craft, character); }

        private bool checkRequirementsByType(Requirements.Types type, Character character)
        {
            if (ItemRequirements == null)
            {
                this.LoadProperty("ItemRequirements");
                this.LoadProperty("NpcRequirements");
                this.LoadProperty("StatRequirements");
            }

            List<IRequirement> requirements = new List<IRequirement>();
            requirements.AddRange(ItemRequirements.Where(x => x.Level == Level).Where(x => x.Type == type).OfType<IRequirement>());
            requirements.AddRange(NpcRequirements.Where(x => x.Level == Level).Where(x => x.Type == type).OfType<IRequirement>());
            requirements.AddRange(StatRequirements.Where(x => x.Level == Level).Where(x => x.Type == type).OfType<IRequirement>());

            foreach (IRequirement item in requirements)
                if (!item.CheckRequirements(character))
                    return false;

            return true;
        }

        public override string ToString()
        {
            return string.Format("Item #{0}: {1}", ID, Name);
        }
    }
}
