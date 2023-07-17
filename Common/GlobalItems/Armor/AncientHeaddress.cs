using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ReturnOfTheThrower.Common.Players;


namespace ReturnOfTheThrower.Common.GlobalItems.Armor
{
    class AncientHeaddress : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.AncientArmorHat;
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

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ItemID.AncientArmorHat && body.type == ItemID.AncientArmorShirt && legs.type == ItemID.AncientArmorPants) return "RotT_Ancient";
            return base.IsArmorSet(head, body, legs);
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetDamage(DamageClass.Throwing) += .10f;
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "RotT_Ancient")
            {
                //player.huntressAmmoCost90 = true;
                //player.setBonus = "10% chance to not consume ammo";
                player.GetModPlayer<AncientTornadoPlayer>().ancientArmorSet = true;
                player.setBonus = "Throwing weapons will create homing tornadoes";
            }
        }
    }
}
