using SQLite4Unity3d;
using SQLiteNetExtensions.Attributes;

namespace ikromm.Items
{
    /// <summary>
    /// Recipes contain the relations between recipe books and items that can be produced by them.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// The recipe's item ID on the database
        /// </summary>
        [PrimaryKey]
        public int ItemID { get; set; }
        
        /// <summary>
        /// The produced item's ID on the database
        /// </summary>
        public int CraftedItemID { get; set; }
        
        /// <summary>
        /// The produced item
        /// </summary>
        [OneToOne("CraftedItemID")]
        public Item CraftedItem { get; set; }
        
    }
}