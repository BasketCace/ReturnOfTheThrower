using Terraria;
using Terraria.ModLoader;
using ReturnOfTheThrower.Content.DamageClasses;

namespace ReturnOfTheThrower.Common.Players
{
    internal class ConsumeChancePlayer : ModPlayer
    {
        public bool wanderingAmmoCost90;
        public bool ninjaAmmoCost80;
        public bool crystalAmmoCost67;

        public override bool CanConsumeAmmo(Item weapon, Item ammo)
        {
            if (weapon.DamageType == DamageClass.Throwing || weapon.DamageType.GetEffectInheritance(DamageClass.Throwing) == true)
            {
                if (Main.rand.Next(10) == 0 && wanderingAmmoCost90) return false;
                if (Main.rand.Next(5) == 0 && ninjaAmmoCost80) return false;
                if (Main.rand.Next(3) == 0 && crystalAmmoCost67) return false;
            }
            return base.CanConsumeAmmo(weapon, ammo);
        }

        public override void ResetEffects()
        {
            wanderingAmmoCost90 = false;
            ninjaAmmoCost80 = false;
        }
    }
}
