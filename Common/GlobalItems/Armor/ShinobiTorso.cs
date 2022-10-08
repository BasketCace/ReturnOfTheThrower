using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class ShinobiTorso : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<Config.ThrowingClassConfig>().ThrowingShinobiArmor;
        }

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.MonkAltShirt;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "20% increased minion damage and throwing speed";
            }
            line = tooltips.FirstOrDefault(x => x.Name == "Tooltip1" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "5% increased throwing damage and critical strike chance";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetCritChance(DamageClass.Melee) -= 5;
            player.GetCritChance(DamageClass.Throwing) += 5;
            player.GetDamage(DamageClass.Throwing) += 0.05f;
            player.GetAttackSpeed(DamageClass.Melee) -= .2f;
            player.GetAttackSpeed(DamageClass.Throwing) += .2f;
        }
    }
}
