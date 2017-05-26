using UnityEngine;
using System.Collections;
using SQLite4Unity3d;
using SQLiteNetExtensions.Attributes;

namespace ikromm.Characters
{
    public class CharacterSkill
    {
        [ForeignKey(typeof(Character))]
        public int CharacterID { get; set; }

        [ForeignKey(typeof(Skill))]
        public int SkillID { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Skill Skill { get; set; }
        
        public float Rank { get; set; }
        public float Bonus { get; set; }
    }
}
