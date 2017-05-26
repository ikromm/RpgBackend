using ikromm.Castle;
using SQLite4Unity3d;
using SQLiteNetExtensions.Attributes;

namespace ikromm.Requirements
{
    public class RoomItemRequirement
    {
        [ForeignKey(typeof(Room))]
        public int RoomID { get; set; }

        [PrimaryKey]
        public int Level { get; set; }

        [ForeignKey(typeof(ItemRequirement))]
        public int ItemRequirementID { get; set; }
    }
}
