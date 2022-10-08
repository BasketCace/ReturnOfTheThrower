using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReturnOfTheThrower.Content.Projectiles
{
    internal class BatarangSmall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Batarang");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Shuriken);
            Projectile.width = 18;
            Projectile.height = 32;
            Projectile.damage = 20;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 40;
            AIType = ProjectileID.Bananarang;
        }
    }
}
