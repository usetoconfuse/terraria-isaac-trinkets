using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class CurvedHorn : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Blue;
            // Obtain method handled in TrinketGlobalItem (ModifyNPCLoot)
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += 0.06f;
        }
	}
}
