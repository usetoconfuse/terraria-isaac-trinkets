using IsaacTrinkets.Content.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Players
{
    public class TrinketPlayer : ModPlayer
    {
        public bool vibrantBulbAcc;
        public bool dimBulbAcc;
        public bool watchBatteryAcc;
        public bool callusAcc;
        public bool cursedSkullAcc;

        public override void ResetEffects()
        {
            watchBatteryAcc = false;
            callusAcc = false;
            cursedSkullAcc = false;
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

        public override void PostHurt(Player.HurtInfo info)
        {
            if (cursedSkullAcc && Player.statLife < Player.statLifeMax2 * 0.1f)
            {
                Player.TeleportationPotion();
            }
        }

        // Prevent instant damage from damaging tiles
        public override bool ImmuneTo(PlayerDeathReason damageSource, int cooldownCounter, bool dodgeable)
        {
            if (callusAcc && damageSource.SourceOtherIndex == 3)
            {
                return true;
            }

            return false;
        }
    }
}
