using UnityEngine;
using System.Collections;
using SQLite4Unity3d;

namespace ikromm.Characters
{
    public class Skill
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Name { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public Types Type { get; set; }
        public int Ranks { get; set; }
        public int Cooldown { get; set; }

        public Skills ToEnum() { return (Skills)System.Enum.Parse(typeof(Skills), Name); }
    }

    public enum Skills
    {

    }

    public enum Category
    {

    }

    public enum Types
    {
        Active,
        Passive
    }
}
