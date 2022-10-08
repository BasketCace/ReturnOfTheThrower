using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class AncientGarments : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.AncientArmorShirt;
        }

        public override void SetDefaults(Item item)
        {
            item.vanity = false;
            item.defense = 8;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Defense" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = line.Text + "\n15% increased throwing knockback";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetKnockback(DamageClass.Throwing) += .15f;
        }
    }
}
