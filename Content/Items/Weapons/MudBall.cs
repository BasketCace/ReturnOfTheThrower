using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using ReturnOfTheThrower.Content.Projectiles;

namespace ReturnOfTheThrower.Content.Items.Weapons
{
    public class MudBall : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ball of Mud");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Snowball);

			Item.shoot = ModContent.ProjectileType<MudBallProjectile>(); 

			Item.damage += 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe(15)
				.AddIngredient(ItemID.MudBlock)
				.Register();
		}
	}
}
