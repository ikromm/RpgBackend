using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using ikromm.Characters;
using System.Linq;

namespace ikromm.Ui
{
    public class SkillsCategorySelection : TabSelection<Skills>
    {
        public GameObject TabPrefab;

        public float Spacing;
        public float TabWidth;

        private int tabCounter;

        private Dictionary<Character, List<SkillCategoryTab>> tabMap = new Dictionary<Character, List<SkillCategoryTab>>();

        private Character selectedCharacter;
        
        public void SetSelectedCharacter(Character character)
        {
            if (selectedCharacter == character)
                return;

            hideTabs(selectedCharacter);
            selectedCharacter = character;

            if (tabMap.ContainsKey(selectedCharacter))
                showTabs(selectedCharacter);

            List<Skills> distinctSkills = new List<Skills>(character.Skills.Select(x => x.Skill.ToEnum()).Distinct());
            createTabs(selectedCharacter, distinctSkills);
            showTabs(selectedCharacter);
        }

        private void createTabs(Character character, List<Skills> skills)
        {
            List<SkillCategoryTab> tabs = new List<SkillCategoryTab>();
            for (int i = 0; i < skills.Count; i++)
            {
                GameObject go = (GameObject)Instantiate(TabPrefab);
                go.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i * (TabWidth - Spacing));

                Toggle toggle = go.GetComponent<Toggle>();
                toggle.group = toggleGroup;
                toggle.onValueChanged.AddListener((value) => { ChangeSelection(); });

                SkillCategoryTab script = go.GetComponent<SkillCategoryTab>();
                script.Name = skills[i].ToString();
                tabs.Add(script);
            }

            tabMap.Add(character, tabs);
        }

        private void showTabs(Character character)
        {
            foreach (SkillCategoryTab tab in tabMap[character])
                tab.gameObject.SetActive(true);
        }

        private void hideTabs(Character character)
        {
            foreach (SkillCategoryTab tab in tabMap[character])
                tab.gameObject.SetActive(false);
        }
    }
}
