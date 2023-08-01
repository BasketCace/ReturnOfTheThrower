using System.Collections.Generic;
using Terraria.ModLoader;


namespace ReturnOfTheThrower.Content.DamageClasses
{
    public class GrenadeDamageClass : DamageClass
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("throwing damage");
        }
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Generic || damageClass == DamageClass.Throwing) return StatInheritanceData.Full;

            return StatInheritanceData.None;
        }
        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Throwing) return true;

            return false;
        }
    }
}
