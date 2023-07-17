using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using ReturnOfTheThrower.Content.Projectiles;

using Terraria.GameContent.Creative;

namespace ReturnOfTheThrower.Content.Items.Weapons
{
    public class ThrowingStar : ModItem
    {
		public override void SetStaticDefaults()
		{

			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 14));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true; 


			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; 
		}

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 4);
            Item.maxStack = 9999;

            Item.consumable = true;
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.useAnimation = 12;
            Item.useTime = 19;

            Item.damage = 24;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;

            Item.shootSpeed = 10f;
            Item.shoot = ModContent.ProjectileType<ThrowingStarProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(5)
                .AddIngredient(ItemID.FallenStar, 4)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
