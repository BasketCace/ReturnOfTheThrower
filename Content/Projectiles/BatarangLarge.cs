using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReturnOfTheThrower.Content.Projectiles
{
    internal class BatarangLarge : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Batarang");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bananarang);
            Projectile.width = 28;
            Projectile.height = 48;
            Projectile.damage = 40;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 300;
            AIType = ProjectileID.Bananarang;
            Projectile.extraUpdates = 1;
        }
    }
}
