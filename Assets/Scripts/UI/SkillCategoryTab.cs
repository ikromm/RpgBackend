using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ikromm.Ui
{
    [RequireComponent(typeof(Toggle))]
    public class SkillCategoryTab : MonoBehaviour
    {
        public Image Background;

        [Header("Containers")]
        public Text CategoryName;

        public float ImageWidth { get; private set; }

        public string Name { get; set; }

        public void Start()
        {
            CategoryName.text = Name;
            ImageWidth = Background.GetComponent<RectTransform>().rect.width;
        }
    }
}
