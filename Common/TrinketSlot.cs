﻿using IsaacTrinkets.Content.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace IsaacTrinkets.Common
{
	public class TrinketSlot : ModAccessorySlot
	{
		public static LocalizedText TrinketSlotText { get; private set; }
		public override Vector2? CustomLocation => new Vector2(AccessorySlotLoader.DefenseIconPosition.X -141, AccessorySlotLoader.DrawVerticalAlignment + 242);

		public override bool DrawVanitySlot => false;
		public override bool DrawDyeSlot => false;

		public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back2";

		// Icon textures. Nominal image size is 32x32. Will be centered on the slot.
		public override string FunctionalTexture => "IsaacTrinkets/Assets/Textures/TrinketSlot";
		
		public override void SetupContent()
		{
			TrinketSlotText = Mod.GetLocalization($"{nameof(TrinketSlot)}.Trinket");
		}
		
		public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
		{
			return TrinketItem.IsTrinket[checkItem.type];
		}

		public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo)
		{
			return TrinketItem.IsTrinket[item.type];
		}

		// Can be used to modify stuff while the Mouse is hovering over the slot.
		public override void OnMouseHover(AccessorySlotType context) {
			// We will modify the hover text while an item is not in the slot, so that it says "Wings".
			Main.hoverItemName = TrinketSlotText.Value;
		}
	}
}