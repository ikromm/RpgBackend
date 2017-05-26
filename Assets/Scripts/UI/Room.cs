using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ikromm.Ui
{
    public class Room : MonoBehaviour
    {
        public int MaxLevel = 4;

        public Color NormalColor;
        public Color SelectedColor;

        [Header("Containers")]
        public Text Name;
        public List<Image> LevelJewels;

        public bool Selected;

        public Castle.Room CastleRoom { get; set; }

        void Start()
        {
            Name.text = CastleRoom.Name;

            for (int i = 1; i <= MaxLevel; i++)
            {
                LevelJewels[i].enabled = i <= CastleRoom.Level;
            }
        }

        void Update()
        {
            Name.color = Selected ? SelectedColor : NormalColor;
        }

    }
}