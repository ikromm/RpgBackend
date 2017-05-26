using UnityEngine;
using System.Collections;
using ikromm.Characters;
using SQLite4Unity3d;
using SQLiteNetExtensions.Attributes;
using System;

namespace ikromm.Requirements
{
    public class StatRequirement : IRequirement
    {
        [PrimaryKey]
        public int ID { get; set; }

        public Types Type { get; set; }

        public int Level { get; set; }

        public int StatID { get; set; }

        public float Value { get; set; }

        public bool CheckRequirements(Character character)
        {
            return character.Stats.Find(entry => entry.Stat.ID == StatID).Modifier >= Value;
        }
    }
}
