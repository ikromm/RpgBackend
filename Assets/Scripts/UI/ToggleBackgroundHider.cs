using UnityEngine;
using UnityEngine.UI;

namespace ikromm.Ui
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleBackgroundHider : MonoBehaviour
    {
        public Image Background;

        void Start()
        {
            GetComponent<Toggle>().onValueChanged.AddListener((value) => { ToggleBackground(value); });
        }

        void ToggleBackground(bool value)
        {
            if (Background != null)
                Background.enabled = !value;
        }
    }
}
