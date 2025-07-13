using IsaacTrinkets.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace IsaacTrinkets.Content.Items
{
    public class TrinketGlobalItem : GlobalItem
    {
        public override void OnConsumeItem(Item item, Player player)
        {
            if (player.GetModPlayer<TrinketPlayer>().endlessNamelessAcc && item.consumable)
            {
                UnifiedRandom random = new UnifiedRandom();
                if (random.NextBool(10))
                {
                    item.stack += 1;
                }
            }
        }
    }
}