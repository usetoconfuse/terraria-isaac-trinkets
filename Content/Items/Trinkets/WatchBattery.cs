using IsaacTrinkets.Common;
using Terraria;
using Terraria.ID;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class WatchBattery : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Logic handled in TrinketGlobalNPC (OnKill)
            player.GetModPlayer<TrinketPlayer>().watchBatteryAcc = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            // Custom RecipeGroup for any watch in TrinketModSystem (AddRecipeGroups)
            recipe.AddRecipeGroup("IsaacTrinkets:AnyWatch");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
	}
}
