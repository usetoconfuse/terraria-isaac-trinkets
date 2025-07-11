using IsaacTrinkets.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Items
{ 
	// This [ReinitializeDuringResizeArrays] attribute will cause this class's static constructor to be called during the ResizeArrays step of mod loading. This is essential for any class with field initializers calling SetFactory methods.
	// This will allow the arrays to have the correct lengths after all content has been loaded into the game. This reinitialization happens before ModSystem.ResizeArrays, avoiding potential issues from mod load order.
	[ReinitializeDuringResizeArrays]
	public abstract class TrinketItem : ModItem
	{
		// Named ID set. This will behave the same as any other ItemID.Sets array.
		public const string TrinketItemCustomSetKey = "IsaacTrinket";
        
		// To create a named ID set for items, we use the ItemID.Sets.Factory.CreateNamedSet method and provide a string key.
		// This is then optionally followed by the Decription method. The description explains how this mod uses the set. Other mods can view this description using the /customsets chat command.
		// By registering the set, other mods can access it the key. The key and default value must be consistent with other mods. Remember that the Mod name is part of the key that that other mods will be using to access this set.
		public static bool[] IsTrinket = ItemID.Sets.Factory.CreateNamedSet(TrinketItemCustomSetKey)
			.Description("Indicates that the item is a trinket which can be equipped in the trinket slot.")
			.RegisterBoolSet(false);

		public override void SetStaticDefaults()
		{
			IsTrinket[Type] = true;
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
				int trinketSlot = LoaderManager.Get<AccessorySlotLoader>().Get(ModContent.GetInstance<TrinketSlot>().Type, player).Type;

				//Main.NewText("Modded slot: " + moddedSlot.ToString() + ", Selected slot: " + slot.ToString(), 255, 255, 255);

				if (trinketSlot == slot)
				{
					return true;
				}
			}
			
			return false;
		}
	}
}
