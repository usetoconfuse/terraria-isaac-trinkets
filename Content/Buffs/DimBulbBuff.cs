using IsaacTrinkets.Players;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Buffs
{
	public class DimBulbBuff : ModBuff
	{
        public override bool RightClick(int buffIndex)
        {
            return false;
        }

        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<TrinketPlayer>().dimBulbAcc && player.statLife < player.statLifeMax2 * 0.25f)
            {
                player.statDefense += 10;
                player.GetDamage(DamageClass.Generic) += 0.1f;
                player.GetCritChance(DamageClass.Generic) += 10;
                player.equipmentBasedLuckBonus += 0.1f;
                player.moveSpeed += 0.15f;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
	}
}
