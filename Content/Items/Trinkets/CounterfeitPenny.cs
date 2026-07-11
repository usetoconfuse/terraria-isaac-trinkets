using IsaacTrinkets.Common;
using Terraria;
using Terraria.ID;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class CounterfeitPenny : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 50);
            Item.rare = ItemRarityID.Blue;
            // Obtain method handled in TrinketGlobalNPC (ModifyShop)
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Logic handled in TrinketGlobalNPC (OnKill)
            player.GetModPlayer<TrinketPlayer>().counterfeitPennyAcc = true;
        }
	}
}
