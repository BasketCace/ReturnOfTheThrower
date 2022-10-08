using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ReturnOfTheThrower.Content.DamageClasses;


namespace ReturnOfTheThrower.Common.GlobalItems.Weapons
{
    class HappyGrenade : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.PartyGirlGrenade;
        }

        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<GrenadeDamageClass>();
        }
    }
}
