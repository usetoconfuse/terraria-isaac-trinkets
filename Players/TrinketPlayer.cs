using IsaacTrinkets.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Players
{
    public class TrinketPlayer : ModPlayer
    {
        public bool vibrantBulb = false;
        public bool dimBulb = false;
        public override void PostUpdateBuffs()
        {
            if (vibrantBulb && Player.statLife == Player.statLifeMax2)
            {
                Player.AddBuff(ModContent.BuffType<VibrantBulbBuff>(), 60);
            }
            vibrantBulb = false;

            if (dimBulb && Player.statLife < Player.statLifeMax2 * 0.25f)
            {
                Player.AddBuff(ModContent.BuffType<DimBulbBuff>(), 60);
            }
            dimBulb = false;
        }
    }
}
