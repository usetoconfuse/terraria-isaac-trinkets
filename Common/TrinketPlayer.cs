using IsaacTrinkets.Content.Buffs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace IsaacTrinkets.Common
{
    public class TrinketPlayer : ModPlayer
    {
        public bool vibrantBulbAcc;
        public bool dimBulbAcc;
        public bool watchBatteryAcc;
        public bool callusAcc;
        public bool cursedSkullAcc;
        public bool endlessNamelessAcc;
        public bool hairpinAcc;
        public bool brainWormAcc;
        public bool oldCapacitorAcc;
        public bool woodenCrossAcc;
        public bool woodenCrossDodge;
        public int woodenCrossDodgeTimer;
        public bool swallowedM80Acc;

        public override void ResetEffects()
        {
            watchBatteryAcc = false;
            callusAcc = false;
            cursedSkullAcc = false;
            endlessNamelessAcc = false;
            hairpinAcc = false;
            brainWormAcc = false;
            oldCapacitorAcc = false;
            woodenCrossDodge = false;
            swallowedM80Acc = false;
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

            if (woodenCrossAcc && woodenCrossDodgeTimer == 0 && Player.shadowDodgeTimer == 0)
            {
                if (!woodenCrossDodge)
                {
                    woodenCrossDodgeTimer = 5400;
                    Player.shadowDodgeTimer = 1800;
                }
                Player.AddBuff(ModContent.BuffType<WoodenCrossBuff>(), 5400);
            }
            woodenCrossAcc = false;
            if (woodenCrossDodgeTimer > 0)
            {
                woodenCrossDodgeTimer--;
            }
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
                woodenCrossDodgeTimer = 5400;
                Player.shadowDodgeTimer = 1800;
                SoundEngine.PlaySound(new SoundStyle("IsaacTrinkets/Assets/Sounds/HolyShield") with { Type = SoundType.Sound }, Player.position);
                NetMessage.SendData(MessageID.Dodge, -1, -1, null, Player.whoAmI, 2f);
                return true;
            }
            return false;
        }

        public override void PostHurt(Player.HurtInfo info)
        {
            if (swallowedM80Acc)
            {
                if (Player.whoAmI == Main.myPlayer)
                {
                    IEntitySource projectileSource_Misc = Player.GetSource_FromThis();
                    int num4 = Projectile.NewProjectile(projectileSource_Misc, Player.Center.X, Player.Center.Y, 0f, 0f, 608, 100, 15f, Main.myPlayer);
                    Main.projectile[num4].netUpdate = true;
                    Main.projectile[num4].Kill();
                }
            }
            
            if (cursedSkullAcc && Player.statLife < Player.statLifeMax2 * 0.1f)
            {
                Player.TeleportationPotion();
            }
        }

        // Prevent instant damage from damaging tiles with callus
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
