using UnityEngine;
using System.Collections;

namespace ikromm.Ui
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CanvasGroup))]
    public class MenuBehaviour : MonoBehaviour
    {
        public const string AnimatorBoolName = "IsOpen";
        public const string AnimatorStateName = "Open";

        private Animator animator;
        private CanvasGroup canvasGroup;

        public virtual bool IsOpen
        {
            get { return animator.GetBool(AnimatorBoolName); }
            set
            {
                animator.SetBool(AnimatorBoolName, value);
                canvasGroup.blocksRaycasts = value;
                canvasGroup.interactable = value;
            }
        }

        public void Awake()
        {
            animator = GetComponent<Animator>();
            canvasGroup = GetComponent<CanvasGroup>();

            RectTransform rect = GetComponent<RectTransform>();
            rect.offsetMin = rect.offsetMax = Vector2.zero;
        }

    }
}
