using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ReturnOfTheThrower.Common.Players;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class NinjaHood : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.NinjaHood;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "3% increased throwing critical strike chance" + "\nIncreases armor penetration by 3";
            }
            line = tooltips.FirstOrDefault(x => x.Name == "SetBonus" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "Set bonus: 20% increased movement speed" + "\n20% chance to not consume thrown items";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetCritChance(DamageClass.Generic) -= 3;
            player.GetCritChance(DamageClass.Throwing) += 3;
            player.GetArmorPenetration(DamageClass.Generic) += 3;
        }

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ItemID.NinjaHood && body.type == ItemID.NinjaShirt && legs.type == ItemID.NinjaPants) return "RotT Ninja";
            return base.IsArmorSet(head, body, legs);
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "RotT Ninja")
            {
                player.GetModPlayer<ConsumeChancePlayer>().ninjaAmmoCost80 = true;
            }
        }
    }
}
