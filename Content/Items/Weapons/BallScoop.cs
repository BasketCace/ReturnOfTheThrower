using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace ReturnOfTheThrower.Content.Items.Weapons
{
    public class BallScoop : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Throws snowballs with greater force");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.useTime = 20;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true; 
            Item.UseSound = SoundID.Item1;

            Item.DamageType = DamageClass.Throwing;
            Item.damage = 14;
            Item.knockBack = 2.5f;
            Item.noMelee = true;

            Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 9.5f;
            Item.useAmmo = AmmoID.Snowball;
        }
    }
}
