using IsaacTrinkets.Common;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Buffs
{
	public class VibrantBulbBuff : ModBuff
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
            if (player.GetModPlayer<TrinketPlayer>().vibrantBulbAcc && player.statLife == player.statLifeMax2)
            {
                player.statDefense += 4;
                player.GetDamage(DamageClass.Generic) += 0.04f;
                player.GetCritChance(DamageClass.Generic) += 4;
                player.equipmentBasedLuckBonus += 0.05f;
                player.moveSpeed += 0.05f;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
	}
}
