using ikromm.Requirements;
using SQLite4Unity3d;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace ikromm.Castle
{
    public class Room : ILoadableResources, IDbObject
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Name { get; set; }
        public int Level { get; set; }

        [ManyToMany(typeof(RoomItemRequirement))]
        public List<ItemRequirement> LevelRequirements { get; set; }
        
    }

}