using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class GladiatorBreastplate : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.GladiatorBreastplate;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Defense" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text += "\n10% increased throwing knockback";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetKnockback(DamageClass.Throwing) += 0.1f;
        }
    }
}
