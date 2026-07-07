using IsaacTrinkets.Common;
using Terraria;
using Terraria.ID;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class SwallowedM80 : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Blue;
            // Obtain method handled in TrinketModSystem (PostWorldGen)
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Logic handled in TrinketPlayer (PostHurt)
            player.GetModPlayer<TrinketPlayer>().swallowedM80Acc = true;
        }
    }
}
