using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    // This is a basic item template.
    // Please see tModLoader's ExampleMod for every other example:
    // https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
    public class VibrantBulb : TrinketItem
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
            if (player.statLife == player.statLifeMax2)
            {
                player.statDefense += 4;
                player.GetDamage(DamageClass.Generic) += 0.04f;
                player.GetCritChance(DamageClass.Generic) += 4;
                player.equipmentBasedLuckBonus += 0.05f;

                player.moveSpeed += 0.05f;
            }
        }
    }
}
