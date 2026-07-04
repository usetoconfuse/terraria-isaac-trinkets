using IsaacTrinkets.Common;
using Terraria;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Buffs
{
	public class VibrantBulbBuff : TrinketBuff
	{
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override bool GetTrinketBool(Player player)
        {
            return player.GetModPlayer<TrinketPlayer>().vibrantBulbAcc && player.statLife == player.statLifeMax2;
        }

        public override void BuffEffect(Player player)
        {
            player.statDefense += 4;
            player.GetDamage(DamageClass.Generic) += 0.04f;
            player.GetCritChance(DamageClass.Generic) += 4;
            player.equipmentBasedLuckBonus += 0.05f;
            player.moveSpeed += 0.05f;
        }
	}
}
