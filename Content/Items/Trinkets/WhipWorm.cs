using IsaacTrinkets.Common;
using Terraria;
using Terraria.ID;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class WhipWorm : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Blue;
            // Obtain method handled in TrinketGlobalItem (ModifyItemLoot) and TrinketGlobalNPC (ModifyNPCLoot)
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Logic handled in TrinketPlayer (ModifyShootStats) - currently using same variable as BrokenSyringe so doesn't stack - would be better to have separate var for individual balancing
            player.GetModPlayer<TrinketPlayer>().speedBall = true;
        }
	}
}
