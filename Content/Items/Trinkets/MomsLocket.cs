using IsaacTrinkets.Common;
using Terraria;
using Terraria.ID;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class MomsLocket : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Logic handled in TrinketGlobalItem (OnPickup)
            player.GetModPlayer<TrinketPlayer>().momsLocketAcc = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PanicNecklace);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.InGraveyard);
            recipe.Register();
        }
	}
}
