using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace IsaacTrinkets.UI
{
    [Autoload(Side = ModSide.Client)]
    public class TrinketSlotSystem : ModSystem
    {
        internal TrinketSlotState TrinketSlotState;

        private UserInterface _trinketSlotState;

        public override void Load()
        {
            TrinketSlotState = new TrinketSlotState();
            TrinketSlotState.Activate();
            _trinketSlotState = new UserInterface();
            _trinketSlotState.SetState(TrinketSlotState);
        }
        
        public override void UpdateUI(GameTime gameTime)
        {
            _trinketSlotState?.Update(gameTime);
        }
        
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "IsaacTrinkets: Trinkets from The Binding of Isaac: Rebirth",
                    delegate
                    {
                        _trinketSlotState.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}