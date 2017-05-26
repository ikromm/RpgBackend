using UnityEngine;
using System.Collections;
using ikromm.Characters;
using UnityEngine.UI;

namespace ikromm.Ui
{
    public class CharacterPortrait : MonoBehaviour
    {
        public Character Character;

        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                updateDisplay();
            }
        }

        [Header("Containers")]
        public Text HpText;
        public Slider HpProgressbar;
        public Image Portrait;
        public Text Name;

        public void Start()
        {
            Name.text = Character.Name;
        }
        
        private void updateDisplay()
        {
            Portrait.sprite = Character.LoadResource<Sprite>(ResourcePaths.IngameMenu,
                selected ? ResourcePostfixes.PortraitSelected : ResourcePostfixes.Portrait);
        }
    }
}
