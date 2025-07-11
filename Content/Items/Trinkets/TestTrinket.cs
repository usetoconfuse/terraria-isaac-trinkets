using System.Linq;
using IsaacTrinkets.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Items.Trinkets
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class TestTrinket : Trinket
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.IsaacTrinkets.hjson' file.
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.defense = 10;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
