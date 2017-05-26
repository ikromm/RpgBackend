using UnityEngine.UI;

namespace ikromm.Ui
{
    public class FixedHeightScrollbar : Scrollbar
    {
        protected override void Awake()
        {
            base.Awake();
            this.size = 0;
            this.direction = Direction.TopToBottom;
        }

        public void Update()
        {
            this.size = 0;
        }

    }
}
