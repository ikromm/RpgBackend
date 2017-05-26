using UnityEngine;
using System.Collections;
using ikromm.Characters;
using UnityEngine.UI;

namespace ikromm.Ui
{
    public class StatsSubmenu : PartySubmenu
    {
        public StatsText[] Containers;

        public void Update()
        {
            Character character = PartyMenu.SelectedCharacter;

            foreach (StatsText item in Containers)
                item.Text.text = character[item.Stat].Modifier.ToString();
        }

        [System.Serializable]
        public struct StatsText
        {
            public Stats Stat;
            public Text Text;
        }
    }
}
