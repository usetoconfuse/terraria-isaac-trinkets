using Terraria;
using Terraria.ID;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class BlindRage : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Uses the same var as the Cross Necklace, so doesn't stack
            player.longInvince = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Blindfold);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.InGraveyard);
            recipe.Register();
        }
	}
}
