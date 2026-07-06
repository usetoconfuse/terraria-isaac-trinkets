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

        // Hairpin & Tick
		public override void OnSpawn(NPC npc, IEntitySource source)
		{
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

        // Watch Battery
		public override void OnKill(NPC npc)
		{
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

        // Old Capacitor
        public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
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
            switch (npc.type)
            {
                case NPCID.KingSlime:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrackedCrown>(), 20));
                    break;
                case NPCID.BrainofCthulhu:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StemCell>(), 10));
                    break;
            }
        }
	}
}