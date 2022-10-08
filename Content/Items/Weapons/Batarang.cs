using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using ReturnOfTheThrower.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

namespace ReturnOfTheThrower.Content.Items.Weapons
{
    internal class Batarang : ModItem
    {
        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 2, silver: 50);

            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.useAnimation = 12;
            Item.useTime = 16;

            Item.damage = 52;
            Item.knockBack = 1.2f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;

            Item.shootSpeed = 15f;
            Item.shoot = ModContent.ProjectileType<BatarangLarge>();
        }
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            var smalltype = ModContent.ProjectileType<BatarangSmall>();
            Projectile.NewProjectile(player.GetSource_ItemUse(Item), position, 2 * velocity, smalltype, damage * 2 / 3, knockback, Main.myPlayer);
            var angle = MathHelper.Pi / 8;
            var dirX = velocity.X * Math.Cos(angle) - velocity.Y * Math.Sin(angle);
            var dirY = velocity.X * Math.Sin(angle) + velocity.Y * Math.Cos(angle);
            var newVel = new Vector2((float)dirX, (float)dirY);
            Projectile.NewProjectile(player.GetSource_ItemUse(Item), position, 2 * newVel, smalltype, damage * 2 / 3, knockback, Main.myPlayer);
            angle *= -1;
            dirX = velocity.X * Math.Cos(angle) - velocity.Y * Math.Sin(angle);
            dirY = velocity.X * Math.Sin(angle) + velocity.Y * Math.Cos(angle);
            newVel = new Vector2((float)dirX, (float)dirY);
            Projectile.NewProjectile(player.GetSource_ItemUse(Item), position, 2 * newVel, smalltype, damage * 2 / 3, knockback, Main.myPlayer);
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
