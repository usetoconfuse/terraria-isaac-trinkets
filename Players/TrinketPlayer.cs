using IsaacTrinkets.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace IsaacTrinkets.Players
{
    public class TrinketPlayer : ModPlayer
    {
        public bool vibrantBulbAcc;
        public bool dimBulbAcc;
        public bool watchBatteryAcc;
        public bool oldCapacitorAcc;
        public bool woodenCrossAcc;

        public bool woodenCrossDodge;

        public override void ResetEffects()
        {
            watchBatteryAcc = false;
            oldCapacitorAcc = false;
            woodenCrossDodge = false;
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

            if (woodenCrossAcc && Player.shadowDodgeTimer == 0)
            {
                if (!woodenCrossDodge)
                {
                    Player.shadowDodgeTimer = 1800;
                }
                Player.AddBuff(ModContent.BuffType<WoodenCrossBuff>(), 1800);
            }
            woodenCrossAcc = false;
        }

        public override bool ConsumableDodge(Player.HurtInfo info)
        {
            if
            (
                !Player.immune
                && info.Dodgeable
                && Player.whoAmI == Main.myPlayer
                && woodenCrossDodge
            )
            {
                Player.SetImmuneTimeForAllTypes(Player.longInvince ? 120 : 80);
                Player.ClearBuff(ModContent.BuffType<WoodenCrossBuff>());
                Player.shadowDodgeTimer = 1800;
                NetMessage.SendData(MessageID.Dodge, -1, -1, null, Player.whoAmI, 2f);
                return true;
            }
            return false;
        }
    }
}
