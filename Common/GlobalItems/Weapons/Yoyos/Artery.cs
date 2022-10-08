using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace ReturnOfTheThrower.Common.GlobalItems.Weapons
{
    class Artery : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<Config.ThrowingClassConfig>().ThrowingYoyoToggle;
        }
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.CrimsonYoyo;
        }

        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<ThrowingDamageClass>();
        }
    }
}
