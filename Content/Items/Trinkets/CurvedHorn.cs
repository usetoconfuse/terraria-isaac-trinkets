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
            Item.value = Item.buyPrice(silver: 1);
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += 0.06f;
        }
	}
}
