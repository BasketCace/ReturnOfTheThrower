using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ReturnOfTheThrower.Common.Players;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class CrystalAssassinShirt : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.CrystalNinjaChestplate;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "10% increased throwing damage";
            }
            line = tooltips.FirstOrDefault(x => x.Name == "Tooltip1" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "10% chance to not consume thrown items";
            }
            line = tooltips.FirstOrDefault(x => x.Name == "SetBonus" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "Set bonus: Allows the ability to dash" + "\n10 increased throwing damage and critical strike chance" + "\n33% chance to not consume thrown items";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetDamage(DamageClass.Generic) -= 0.05f;
            player.GetDamage(DamageClass.Throwing) += 0.1f;
            player.huntressAmmoCost90 = false;
            player.GetModPlayer<ConsumeChancePlayer>().wanderingAmmoCost90 = true;

        }
    }
}
