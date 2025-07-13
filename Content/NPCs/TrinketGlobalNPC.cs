using IsaacTrinkets.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using IsaacTrinkets.Players;
using Terraria.DataStructures;

namespace IsaacTrinkets.Content.NPCs
{
	public class TrinketGlobalNPC : GlobalNPC
	{
		public override void OnSpawn(NPC npc, IEntitySource source)
		{
			if (npc.boss)
			{
				foreach (Player player in Main.player)
				{
					if (player.GetModPlayer<TrinketPlayer>().hairpinAcc)
					{
						player.AddBuff(ModContent.BuffType<HairpinBuff>(), 30 * 60);
					}
				}
			}
		}

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
	}
}