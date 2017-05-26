using UnityEngine;
using System.Collections;
using SQLite4Unity3d;
using SQLiteNetExtensions.Attributes;

namespace ikromm.Characters
{
    public class CharacterStat
    {
        [ForeignKey(typeof(Character))]
        public int CharacterID { get; set; }

        [ForeignKey(typeof(Stat))]
        public int StatID { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Stat Stat { get; set; }

        public float Modifier { get; set; }
        public float Bonus { get; set; }
    }
}
