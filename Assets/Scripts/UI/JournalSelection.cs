using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

namespace ikromm.Ui
{
    public class JournalSelection : TabSelection<ikromm.Ui.JournalSelection.Options>
    {
        public JournalOptionsDictionary Map;

        public Text Title;

        public override void Awake()
        {
            base.Awake();
            SetMap(Map);
        }

        public override void Start()
        {
            ChangeSelection();
        }

        public override void ChangeSelection()
        {
            base.ChangeSelection();
            Title.text = Selected.ToString();
        }

        public enum Options
        {
            Log,
            Rumors,
            Secrets,
            Bestiary
        }


        [System.Serializable]
        // The drawer of this class is in SerializableDictionaryDrawer
        public class JournalOptionsDictionary : SerializableDictionary<Options, Toggle> { } 

    }
}
