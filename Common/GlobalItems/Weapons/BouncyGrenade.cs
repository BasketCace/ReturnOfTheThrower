using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ReturnOfTheThrower.Content.DamageClasses;


namespace ReturnOfTheThrower.Common.GlobalItems.Weapons
{
    class BouncyGrenade : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.BouncyGrenade;
        }

        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<GrenadeDamageClass>();
        }
    }
}
