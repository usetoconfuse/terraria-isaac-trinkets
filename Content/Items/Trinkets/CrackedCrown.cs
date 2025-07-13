using System;
using System.Collections.Generic;
using IsaacTrinkets.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    // This is a basic item template.
    // Please see tModLoader's ExampleMod for every other example:
    // https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
    public class CrackedCrown : TrinketItem
    {
        // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.IsaacTrinkets.hjson' file.
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.buyPrice(silver: 1);
            Item.rare = ItemRarityID.Blue;
        }

        public float statBoosterScale = 0.25f;
        public int crownDefense = 0;
        public int crownCritChance = 0;
        public int crownDamage = 0;
        public int crownMoveSpeed = 0;
        public int crownMeleeSpeed = 0;
        public int crownMana = 0;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            List<int> prefixList = player.GetModPlayer<TrinketPlayer>().crackedCrownPrefixList;
            int totalDefense = 0;
            int totalCritChance = 0;
            int totalDamage = 0;
            int totalMoveSpeed = 0;
            int totalMeleeSpeed = 0;
            int totalMana = 0;
            for (int i = 0; i < prefixList.Count; i++)
            {
                int prefix = prefixList[i];
                switch (prefix)
                {
                    case 62: //Hard
                        totalDefense += 1;
                        break;
                    case 63: //Guarding
                        totalDefense += 2;
                        break;
                    case 64: //Armored
                        totalDefense += 3;
                        break;
                    case 65: //Warding
                        totalDefense += 4;
                        break;
                    case 66: //Arcane
                        totalMana += 20;
                        break;
                    case 67: //Precise
                        totalCritChance += 2;
                        break;
                    case 68: //Lucky
                        totalCritChance += 4;
                        break;
                    case 69: //Jagged
                        totalDamage += 1;
                        break;
                    case 70: //Spiked
                        totalDamage += 2;
                        break;
                    case 71: //Angry
                        totalDamage += 3;
                        break;
                    case 72: //Menacing
                        totalDamage += 4;
                        break;
                    case 73: //Brisk
                        totalMoveSpeed += 1;
                        break;
                    case 74: //Fleeting
                        totalMoveSpeed += 2;
                        break;
                    case 75: //Hasty
                        totalMoveSpeed += 3;
                        break;
                    case 76: //Quick
                        totalMoveSpeed += 4;
                        break;
                    case 77: //Wild
                        totalMeleeSpeed += 1;
                        break;
                    case 78: //Rash
                        totalMeleeSpeed += 2;
                        break;
                    case 79: //Intrepid
                        totalMeleeSpeed += 3;
                        break;
                    case 80: //Violent
                        totalMeleeSpeed += 4;
                        break;

                }
            }
            crownDefense = (int)(totalDefense * statBoosterScale);
            crownCritChance = (int)(totalCritChance * statBoosterScale);
            crownDamage = (int)(totalDamage * statBoosterScale);
            crownMoveSpeed = (int)(totalMoveSpeed * statBoosterScale);
            crownMeleeSpeed = (int)(totalMeleeSpeed * statBoosterScale);
            crownMana = (int)(totalMana * statBoosterScale);

            player.statDefense += crownDefense;
            player.GetCritChance(DamageClass.Generic) += crownCritChance;
            player.GetDamage(DamageClass.Generic) += crownDamage * 0.01f;
            player.moveSpeed += crownMoveSpeed * 0.01f;
            player.GetAttackSpeed(DamageClass.Melee) += crownMeleeSpeed * 0.01f;
            player.statManaMax2 += crownMana;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            List<string> tooltiplist = new List<string>();
            if (crownDefense > 0)
            {
                tooltiplist.Add("+" + crownDefense.ToString() + " defense");
            }
            if (crownCritChance > 0)
            {
                tooltiplist.Add("+" + crownCritChance.ToString() + "% critical strike chance");
            }
            if (crownDamage > 0)
            {
                tooltiplist.Add("+" + crownDamage.ToString() + "% damage");
            }
            if (crownMoveSpeed > 0)
            {
                tooltiplist.Add("+" + crownMoveSpeed.ToString() + "% movement speed");
            }
            if (crownMeleeSpeed > 0)
            {
                tooltiplist.Add("+" + crownMeleeSpeed.ToString() + "% melee speed");
            }
            if (crownMana > 0)
            {
                tooltiplist.Add("+" + crownMana.ToString() + " maximum mana");
            }
            string tooltip = String.Join(", ", tooltiplist.ToArray());
            tooltips[3] = new TooltipLine(Mod, "Crown", tooltip);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
