using IsaacTrinkets.Common;
using Terraria;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Buffs
{
    public abstract class BrokenSyringeBuff : TrinketBuff
    {
        public override bool GetTrinketBool(Player player)
        {
            return player.GetModPlayer<TrinketPlayer>().brokenSyringeAcc;
        }
    }

    public class AdrenalineBuff : BrokenSyringeBuff
    {
        public override void BuffEffect(Player player)
        {
            float missingLifePercentage = 1 - ((float)player.statLife / (float)player.statLifeMax2);
            player.GetDamage(DamageClass.Generic) += 0.2f * missingLifePercentage * missingLifePercentage;
        }
    }

    public class GrowthHormonesBuff : BrokenSyringeBuff
    {
        public override void BuffEffect(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.moveSpeed += 0.05f;
        }
    }

    public class RoidRageBuff : BrokenSyringeBuff
    {
        public override void BuffEffect(Player player)
        {
            player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
            player.moveSpeed += 0.1f;
        }
    }

    public class SpeedBallBuff : BrokenSyringeBuff
    {
        public override void BuffEffect(Player player)
        {
            player.GetModPlayer<TrinketPlayer>().speedBall = true;
            player.moveSpeed += 0.1f;
        }
    }
    
    public class SynthoilBuff : BrokenSyringeBuff
	{
        public override void BuffEffect(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 5;
        }
	}
}
