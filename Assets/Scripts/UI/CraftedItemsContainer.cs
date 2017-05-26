using ikromm.Characters;
using ikromm.Inventory;
using ikromm.Items;
using System.Collections.Generic;
using UnityEngine;

namespace ikromm.Ui
{
    public class CraftedItemsContainer : MonoBehaviour
    {
        public NonPlayableCharacter NPC;
        public GameObject CraftedItemPrefab;

        private List<CraftedItem> items;

        public void Awake()
        {
            List<Item> recipeItems = new List<Item>();
            HiddenInventory.Instance.Slots
                .FindAll(x => (x.Item.Type == Items.Types.Recipe) && (x.Item.NpcRequirements.Exists(req => req.NpcID == NPC.ID)))
                .ForEach(slot => recipeItems.Add(slot.Item));

            foreach (Item item in recipeItems)
                foreach (Recipe recipe in item.CraftedItems)
                    AddItem(recipe.CraftedItem);
        }

        private void AddItem(Item item)
        {
            GameObject instance = Instantiate(CraftedItemPrefab);
            instance.transform.SetParent(transform, false);

            CraftedItem script = instance.GetComponent<CraftedItem>();
            script.Item = item;

            items.Add(script);
        }
    }
}