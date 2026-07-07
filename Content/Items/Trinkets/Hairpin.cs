using IsaacTrinkets.Common;
using Terraria;
using Terraria.ID;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class Hairpin : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Blue;
            // Obtain method handled in TrinketGlobalNPC (ModifyShop)
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Logic handled in TrinketGlobalNPC (OnSpawn) and HairpinBuff
            player.GetModPlayer<TrinketPlayer>().hairpinAcc = true;
        }
    }
}