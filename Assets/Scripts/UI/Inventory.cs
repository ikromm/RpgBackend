using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

namespace ikromm.Ui
{
    public class Inventory : MonoBehaviour
    {
        public GridLayoutGroup ItemsContainer;
        
        public ToggleGroup Actions;
        public TypedGameObjects[] Mapping;

        public ListingTypes ListingType
        {
            get { return System.Array.Find(Mapping, entry => entry.GameObject == Actions.ActiveToggles().FirstOrDefault()).Type; }
        }


        public enum ListingTypes
        {
            Inventory,
            Plot
        }

        [System.Serializable]
        public struct TypedGameObjects
        {
            public ListingTypes Type;
            public GameObject GameObject;
        }
    }
}
