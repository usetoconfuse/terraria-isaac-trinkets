using IsaacTrinkets.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class VibrantBulb : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Blue;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<DimBulb>();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Logic handled in TrinketPlayer (PostUpdateBuffs) and VibrantBulbBuff
            player.GetModPlayer<TrinketPlayer>().vibrantBulbAcc = true;
        }
    }
}
