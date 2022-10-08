using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class FossilHelmet : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<Config.ThrowingClassConfig>().ThrowingFossilArmor;
        }
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.FossilHelm;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "4% increased throwing critical strike chance" + "\nIncreases armor penetration by 4";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetCritChance(DamageClass.Throwing) += 4;
            player.GetCritChance(DamageClass.Ranged) -= 4;
            player.GetArmorPenetration(DamageClass.Generic) += 4;
        }
    }
}
