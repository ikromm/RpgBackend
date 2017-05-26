using SQLite4Unity3d;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace ikromm.Characters
{
    public class Character : ILoadableResources, IDbObject
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Name { get; set; }
        public int Level { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead | CascadeOperation.CascadeInsert)]
        public List<CharacterStat> Stats { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead | CascadeOperation.CascadeInsert)]
        public List<CharacterSkill> Skills { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead | CascadeOperation.CascadeInsert)]
        public List<InventorySlot> Inventory { get; set; }

        //[OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        //public List<HiddenInventorySlot> HiddenInventory { get; set; }

        public InventorySlot this[int i] { get { return Inventory[i]; } }
        public CharacterStat this[Stats stat] { get { return Stats.Find(x => x.Stat.Name == stat.ToString()); } }
        public CharacterSkill this[Skills skill] { get { return Skills.Find(x => x.Skill.Name == skill.ToString()); } }

        public override string ToString()
        {
            return string.Format("Character #{0}: {1}", ID, Name);
        }
    }
}
