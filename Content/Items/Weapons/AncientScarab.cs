using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using ReturnOfTheThrower.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace ReturnOfTheThrower.Content.Items.Weapons
{
    internal class AncientScarab : ModItem
    {
        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(copper: 50);
            Item.maxStack = 9999;

            Item.consumable = true;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.useAnimation = 12;
            Item.useTime = 16;

            Item.damage = 34;
            Item.knockBack = 1.2f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;

            Item.shootSpeed = 10f;
            Item.shoot = ModContent.ProjectileType<AncientScarabProjectile>();
        }
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(player.GetSource_ItemUse(Item), position, velocity, type, damage, knockback, Main.myPlayer, Item.shootSpeed);

            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.AncientCloth, 1)
                .AddIngredient(ItemID.GoldBar, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            CreateRecipe(20)
                .AddIngredient(ItemID.AncientCloth, 1)
                .AddIngredient(ItemID.PlatinumBar, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
