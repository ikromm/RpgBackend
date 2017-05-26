using UnityEngine;
using System.Collections;
using SQLiteNetExtensions.Attributes;
using ikromm.Items;

namespace ikromm.Requirements
{
    public class ItemNpcRequirement
    {
        [ForeignKey(typeof(Item))]
        public int ItemID { get; set; }

        [ForeignKey(typeof(NpcRequirement))]
        public int NpcRequirementID { get; set; }
    }
}
