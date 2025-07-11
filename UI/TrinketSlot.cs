using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace IsaacTrinkets.UI
{
	public class TrinketSlot : ModAccessorySlot
	{
		// Helper function to check if a ModItem is a TrinketItem
		private bool IsTrinket(Item checkItem)
		{
			ModItem thisItem = ItemLoader.GetItem(checkItem.type);

			if (thisItem != null)
			{
				if (thisItem.ToString().StartsWith("IsaacTrinkets.Content.Items.Trinkets."))
				{
					return true;
				}
			}
			return false;
		}
		
		public static LocalizedText TrinketSlotText { get; private set; }

		public override bool DrawVanitySlot => false;
		public override bool DrawDyeSlot => false;
		
		public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
		{
			return IsTrinket(checkItem);
		}

		public override void SetupContent()
		{
			TrinketSlotText = Mod.GetLocalization($"{nameof(TrinketSlot)}.Trinket");
		}

		public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo)
		{
			return IsTrinket(item);
		}

		// Icon textures. Nominal image size is 32x32. Will be centered on the slot.
		public override string FunctionalTexture => "Terraria/Images/Mana";

		// Can be used to modify stuff while the Mouse is hovering over the slot.
		public override void OnMouseHover(AccessorySlotType context) {
			// We will modify the hover text while an item is not in the slot, so that it says "Wings".
			Main.hoverItemName = TrinketSlotText.Value;
		}
	}
}