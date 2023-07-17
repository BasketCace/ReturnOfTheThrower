using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using ReturnOfTheThrower.Content.Projectiles;

namespace ReturnOfTheThrower.Content.Items.Weapons
{
    public class CursedCocktail : ModItem
    {
		public override void SetStaticDefaults()
		{

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.MolotovCocktail);

			Item.shoot = ModContent.ProjectileType<CursedCocktailProjectile>();

			Item.damage = 32;
		}

		public override void AddRecipes()
		{
			CreateRecipe(10)
				.AddIngredient(ItemID.Ale, 10)
				.AddIngredient(ItemID.Gel, 2)
				.AddIngredient(ItemID.Silk, 2)
				.AddIngredient(ItemID.CursedTorch)
				.Register();
		}
	}
}
