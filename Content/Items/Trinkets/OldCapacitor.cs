using IsaacTrinkets.Common;
using Terraria;
using Terraria.ID;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class OldCapacitor : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 20);
            Item.rare = ItemRarityID.Blue;
            // Obtain method handled in TrinketGlobalNPC (ModifyShop)
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaRegenDelay = 60;
            // Logic handled in TrinketGlobalNPC (OnHitByProjectile)
            player.GetModPlayer<TrinketPlayer>().oldCapacitorAcc = true;
        }
	}
}
