using System.Collections.Generic;
using IsaacTrinkets.Content.Buffs;
using IsaacTrinkets.Content.Items.Trinkets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Common
{
    public class TrinketPlayer : ModPlayer
    {
        
        public bool brainWormAcc;
        public bool brokenSyringeAcc;
        public int brokenSyringeActiveTimer;
        public bool callusAcc;
        public bool cancerAcc;
        public bool childsHeartAcc;
        public bool counterfeitPennyAcc;
        public List<int> crackedCrownPrefixList;
        public bool cursedSkullAcc;
        public bool dimBulbAcc;
        public bool endlessNamelessAcc;
        public bool hairpinAcc;
        public bool momsLocketAcc;
        public bool oldCapacitorAcc;
        public bool redPatchAcc;
        public bool speedBall;
        public bool stemCellAcc;
        public bool swallowedM80Acc;
        public bool tickAcc;
        public bool vibrantBulbAcc;
        public bool watchBatteryAcc;
        public bool woodenCrossAcc;
        public bool woodenCrossDodge;
        public int woodenCrossDodgeTimer;

        public override void ResetEffects()
        {
            brainWormAcc = false;
            callusAcc = false;
            cancerAcc = false;
            childsHeartAcc = false;
            counterfeitPennyAcc = false;
            crackedCrownPrefixList = new List<int>();
            cursedSkullAcc = false;
            endlessNamelessAcc = false;
            momsLocketAcc = false;
            oldCapacitorAcc = false;
            speedBall = false;
            stemCellAcc = false;
            swallowedM80Acc = false;
            tickAcc = false;
            watchBatteryAcc = false;
            woodenCrossDodge = false;
        }

        public override void PreUpdate()
        {
            // Cooldowns or timers should be decremented here

            if (woodenCrossDodgeTimer > 0)
            {
                woodenCrossDodgeTimer--;
            }

            if (brokenSyringeActiveTimer > 0)
            {
                brokenSyringeActiveTimer--;
            }
        }
        public override void PostUpdateBuffs()
        {
            // Vibrant Bulb
            if (vibrantBulbAcc && Player.statLife == Player.statLifeMax2)
            {
                Player.AddBuff(ModContent.BuffType<VibrantBulbBuff>(), 60);
            }

            // Dim Bulb
            if (dimBulbAcc && Player.statLife < Player.statLifeMax2 * 0.25f)
            {
                Player.AddBuff(ModContent.BuffType<DimBulbBuff>(), 60);
            }

            // Wooden Cross
            if (woodenCrossAcc && woodenCrossDodgeTimer == 0 && Player.shadowDodgeTimer == 0)
            {
                if (!woodenCrossDodge)
                {
                    woodenCrossDodgeTimer = Main.rand.Next(3600, 7200);
                    Player.shadowDodgeTimer = 1800;
                }
                Player.AddBuff(ModContent.BuffType<WoodenCrossBuff>(), woodenCrossDodgeTimer);
            }
            
            // Broken Syringe
            if (brokenSyringeAcc && brokenSyringeActiveTimer == 0 && Main.rand.NextBool(1000))
            {
                int randomBuffIndex = Main.rand.Next(5);
                int randomDuration = Main.rand.Next(600, 1200);
                switch (randomBuffIndex)
                {
                    case 0:
                        Player.AddBuff(ModContent.BuffType<AdrenalineBuff>(), randomDuration);
                        break;
                    case 1:
                        Player.AddBuff(ModContent.BuffType<GrowthHormonesBuff>(), randomDuration);
                        break;
                    case 2:
                        Player.AddBuff(ModContent.BuffType<RoidRageBuff>(), randomDuration);
                        break;
                    case 3:
                        Player.AddBuff(ModContent.BuffType<SpeedBallBuff>(), randomDuration);
                        break;
                    case 4:
                        Player.AddBuff(ModContent.BuffType<SynthoilBuff>(), randomDuration);
                        break;
                }
                brokenSyringeActiveTimer = randomDuration;
            }

            // Buff-related trinket booleans should be set to false here
            brokenSyringeAcc = false;
            dimBulbAcc = false;
            hairpinAcc = false;
            redPatchAcc = false;
            vibrantBulbAcc = false;
            woodenCrossAcc = false;
            
        }

        public override bool ConsumableDodge(Player.HurtInfo info)
        {
            // Wooden Cross
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
                woodenCrossDodgeTimer = Main.rand.Next(3600, 7200);
                Player.shadowDodgeTimer = 1800;
                SoundEngine.PlaySound(new SoundStyle("IsaacTrinkets/Assets/Sounds/HolyShield") with { Type = SoundType.Sound }, Player.position);
                NetMessage.SendData(MessageID.Dodge, -1, -1, null, Player.whoAmI, 2f);
                return true;
            }
            return false;
        }

        public override void PostHurt(Player.HurtInfo info)
        {
            // Swallowed M80
            if (swallowedM80Acc)
            {
                if (Player.whoAmI == Main.myPlayer)
                {
                    IEntitySource projectileSource_Misc = Player.GetSource_FromThis();
                    int num4 = Projectile.NewProjectile(projectileSource_Misc, Player.Center.X, Player.Center.Y, 0f, 0f, ProjectileID.SolarCounter, 100, 15f, Main.myPlayer);
                    Main.projectile[num4].netUpdate = true;
                    Main.projectile[num4].Kill();
                }
            }

            // Cursed Skull
            if (cursedSkullAcc && Player.statLife < Player.statLifeMax2 * 0.1f)
            {
                Player.TeleportationPotion();
                SoundEngine.PlaySound(new SoundStyle("IsaacTrinkets/Assets/Sounds/Teleport") with { Type = SoundType.Sound }, Player.position);
            }

            // Red Patch
            if (redPatchAcc)
            {
                if (Main.rand.NextBool(10))
                {
                    Player.AddBuff(ModContent.BuffType<RedPatchBuff>(), 600);
                }
            }
        }

        public override bool ImmuneTo(PlayerDeathReason damageSource, int cooldownCounter, bool dodgeable)
        {
            // Callus - Prevent instant damage from damaging tiles
            if (callusAcc && damageSource.SourceOtherIndex == 3)
            {
                return true;
            }

            return false;
        }

        public override void ModifyShootStats(Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Broken Syringe & Whip Worm
            if (speedBall)
            {
                velocity *= 1.3f;
            }
        }

        public override void UpdateLifeRegen()
        {
            // Stem Cell
            if (stemCellAcc)
            {
                Player.lifeRegen += 2;
            }
        }

        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            // Broken Syringe obtainted from fishing
            bool inWater = !attempt.inLava && !attempt.inHoney;
            if (inWater && Main.bloodMoon && attempt.veryrare && Main.rand.Next(3) == 0)
            {
                itemDrop = ModContent.ItemType<BrokenSyringe>();
            }
        }

        public override float UseSpeedMultiplier(Item item)
        {
            // Cancer
            float multiplier = base.UseSpeedMultiplier(item);
            if (cancerAcc && item.damage != 0)
            {
                multiplier *= 1.1f;
            }
            return multiplier;
        }
    }
}
