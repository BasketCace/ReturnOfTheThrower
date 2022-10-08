using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReturnOfTheThrower.Content.Projectiles
{
    internal class MudBallProjectile : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ball of Mud");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.SnowBallFriendly);
			AIType = ProjectileID.SnowBallFriendly;
		}

        public override void Kill(int timeLeft)
        {
			for (int i = 0; i < 4; i++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Mud, 0, 0, 0, default(Color), 1);
			}
			SoundEngine.PlaySound(SoundID.NPCHit25, Projectile.Center);
		}
    }
}
