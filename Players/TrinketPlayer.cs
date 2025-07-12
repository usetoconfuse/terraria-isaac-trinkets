using IsaacTrinkets.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Players
{
    public class TrinketPlayer : ModPlayer
    {
        public bool vibrantBulbAcc;
        public bool dimBulbAcc;
        public bool watchBatteryAcc;

        public override void ResetEffects() {
			watchBatteryAcc = false;
		}

        public override void PostUpdateBuffs()
        {
            if (vibrantBulbAcc && Player.statLife == Player.statLifeMax2)
            {
                Player.AddBuff(ModContent.BuffType<VibrantBulbBuff>(), 60);
            }
            vibrantBulbAcc = false;

            if (dimBulbAcc && Player.statLife < Player.statLifeMax2 * 0.25f)
            {
                Player.AddBuff(ModContent.BuffType<DimBulbBuff>(), 60);
            }
            dimBulbAcc = false;
        }
    }
}
