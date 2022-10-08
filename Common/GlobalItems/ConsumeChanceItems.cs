using Terraria;
using Terraria.ModLoader;
using ReturnOfTheThrower.Common.Players;
using ReturnOfTheThrower.Content.DamageClasses;

namespace ReturnOfTheThrower.Common.GlobalItems
{
    internal class ConsumeChanceItems : GlobalItem
    {
        public override bool ConsumeItem(Item item, Player player)
        {
            if ((item.DamageType == DamageClass.Throwing || item.DamageType.GetEffectInheritance(DamageClass.Throwing) == true) && item.damage > 0)
            {
                if (Main.rand.Next(10) == 0 && player.GetModPlayer<ConsumeChancePlayer>().wanderingAmmoCost90) return false;
                if (Main.rand.Next(5) == 0 && player.GetModPlayer<ConsumeChancePlayer>().ninjaAmmoCost80) return false;
                if (Main.rand.Next(3) == 0 && player.GetModPlayer<ConsumeChancePlayer>().crystalAmmoCost67) return false;
            } 
            return base.ConsumeItem(item, player);
        }
    }
}
