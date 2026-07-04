using IsaacTrinkets.Common;
using Terraria;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Buffs
{
	public class WoodenCrossBuff : TrinketBuff
	{
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override bool GetTrinketBool(Player player)
        {
            return player.GetModPlayer<TrinketPlayer>().woodenCrossAcc;
        }

        public override void BuffEffect(Player player)
        {
            player.GetModPlayer<TrinketPlayer>().woodenCrossDodge = true;
        }
	}
}
