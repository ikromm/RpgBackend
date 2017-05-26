using SQLiteNetExtensions.Attributes;
using ikromm.Items;

namespace ikromm.Requirements
{
    public class ItemItemRequirement
    {
        [ForeignKey(typeof(Item))]
        public int ItemID { get; set; }

        [ForeignKey(typeof(ItemRequirement))]
        public int ItemRequirementID { get; set; }
    }
}
