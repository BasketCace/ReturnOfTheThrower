using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace ReturnOfTheThrower.Common.GlobalItems.Weapons
{
    class Daybreak : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<Config.ThrowingClassConfig>().ThrowingDaybreakToggle;
        }

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.DayBreak;
        }

        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<ThrowingDamageClass>();
        }
    }
}
