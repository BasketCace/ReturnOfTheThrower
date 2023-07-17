using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using ReturnOfTheThrower.Util;

namespace ReturnOfTheThrower.Content.Projectiles
{
    internal class AncientTornado : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 8;
            DisplayName.SetDefault("Sandnado");
        }
        public override void SetDefaults()
        {
			Projectile.width = 58;
			Projectile.height = 62;
			//       Projectile.aiStyle = ProjectileID.WeatherPainShot;
			AIType = 0;
			Projectile.friendly = true; 
			Projectile.hostile = false;
			Projectile.DamageType = ModContent.GetInstance<ThrowingDamageClass>();
			Projectile.damage = 30;
			Projectile.knockBack = 1;
			Projectile.penetrate = 12;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.timeLeft = 400;
			Projectile.Opacity = 100;
		}

        public override void AI()
        {
			if (Projectile.frame >= 7) Projectile.frame = 0;
			else Projectile.frame++;

			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Sand, 0, 0, 0, default(Color), 1);

			float maxDetectRadius = 300f;
			float projSpeed = 14f;

			NPC closestNPC = ProjectileUtil.FindClosestNPC(maxDetectRadius, Projectile.Center);

			if (closestNPC != null) Projectile.tileCollide = false;
			else Projectile.tileCollide = true;

			if (closestNPC != null) Projectile.velocity = Vector2.Lerp(Projectile.velocity, (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed, 0.1f);
			else Projectile.velocity = Vector2.Lerp(Projectile.velocity, Projectile.velocity.SafeNormalize(Vector2.Zero) * projSpeed, 0.2f);
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate -= 2;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
			else
			{
				Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
				if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
			}

			return false;
		}

		public override void Kill(int timeleft)
		{
			for (int g = 0; g < 2; g++)
			{
				Projectile projectile = Projectile;
				int goreIndex = Gore.NewGore(projectile.GetSource_FromThis(), new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
				goreIndex = Gore.NewGore(projectile.GetSource_FromThis(), new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
				goreIndex = Gore.NewGore(projectile.GetSource_FromThis(), new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
				goreIndex = Gore.NewGore(projectile.GetSource_FromThis(), new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
			}
		}
	}
}
