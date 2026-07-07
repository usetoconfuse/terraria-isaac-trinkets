using IsaacTrinkets.Content.Buffs;
using IsaacTrinkets.Content.Items.Trinkets;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Common
{
	public class TrinketGlobalNPC : GlobalNPC
	{
		public override void OnSpawn(NPC npc, IEntitySource source)
		{
            // Hairpin & Tick
			if (npc.boss)
			{
				foreach (Player player in Main.ActivePlayers)
				{
					if (player.GetModPlayer<TrinketPlayer>().hairpinAcc)
					{
						player.AddBuff(ModContent.BuffType<HairpinBuff>(), 30 * 60);
					}
                    if (player.GetModPlayer<TrinketPlayer>().tickAcc)
					{
						npc.life -= (int)(npc.lifeMax * 0.15f);
					}
				}
			}
		}

		public override void OnKill(NPC npc)
		{
            // Watch Battery
			Player closestPlayer = Main.player[Player.FindClosest(npc.position, npc.width, npc.height)];

            if
            (
                Main.rand.NextBool(2)
                && closestPlayer.statMana < closestPlayer.statManaMax2
                && closestPlayer.GetModPlayer<TrinketPlayer>().watchBatteryAcc
            )
            {
                Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.Star);
            }
        }

        public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
            // Old Capacitor
            Player player = Main.player[projectile.owner];
            if
            (
                Main.rand.NextBool(5)
                && player.statMana < player.statManaMax2
                && projectile.CountsAsClass(DamageClass.Magic)
                && player.GetModPlayer<TrinketPlayer>().oldCapacitorAcc
            )
            {
                Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.Star);
            }
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            // Trinkets dropped by enemies / bosses
            switch (npc.type)
            {
                case NPCID.KingSlime:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrackedCrown>(), 20));
                    break;
                case NPCID.BrainofCthulhu:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StemCell>(), 10));
                    break;
                case NPCID.DevourerHead or NPCID.DiggerHead or NPCID.DuneSplicerHead or NPCID.GiantWormHead or NPCID.TombCrawlerHead or 98:
                    npcLoot.Add(ItemDropRule.OneFromOptions(100, ModContent.ItemType<BrainWorm>(), ModContent.ItemType<WhipWorm>()));
                    break;
                case NPCID.BloodZombie or NPCID.Drippler:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RedPatch>(), 100));
                    break;
                case NPCID.FaceMonster or NPCID.Crimera:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Callus>(), 100));
                    break;
                case NPCID.CursedSkull or NPCID.GiantCursedSkull:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedSkull>(), 100));
                    break;
                case NPCID.MotherSlime:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MothersKiss>(), 100));
                    break;
                case NPCID.Demon:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CurvedHorn>(), 100));
                    break;
                case NPCID.RedDevil:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CurvedHorn>(), 50));
                    break;
                case NPCID.Corruptor:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LuckyToe>(), 100));
                    break;
            }
        }

        public override void ModifyShop(NPCShop shop)
        {
            // Trinkets sold by NPCs
            if (shop.NpcType == NPCID.BestiaryGirl)
            {
				shop.Add<GoatHoof>();
			}
			else if (shop.NpcType == NPCID.Cyborg)
            {
                shop.Add<OldCapacitor>();
            }
			else if (shop.NpcType == NPCID.Stylist)
            {
				shop.Add<Hairpin>(Condition.Hardmode);
			}
			else if (shop.NpcType == NPCID.Mechanic)
            {
				shop.Add<VibrantBulb>(Condition.MoonPhaseFull);
			}
        }
	}
}