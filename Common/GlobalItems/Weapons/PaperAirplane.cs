using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace ReturnOfTheThrower.Common.GlobalItems.Weapons
{
    class PaperAirplane : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.PaperAirplaneA;
        }

        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<ThrowingDamageClass>();
        }
    }
}
