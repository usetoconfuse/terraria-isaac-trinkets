using IsaacTrinkets.Content.Items.Trinkets;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Common
{
    public class TrinketGlobalItem : GlobalItem
    {
        public override void OnConsumeItem(Item item, Player player)
        {
            // Endless Nameless - chance to refund item consumption
            if (player.GetModPlayer<TrinketPlayer>().endlessNamelessAcc && item.consumable)
            {
                if (Main.rand.NextBool(10))
                {
                    item.stack += 1;
                }
            }
        }

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            // Worm Trinkets - Can of Worms drop
            if (item.type == ItemID.CanOfWorms)
            {
                itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(20, ModContent.ItemType<BrainWorm>(), ModContent.ItemType<WhipWorm>()));
            }
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            // Cracked Crown - Get equipped accessory prefixes
            player.GetModPlayer<TrinketPlayer>().crackedCrownPrefixList.Add(item.prefix);
        }
    }
}