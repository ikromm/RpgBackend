using UnityEngine;
using UnityEngine.UI;
using ikromm.Items;

namespace ikromm.Ui
{
    public class CraftedItem : MonoBehaviour
    {
        public Item Item { get; set; }

        [Header("Containers")]
        public Image Icon;
        public Text Name;
        public Text Lore;
        public CraftingPrerequisitesContainer CraftingPrerequisites;

        public void Start()
        {
            CraftingPrerequisites.CraftedItem = Item;
            Icon.sprite = Item.LoadResource<Sprite>(ResourcePaths.Items, ResourcePostfixes.Icon);
            Name.text = Item.Name;
            Lore.text = Item.Lore;
        }
    }
}