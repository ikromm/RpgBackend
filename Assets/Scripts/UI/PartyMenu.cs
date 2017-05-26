using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ikromm.Characters;
using UnityEngine.UI;

namespace ikromm.Ui
{
    public class PartyMenu : MenuBehaviour
    {
        public GameObject Border;
        public GameObject PartyContainer;

        public GameObject CharacterPortraitPrefab;

        private List<CharacterPortrait> portraits = new List<CharacterPortrait>();

        private CharacterPortrait selectedPortrait;
        public CharacterPortrait SelectedPortrait { get { return selectedPortrait; } }
        public Character SelectedCharacter { get { return selectedPortrait.Character; } }

        public void Start()
        {
            foreach (Character character in DummyParty.Instance.Party)
            {
                GameObject instance = (GameObject)Instantiate(CharacterPortraitPrefab);
                instance.transform.SetParent(PartyContainer.transform, false);

                CharacterPortrait script = instance.GetComponent<CharacterPortrait>();
                script.Character = character;
                script.Selected = false;

                portraits.Add(script);

                instance.GetComponent<Button>().onClick.AddListener(() => SelectCharacter(script));
            }

            selectedPortrait = portraits[0];
            portraits[0].Selected = true;
        }

        public void SelectCharacter(CharacterPortrait portrait)
        {
            if (selectedPortrait != null)
                selectedPortrait.Selected = false;

            selectedPortrait = portrait;
            selectedPortrait.Selected = true;

            iTween.MoveTo(Border, new Hashtable(){
                {"x", portrait.GetComponent<RectTransform>().position.x}, 
                {"time", 0.5f}
            });
        }
    }
}
