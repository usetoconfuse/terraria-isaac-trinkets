using Terraria;
using Terraria.ID;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class AAABattery : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaRegenBonus += 25;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            // Custom RecipeGroup for copper/tin in TrinketModSystem (AddRecipeGroups)
            recipe.AddRecipeGroup(nameof(ItemID.CopperBar), 6);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddIngredient(ItemID.Wire);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
	}
}
