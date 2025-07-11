using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace IsaacTrinkets.UI
{
	public class TrinketSlot : ModAccessorySlot
	{
		public static LocalizedText TrinketSlotText { get; private set; }

		public override bool DrawVanitySlot => false;
		public override bool DrawDyeSlot => false;
		

		public override void SetupContent() {
			TrinketSlotText = Mod.GetLocalization($"{nameof(TrinketSlot)}.Trinket");
		}

		public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) {
			if (checkItem.wingSlot > 0) // if is Wing, then can go in slot
				return true;

			return false; // Otherwise nothing in slot
		}

		// Designates our slot to be a priority for putting wings in to. NOTE: use ItemLoader.CanEquipAccessory if aiming for restricting other slots from having wings!
		public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) {
			if (item.wingSlot > 0) // If is Wing, then we want to prioritize it to go in to our slot.
				return true;

			return false;
		}

		// Overrides the default behavior where a disabled accessory slot will allow retrieve items if it contains items
		public override bool IsVisibleWhenNotEnabled() {
			return false; // We set to false to just not display if not Enabled. NOTE: this does not affect behavior when mod is unloaded!
		}

		// Icon textures. Nominal image size is 32x32. Will be centered on the slot.
		public override string FunctionalTexture => "Terraria/Images/Item_" + ItemID.CreativeWings;

		// Can be used to modify stuff while the Mouse is hovering over the slot.
		public override void OnMouseHover(AccessorySlotType context) {
			// We will modify the hover text while an item is not in the slot, so that it says "Wings".
			switch (context) {
				case AccessorySlotType.FunctionalSlot:
				case AccessorySlotType.VanitySlot:
					Main.hoverItemName = TrinketSlotText.Value;
					break;
				case AccessorySlotType.DyeSlot:
					Main.hoverItemName = TrinketSlotText.Value;
					break;
			}
		}
	}
}