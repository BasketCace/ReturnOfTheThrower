using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;

namespace ReturnOfTheThrower.Content.Projectiles
{
    public class ThrowingStarProjectile : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 14;
            // DisplayName.SetDefault("Throwing Star");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.StarCannonStar);
            Projectile.DamageType = DamageClass.Throwing;
        }

        public override void AI()
        {
            if (Projectile.frame >= 13) Projectile.frame = 0;
            else Projectile.frame++;


            Vector2 vector10 = new Vector2(Main.screenWidth, Main.screenHeight);
            if (Projectile.Hitbox.Intersects(Utils.CenteredRectangle(Main.screenPosition + vector10 / 2f, vector10 + new Vector2(400f))) && Main.rand.Next(6) == 0)
            {
                int num78 = Utils.SelectRandom<int>(Main.rand, 16, 17, 17, 17);
                if (Main.tenthAnniversaryWorld)
                {
                    num78 = Utils.SelectRandom<int>(Main.rand, 16, 16, 16, 17);
                }
                Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity * 0.2f, num78);
            }
            //Projectile.light = 0.9f;
            if (Main.rand.Next(20) == 0 || (Main.tenthAnniversaryWorld && Main.rand.Next(15) == 0))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 150, default(Color), 1.2f);
            }
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

            Color newColor7 = Color.CornflowerBlue;
            if (Main.tenthAnniversaryWorld && (Projectile.type == 12 || Projectile.type == 955))
            {
                newColor7 = Color.HotPink;
                newColor7.A /= 2;
            }
            for (int num613 = 0; num613 < 7; num613++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 58, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 150, default(Color), 0.8f);
            }
            for (float num614 = 0f; num614 < 1f; num614 += 0.125f)
            {
                Dust.NewDustPerfect(Projectile.Center, 278, Vector2.UnitY.RotatedBy(num614 * ((float)Math.PI * 2f) + Main.rand.NextFloat() * 0.5f) * (4f + Main.rand.NextFloat() * 4f), 150, newColor7).noGravity = true;
            }
            for (float num615 = 0f; num615 < 1f; num615 += 0.25f)
            {
                Dust.NewDustPerfect(Projectile.Center, 278, Vector2.UnitY.RotatedBy(num615 * ((float)Math.PI * 2f) + Main.rand.NextFloat() * 0.5f) * (2f + Main.rand.NextFloat() * 3f), 150, Color.Gold).noGravity = true;
            }
            Vector2 vector52 = new Vector2(Main.screenWidth, Main.screenHeight);
            if (Projectile.Hitbox.Intersects(Utils.CenteredRectangle(Main.screenPosition + vector52 / 2f, vector52 + new Vector2(400f))))
            {
                for (int num616 = 0; num616 < 7; num616++)
                {
                    Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, Main.rand.NextVector2CircularEdge(0.5f, 0.5f) * Projectile.velocity.Length(), Utils.SelectRandom<int>(Main.rand, 16, 17, 17, 17, 17, 17, 17, 17));
                }
            }
        }

    }
}
