using System.Linq;
using IsaacTrinkets.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Items.Trinkets
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public abstract class TrinketItem : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.IsaacTrinkets.hjson' file.

		public override void SetStaticDefaults()
		{
			TrinketItemSet.Trinket[Type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
		}

		public override bool CanEquipAccessory(Player player, int slot, bool modded)
		{
			if (modded)
			{
				int moddedSlot = LoaderManager.Get<AccessorySlotLoader>().Get(ModContent.GetInstance<TrinketSlot>().Type, player).Type;

				//Main.NewText("Modded slot: " + moddedSlot.ToString() + ", Selected slot: " + slot.ToString(), 255, 255, 255);

				if (moddedSlot == slot)
				{
					return true;
				}
			}
			
			return false;
		}
	}
}
