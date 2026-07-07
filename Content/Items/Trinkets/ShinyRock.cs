using Terraria;
using Terraria.ID;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class ShinyRock : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Blue;
            // Obtain method handled in TrinketModSystem (PostWorldGen)
        }

        public byte spelunkerTimer;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            spelunkerTimer++;
            if (spelunkerTimer >= 10)
            {
                spelunkerTimer = 0;
                Main.instance.SpelunkerProjectileHelper.AddSpotToCheck(player.Center);
            }
        }
    }
}
