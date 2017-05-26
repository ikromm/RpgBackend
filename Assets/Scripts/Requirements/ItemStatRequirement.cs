using UnityEngine;
using System.Collections;
using SQLiteNetExtensions.Attributes;
using ikromm.Items;

namespace ikromm.Requirements
{
    public class ItemStatRequirement
    {
        [ForeignKey(typeof(Item))]
        public int ItemID { get; set; }

        [ForeignKey(typeof(StatRequirement))]
        public int StatRequirementID { get; set; }
    }
}
