using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    internal class CrystalAssassinPants : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.CrystalNinjaLeggings;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "SetBonus" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "Set bonus: Allows the ability to dash" + "\n10 increased throwing damage and critical strike chance" + "\n33% chance to not consume thrown items";
            }
        }
    }
}
