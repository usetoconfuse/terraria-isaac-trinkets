using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using IsaacTrinkets.Content.Items.Trinkets;

namespace IsaacTrinkets.Common
{
	public class TrinketModSystem : ModSystem
	{
		public override void AddRecipeGroups()
		{
			// Use nameof(ItemID.name) if the group is likely to be used in other mods for the same purpose, otherwise "IsaacTrinkets:GroupName"
			// Copper / Tin bars for AAA Battery
			RecipeGroup anyCopperBarGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBar)}", ItemID.CopperBar, ItemID.TinBar);
			RecipeGroup.RegisterGroup(nameof(ItemID.CopperBar), anyCopperBarGroup);

			// Any type of watch for Watch Battery - note not using localized 'watch' name (could be improved in the future)
			RecipeGroup anyWatchGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Watch", ItemID.CopperWatch, ItemID.TinWatch, ItemID.SilverWatch, ItemID.TungstenWatch, ItemID.GoldWatch, ItemID.PlatinumWatch);
			RecipeGroup.RegisterGroup("IsaacTrinkets:AnyWatch", anyWatchGroup);
		}

        public override void PostWorldGen()
        {
            // Place Trinkets in some chests
			// Loop over all the chests
			for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest == null)
				{
					continue;
				}
				Tile chestTile = Main.tile[chest.x, chest.y];

				if (chestTile.TileType == TileID.Containers)
				{
					// Gold Chest (underground / cavern) - Shiny Rock
					if (chestTile.TileFrameX == 1 * 36)
					{
						// will skip 19/20 times (5% chance to add)
						if (!WorldGen.genRand.NextBool(20))
						{
							continue;
						}
						// Next we need to find the first empty slot for our item
						for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								// Place the item
								chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<ShinyRock>());
								break;
							}
						}
					}
					// Locked Shadow Chest - Endless Nameless
					else if (chestTile.TileFrameX == 4 * 36)
					{

						if (!WorldGen.genRand.NextBool(10))
						{
							continue;
						}

						for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<EndlessNameless>());
								break;
							}
						}
					}
				}
				// Dead Man's Chest - Swallowed M80
				else if (chestTile.TileType == TileID.Containers2 && chestTile.TileFrameX == 4 * 36)
				{
					if (!WorldGen.genRand.NextBool(10))
					{
						continue;
					}
					
					for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.None)
						{
							chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<SwallowedM80>());
							break;
						}
					}
				}
			}
		}
	}
}