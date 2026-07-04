using IsaacTrinkets.Common;
using Terraria;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Buffs
{
    public class HairpinBuff : TrinketBuff
    {

        public override bool GetTrinketBool(Player player)
        {
            return player.GetModPlayer<TrinketPlayer>().hairpinAcc;
        }

        public override void BuffEffect(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.15f;
            player.GetCritChance(DamageClass.Generic) += 5;
            player.moveSpeed += 0.10f;
        }
    }
}