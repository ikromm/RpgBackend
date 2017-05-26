using ikromm.Characters;
using ikromm.Items;
using ikromm.Requirements;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ikromm.Ui
{
    public class CraftingPrerequisitesContainer : MonoBehaviour
    {
        public Item CraftedItem { get; set; }
        public Character Character { get; set; }

        public GameObject PrerequisitePrefab;

        private List<CraftingPrerequisite> craftingPrerequisites;

        [Header("Containers")]
        public Transform ItemList;
        public Text GoldAmount;
        public Text EthershardsAmount;

        public void Start()
        {
            craftingPrerequisites = new List<CraftingPrerequisite>(CraftedItem.ItemRequirements.Count);

            foreach (ItemRequirement requirement in CraftedItem.ItemRequirements)
                AddPrerequisite(requirement);
        }

        public void AddPrerequisite(ItemRequirement requirement)
        {
            GameObject instance = Instantiate(PrerequisitePrefab);
            instance.name = requirement.RequiredItem.Name;
            instance.transform.SetParent(ItemList, false);

            CraftingPrerequisite script = instance.GetComponent<CraftingPrerequisite>();
            script.Character = Character;
            script.Requirement = requirement;

            craftingPrerequisites.Add(script);
        }
    }
}