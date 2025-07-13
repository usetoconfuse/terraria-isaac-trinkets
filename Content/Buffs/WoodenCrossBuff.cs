using IsaacTrinkets.Players;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Buffs
{
	public class WoodenCrossBuff : ModBuff
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
            if (player.GetModPlayer<TrinketPlayer>().woodenCrossAcc)
            {
                player.GetModPlayer<TrinketPlayer>().woodenCrossDodge = true;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
	}
}
