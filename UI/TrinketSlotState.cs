using Terraria.UI;

namespace IsaacTrinkets.UI
{
    public class TrinketSlotState : UIState
    {
        public TrinketSlot trinketSlot;

        public override void OnInitialize()
        {
            trinketSlot = new TrinketSlot();

            Append(trinketSlot);
        }
    }
}