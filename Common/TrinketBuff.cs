using Terraria;
using Terraria.ModLoader;

namespace IsaacTrinkets.Common
{
    public abstract class TrinketBuff : ModBuff
    {
        public override bool RightClick(int buffIndex)
        {
            return false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // Remove the buff if the player no longer has the trinket equipped, otherwise apply effect
            if (GetTrinketBool(player))
            {
                BuffEffect(player);
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }

        public abstract void BuffEffect(Player player);

        public abstract bool GetTrinketBool(Player player);
    }
}