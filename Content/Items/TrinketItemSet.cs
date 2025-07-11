using Terraria.ID;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Items.Trinkets
{
    // This [ReinitializeDuringResizeArrays] attribute will cause this class's static constructor to be called during the ResizeArrays step of mod loading. This is essential for any class with field initializers calling SetFactory methods.
    // This will allow the arrays to have the correct lengths after all content has been loaded into the game. This reinitialization happens before ModSystem.ResizeArrays, avoiding potential issues from mod load order.
    [ReinitializeDuringResizeArrays]
    public class TrinketItemSet
    {
        // Named ID set example. This will behave the same as any other ItemID.Sets array.
        public const string TrinketItemCustomSetKey = "IsaacTrinket";
        
        // To create a named ID set for items, we use the ItemID.Sets.Factory.CreateNamedSet method and provide a string key.
		// This is then optionally followed by the Decription method. The description explains how this mod uses the set. Other mods can view this description using the /customsets chat command.
		// By registering the set, other mods can access it the key. The key and default value must be consistent with other mods. Remember that the Mod name is part of the key that that other mods will be using to access this set.
		public static bool[] Trinket = ItemID.Sets.Factory.CreateNamedSet(TrinketItemCustomSetKey)
			.Description("Indicates that the item is a trinket which can be equipped in the trinket slot.")
			.RegisterBoolSet(false);

		// If sharing a custom ID set with other mods is not needed at all, the CreateXSet methods can be used to create a non-named custom ID set. Use this option for sets you are positive will never be accessed by other mods.
		// public static int[] UnsharedSetExample_SpicyLevel = ItemID.Sets.Factory.CreateIntSet(0, ItemID.PadThai, 5, ModContent.ItemType<ExampleFoodItem>(), 10);
    }
}