using System.Linq;
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

        public override bool OnPickup(Item item, Player player)
        {
            // Mom's Locket - heart pickups heal more
            int[] heartPickups = {ItemID.Heart, ItemID.CandyApple, ItemID.CandyCane};
            if (player.GetModPlayer<TrinketPlayer>().momsLocketAcc && heartPickups.Contains(item.type))
            {
                player.Heal(20); // results in two separate healing texts - could improve by figuring out how to modify the initial amount
            }
            return base.OnPickup(item, player);
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