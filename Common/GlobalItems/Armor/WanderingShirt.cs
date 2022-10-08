using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class WanderingShirt : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.RoninShirt;
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
                line.Text = "Concept by crowflux" + "\n4% increased throwing damage";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetDamage(DamageClass.Throwing) += .04f;
        }
    }
}
