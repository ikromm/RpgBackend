using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ikromm.Ui
{
    [RequireComponent(typeof(ToggleGroup))]
    public class TabSelection<T> : MonoBehaviour
    {
        private Dictionary<T, Toggle> map;

        protected ToggleGroup toggleGroup { get; private set; }

        private Toggle selectedToggle = null;
        public T Selected { get { return map.First(x => x.Value == selectedToggle).Key; } }

        public virtual void Awake()
        {
            toggleGroup = GetComponent<ToggleGroup>();
        }

        public virtual void Start()
        {
            ChangeSelection();
        }

        public virtual void ChangeSelection()
        {
            selectedToggle = toggleGroup.ActiveToggles().FirstOrDefault();

            if (selectedToggle != null)
                selectedToggle.transform.SetAsLastSibling();
        }

        protected void SetMap(IDictionary<T, Toggle> map)
        {
            this.map = new Dictionary<T, Toggle>(map);
        }
    }
}
