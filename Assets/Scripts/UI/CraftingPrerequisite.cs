using ikromm.Characters;
using ikromm.Requirements;
using UnityEngine;
using UnityEngine.UI;

namespace ikromm.Ui
{
    [RequireComponent(typeof(Image))]
    public class CraftingPrerequisite : MonoBehaviour
    {
        public ItemRequirement Requirement { get; set; }
        public Character Character { get; set; }

        public Sprite MissingRequirementBackground;
        public Sprite PassedRequirementBackground;

        [Header("Containers")]
        public Image ItemImage;

        private Image background;

        public void Start()
        {
            background = GetComponent<Image>();
            background.sprite = Requirement.CheckRequirements(Character) ? PassedRequirementBackground : MissingRequirementBackground;

            ItemImage.sprite = Requirement.RequiredItem.LoadResource<Sprite>(ResourcePaths.Items, ResourcePostfixes.Icon);
        }

    }
}