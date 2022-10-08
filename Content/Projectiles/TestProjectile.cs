using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReturnOfTheThrower.Content.Projectiles
{
    internal class TestProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
            Projectile.tileCollide = false;
            Projectile.timeLeft = 300;
            AIType = 0;
        }
    }
}
