using IsaacTrinkets.Common;
using Terraria;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Buffs
{
    public class RedPatchBuff : ModBuff
    {
        public override bool RightClick(int buffIndex)
        {
            return false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<TrinketPlayer>().redPatchAcc)
            {
                player.GetDamage(DamageClass.Generic) += 0.2f;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
