using IsaacTrinkets.Common;
using Terraria;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Buffs
{
	public class DimBulbBuff : TrinketBuff
	{
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override bool GetTrinketBool(Player player)
        {
            return player.GetModPlayer<TrinketPlayer>().dimBulbAcc && player.statLife < player.statLifeMax2 * 0.25f;
        }

        public override void BuffEffect(Player player)
        {
            player.statDefense += 10;
            player.GetDamage(DamageClass.Generic) += 0.1f;
            player.GetCritChance(DamageClass.Generic) += 10;
            player.equipmentBasedLuckBonus += 0.1f;
            player.moveSpeed += 0.15f;
        }
	}
}
