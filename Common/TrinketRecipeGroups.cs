using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace IsaacTrinkets.Common
{
	public class TrinketRecipeGroups : ModSystem
	{
		// Use nameof(ItemID.name) if the group is likely to be used in other mods for the same purpose, otherwise "IsaacTrinkets:GroupName"
		public override void AddRecipeGroups()
		{
			// Copper / Tin bars for AAA Battery
			RecipeGroup anyCopperBarGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBar)}", ItemID.CopperBar, ItemID.TinBar);
			RecipeGroup.RegisterGroup(nameof(ItemID.CopperBar), anyCopperBarGroup);

			// Any type of watch for Watch Battery - note not using localized 'watch' name (could be improved in the future)
			RecipeGroup anyWatchGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Watch", ItemID.CopperWatch, ItemID.TinWatch, ItemID.SilverWatch, ItemID.TungstenWatch, ItemID.GoldWatch, ItemID.PlatinumWatch);
			RecipeGroup.RegisterGroup("IsaacTrinkets:AnyWatch", anyWatchGroup);
		}
	}
}