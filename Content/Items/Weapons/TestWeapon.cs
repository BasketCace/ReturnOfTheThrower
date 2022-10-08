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
    internal class TestWeapon : ModItem
    {
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.WoodenBoomerang);
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<TestProjectile>();

			Item.damage += 1;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			var angle = MathHelper.Pi / 8;
			var dirX = velocity.X * Math.Cos(angle) - velocity.Y * Math.Sin(angle);
			var dirY = velocity.X * Math.Sin(angle) + velocity.Y * Math.Cos(angle);
			var newVel = new Vector2((float)dirX, (float)dirY);
			Projectile.NewProjectile(player.GetSource_ItemUse(Item), position, newVel, type, damage, knockback, Main.myPlayer);
			angle *= -1;
			dirX = velocity.X * Math.Cos(angle) - velocity.Y * Math.Sin(angle);
			dirY = velocity.X * Math.Sin(angle) + velocity.Y * Math.Cos(angle);
			newVel = new Vector2((float)dirX, (float)dirY);
			Projectile.NewProjectile(player.GetSource_ItemUse(Item), position, newVel, type, damage, knockback, Main.myPlayer);
			return false;
		}
    }
}
