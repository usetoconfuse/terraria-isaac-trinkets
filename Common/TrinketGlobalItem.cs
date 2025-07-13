using IsaacTrinkets.Common;
using Terraria;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Items
{
    public class TrinketGlobalItem : GlobalItem
    {
        public override void OnConsumeItem(Item item, Player player)
        {
            if (player.GetModPlayer<TrinketPlayer>().endlessNamelessAcc && item.consumable)
            {
                if (Main.rand.NextBool(10))
                {
                    item.stack += 1;
                }
            }
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            player.GetModPlayer<TrinketPlayer>().crackedCrownPrefixList.Add(item.prefix);
        }
    }
}