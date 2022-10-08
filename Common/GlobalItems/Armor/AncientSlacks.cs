using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class AncientSlacks : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.AncientArmorPants;
        }

        public override void SetDefaults(Item item)
        {
            item.vanity = false;
            item.defense = 6;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Defense" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = line.Text + "\n10% increased throwing damage";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetDamage(DamageClass.Throwing) += .10f;
        }
    }
}
