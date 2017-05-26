using UnityEngine;
using System.Collections;

namespace ikromm.Ui
{
    public class PartySubmenu : SubmenuBehaviour
    {
        public PartyMenu PartyMenu;

        public override MenuBehaviour Parent { get { return PartyMenu; } }
    }
}
