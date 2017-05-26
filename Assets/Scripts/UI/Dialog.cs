using UnityEngine;

namespace ikromm.Ui
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(RectTransform))]
    public class Dialog : MonoBehaviour
    {

        public const string AnimatorBoolName = "IsOpen";
        public const string AnimatorStateName = "Open";

        private Animator animator;
        private CanvasGroup canvasGroup;

        public bool IsOpen
        {
            get { return animator.GetBool(AnimatorBoolName); }
            set { animator.SetBool(AnimatorBoolName, value); }
        }

        public void Awake()
        {
            animator = GetComponent<Animator>();
            canvasGroup = GetComponent<CanvasGroup>();

            RectTransform rect = GetComponent<RectTransform>();
            rect.offsetMax = rect.offsetMin = Vector2.zero;
        }

        public void Update()
        {
            canvasGroup.blocksRaycasts = canvasGroup.interactable =
                animator.GetCurrentAnimatorStateInfo(0).IsName(AnimatorStateName);
        }

    }
}