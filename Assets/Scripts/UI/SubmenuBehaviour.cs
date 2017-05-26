using UnityEngine;
using System.Collections;

namespace ikromm.Ui
{

    public abstract class SubmenuBehaviour : MenuBehaviour
    {
        public abstract MenuBehaviour Parent { get; }

        public override bool IsOpen
        {
            get { return base.IsOpen; }
            set
            {
                if (Parent.IsOpen != value)
                    Parent.IsOpen = value;

                base.IsOpen = value;
            }
        }

    }
}
