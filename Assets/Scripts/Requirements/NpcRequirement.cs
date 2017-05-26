using ikromm.Characters;
using SQLite4Unity3d;
using SQLiteNetExtensions.Attributes;

namespace ikromm.Requirements
{
    public class NpcRequirement : IRequirement
    {
        [PrimaryKey]
        public int ID { get; set; }

        public Types Type { get; set; }

        public int Level { get; set; }

        [ForeignKey(typeof(NonPlayableCharacter))]
        public int NpcID { get; set; }

        public int NpcLevel { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public NonPlayableCharacter NPC { get; set; }

        public bool CheckRequirements(Character character)
        {
            return NPC.Level >= NpcLevel;
        }
    }
}
