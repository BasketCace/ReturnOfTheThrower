using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace ReturnOfTheThrower.Content.Items.Accessories
{
    public class ThrowingEmblem : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("15% increased throwing damage");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 28;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Throwing) *= 1.15f;
		}
	}
}
