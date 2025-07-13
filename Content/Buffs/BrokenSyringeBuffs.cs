using IsaacTrinkets.Common;
using Terraria;
using Terraria.ModLoader;

namespace IsaacTrinkets.Content.Buffs
{
    public class AdrenalineBuff : ModBuff
    {
        public override bool RightClick(int buffIndex)
        {
            return false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<TrinketPlayer>().brokenSyringeAcc)
            {
                float missingLifePercentage = 1 - ((float)player.statLife / (float)player.statLifeMax2);
                player.GetDamage(DamageClass.Generic) += 0.2f * missingLifePercentage * missingLifePercentage;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }

    public class GrowthHormonesBuff : ModBuff
    {
        public override bool RightClick(int buffIndex)
        {
            return false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<TrinketPlayer>().brokenSyringeAcc)
            {
                player.GetDamage(DamageClass.Generic) += 0.05f;
                player.moveSpeed += 0.05f;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }

    public class RoidRageBuff : ModBuff
    {
        public override bool RightClick(int buffIndex)
        {
            return false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<TrinketPlayer>().brokenSyringeAcc)
            {
                player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
                player.moveSpeed += 0.1f;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }

    public class SpeedBallBuff : ModBuff
    {
        public override bool RightClick(int buffIndex)
        {
            return false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<TrinketPlayer>().brokenSyringeAcc)
            {
                player.GetModPlayer<TrinketPlayer>().speedBall = true;
                player.moveSpeed += 0.1f;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
    
    public class SynthoilBuff : ModBuff
	{
        public override bool RightClick(int buffIndex)
        {
            return false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<TrinketPlayer>().brokenSyringeAcc)
            {
                player.GetDamage(DamageClass.Generic) += 0.05f;
                player.GetCritChance(DamageClass.Generic) += 5;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
	}
}
