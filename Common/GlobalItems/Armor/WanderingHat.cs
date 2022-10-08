using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ReturnOfTheThrower.Common.Players;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class WanderingHat : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.RoninHat;
        }

        public override void SetDefaults(Item item)
        {
            item.vanity = false;
            item.defense = 1;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip1" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "Concept by crowflux" + "\n3% increased throwing critical strike chance";
            }
        }

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ItemID.RoninHat && body.type == ItemID.RoninShirt && legs.type == ItemID.RoninPants) return "RotT Ronin";
            return base.IsArmorSet(head, body, legs);
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetCritChance(DamageClass.Throwing) += 3;
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "RotT Ronin")
            {
                player.GetModPlayer<ConsumeChancePlayer>().wanderingAmmoCost90 = true;
                player.setBonus = "10% chance to not consume thrown items";
            }
        }
    }
}
