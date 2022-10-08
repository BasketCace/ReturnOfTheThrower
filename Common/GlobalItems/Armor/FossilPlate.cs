using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class FossilPlate : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<Config.ThrowingClassConfig>().ThrowingFossilArmor;
        }
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.FossilShirt;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "5% increased throwing damage" + "\n15% increased throwing critical strike chance";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.05f;
            player.GetDamage(DamageClass.Ranged) -= 0.05f;
            player.GetCritChance(DamageClass.Throwing) += 15;
        }
    }
}
