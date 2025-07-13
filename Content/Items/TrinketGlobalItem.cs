using IsaacTrinkets.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace IsaacTrinkets.Content.Items
{
    public class TrinketGlobalItem : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (player.GetModPlayer<TrinketPlayer>().crackedCrownAcc)
            {
                int prefix = item.prefix;
            }
        }

    }
}