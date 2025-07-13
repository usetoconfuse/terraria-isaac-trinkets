using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace IsaacTrinkets.Common
{
    public class TrinketGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        
        // Flag if this has triggered Brain Worm's effect
        private bool _brainWormTriggered = false;

        // Projectiles fired by a player using Brain Worm will sometimes turn 90 degrees to try and hit a missed target
        // This effect can occur once per projectile
        public override void AI(Projectile projectile)
        {
            // Check if the projectile was fired by a player who has Brain Worm equipped
            projectile.TryGetOwner(out Player player);
            if (player != null && projectile.friendly && Main.player[projectile.owner].GetModPlayer<TrinketPlayer>().brainWormAcc && !_brainWormTriggered)
            {
                // Find the direction of the nearest target
                int closestTargetIndex = projectile.FindTargetWithLineOfSight();
                if (closestTargetIndex >= 0)
                {
                    // Check if the nearest target is positioned roughly perpendicular to current velocity and whether the effect can be triggered
                    Vector2 closestTargetDirection = Main.npc[closestTargetIndex].position - projectile.position;
                    double dotProduct = double.Abs(Vector2.Dot(closestTargetDirection, projectile.velocity));
                    if (dotProduct < 100)
                    {
                        // 50/50 chance to trigger the effect, either way add the projectile to the triggered array
                        if (Main.rand.NextBool(2))
                        {
                            projectile.velocity = projectile.velocity.Length() * Vector2.Normalize(closestTargetDirection);
                        }
                        _brainWormTriggered = true;
                    }
                }
            }
        }
    }
}