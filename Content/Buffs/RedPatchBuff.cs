using IsaacTrinkets.Common;
using Terraria;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Buffs
{
    public class RedPatchBuff : TrinketBuff
    {
        public override bool GetTrinketBool(Player player)
        {
            return player.GetModPlayer<TrinketPlayer>().redPatchAcc;
        }

        public override void BuffEffect(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.2f;
        }
    }
}
