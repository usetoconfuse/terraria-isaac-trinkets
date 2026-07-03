using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class Karma : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(silver: 1);
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //vanilla reasonable cap with all npcs: 300-400 (11 per npc) = 0.3-0.4 luck
            int karma = 0;
            foreach (var npc in Main.ActiveNPCs)
            {
                if (npc.townNPC)
                {
                    var price = Main.ShopHelper.GetShoppingSettings(player, npc).PriceAdjustment;
                    karma += (int)((1 - price) * 100);
                }
            }
            player.equipmentBasedLuckBonus += (float)karma / 1000;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
	}
}
