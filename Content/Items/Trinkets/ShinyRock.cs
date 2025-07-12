using Terraria;
using Terraria.ID;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    // This is a basic item template.
    // Please see tModLoader's ExampleMod for every other example:
    // https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
    public class ShinyRock : TrinketItem
    {
        // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.IsaacTrinkets.hjson' file.
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(silver: 1);
            Item.rare = ItemRarityID.Blue;
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
