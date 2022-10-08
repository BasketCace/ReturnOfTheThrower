using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ReturnOfTheThrower.Common.Players;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class CrystalAssassinHood : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.CrystalNinjaHelmet;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "10% increased throwing critical strike chance";
            }
            line = tooltips.FirstOrDefault(x => x.Name == "Tooltip1" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "5% increased throwing damage";
            }
            line = tooltips.FirstOrDefault(x => x.Name == "SetBonus" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "Set bonus: Allows the ability to dash" +"\n10 increased throwing damage and critical strike chance" + "\n33% chance to not consume thrown items";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.05f;
            player.GetCritChance(DamageClass.Generic) -= 5;
            player.GetCritChance(DamageClass.Throwing) += 5;
            player.manaCost *= 1.11111111f;
        }

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ItemID.CrystalNinjaHelmet && body.type == ItemID.CrystalNinjaChestplate && legs.type == ItemID.CrystalNinjaLeggings) return "RotT Cystal";
            return base.IsArmorSet(head, body, legs);
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "RotT Cystal")
            {
                player.GetModPlayer<ConsumeChancePlayer>().crystalAmmoCost67 = true;
                player.GetDamage(DamageClass.Generic) -= 0.1f;
                player.GetCritChance(DamageClass.Generic) -= 10;
                player.GetDamage(DamageClass.Throwing) += 0.1f;
                player.GetCritChance(DamageClass.Throwing) += 10;
            }
        }
    }
}
