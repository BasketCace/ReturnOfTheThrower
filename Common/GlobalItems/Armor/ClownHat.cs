using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ReturnOfTheThrower.Content.DamageClasses;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class ClownHat : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.ClownHat;
        }

        public override void SetDefaults(Item item)
        {
            item.vanity = false;
            item.defense = 4;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Defense" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text += "\n4% increased throwing damage";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetDamage(DamageClass.Throwing) += .04f;
        }

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ItemID.ClownHat && body.type == ItemID.ClownShirt && legs.type == ItemID.ClownPants) return "RotT Clown";
            return base.IsArmorSet(head, body, legs);
        }

        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "RotT Clown")
            {
                player.GetDamage(ModContent.GetInstance<GrenadeDamageClass>()) += .4f;
                player.setBonus = "Grenades deal 40% more damage";
            }
        }
    }
}
