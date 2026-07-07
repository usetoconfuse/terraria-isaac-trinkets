using IsaacTrinkets.Common;
using Terraria;
using Terraria.ID;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    public class Tick : TrinketItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Red;
            // Cannot currently be obtained without cheats as dequip prevention is unimplemented.
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Logic handled in TrinketGlobalNPC (OnSpawn)
            player.GetModPlayer<TrinketPlayer>().tickAcc = true;
        }
    }
}