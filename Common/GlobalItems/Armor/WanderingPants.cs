using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class WanderingPants : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.RoninPants;
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
                line.Text = "Concept by crowflux" + "\n4% increased movement speed";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.moveSpeed += .04f;
        }
    }
}
