using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;

namespace ReturnOfTheThrower.Content.Projectiles
{
    public class CursedCocktailProjectile : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Cocktail");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.MolotovCocktail);
            Projectile.DamageType = DamageClass.Throwing;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 7));
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 7));
        }

        public override void AI()
        {
            Vector2 vector51 = new Vector2(4f, -8f);
            float num573 = Projectile.rotation;
            if (Projectile.direction == -1)
            {
                vector51.X = -4f;
            }
            vector51 = vector51.RotatedBy(num573);
            for (int num574 = 0; num574 < 1; num574++)
            {
                int num575 = Dust.NewDust(Projectile.Center + vector51 - Vector2.One * 5f, 4, 4, DustID.CursedTorch);
                Main.dust[num575].scale = 1.5f;
                Main.dust[num575].noGravity = true;
                Main.dust[num575].velocity = Main.dust[num575].velocity * 0.25f + Vector2.Normalize(vector51) * 1f;
                Main.dust[num575].velocity = Main.dust[num575].velocity.RotatedBy(-(float)Math.PI / 2f * (float)Projectile.direction);
            }
        }

        public override void Kill(int timeLeft)
        {
            SoundStyle style = new SoundStyle("Terraria/Sounds/Shatter");
            SoundEngine.PlaySound(style, new Vector2((int)Projectile.position.X, (int)Projectile.position.Y));
            Vector2 vector43 = new Vector2(20f, 20f);
            for (int num407 = 0; num407 < 5; num407++)
            {
                Dust.NewDust(Projectile.Center - vector43 / 2f, (int)vector43.X, (int)vector43.Y, DustID.GemEmerald, 0f, 0f, 0, Color.Red);
            }
            for (int num408 = 0; num408 < 10; num408++)
            {
                int num409 = Dust.NewDust(Projectile.Center - vector43 / 2f, (int)vector43.X, (int)vector43.Y, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
                Dust dust = Main.dust[num409];
                dust.velocity *= 1.4f;
            }
            for (int num410 = 0; num410 < 20; num410++)
            {
                int num411 = Dust.NewDust(Projectile.Center - vector43 / 2f, (int)vector43.X, (int)vector43.Y, DustID.CursedTorch, 0f, 0f, 100, default(Color), 2.5f);
                Main.dust[num411].noGravity = true;
                Dust dust = Main.dust[num411];
                dust.velocity *= 5f;
                num411 = Dust.NewDust(Projectile.Center - vector43 / 2f, (int)vector43.X, (int)vector43.Y, DustID.CursedTorch, 0f, 0f, 100, default(Color), 1.5f);
                dust = Main.dust[num411];
                dust.velocity *= 3f;
            }
            if (Main.myPlayer == Projectile.owner)
            {
                for (int num412 = 0; num412 < 6; num412++)
                {
                    float num413 = (0f - Projectile.velocity.X) * (float)Main.rand.Next(20, 50) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
                    float num414 = (0f - Math.Abs(Projectile.velocity.Y)) * (float)Main.rand.Next(30, 50) * 0.01f + (float)Main.rand.Next(-20, 5) * 0.4f;
                    //Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X + num413, Projectile.Center.Y + num414, num413, num414, 400 + Main.rand.Next(3), (int)((double)Projectile.damage * 0.5), 0f, Projectile.owner);
                    var fire = ModContent.ProjectileType<CursedCocktailFire1>();

                    var firetype = Main.rand.Next(3);
                    switch(firetype)
                    {
                        case 0: fire = ModContent.ProjectileType<CursedCocktailFire1>();
                            break;
                        case 1: fire = ModContent.ProjectileType<CursedCocktailFire2>();
                            break;
                        case 2: fire = ModContent.ProjectileType<CursedCocktailFire3>();
                            break;
                    }

                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X + num413, Projectile.Center.Y + num414, num413, num414, fire, (int)((double)Projectile.damage * 0.5), 0f, Projectile.owner);
                }
            }
        }
    }

    public class CursedCocktailFire1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Cocktail");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.MolotovFire);
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.Opacity = 0;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 7));
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 7));
        }
        public override void AI()
        {

            if (Projectile.wet)
            {
                Projectile.Kill();
            }
            int num157 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100);
            Main.dust[num157].position.X -= 2f;
            Main.dust[num157].position.Y += 2f;
            Dust dust = Main.dust[num157];
            dust.scale += (float)Main.rand.Next(50) * 0.01f;
            Main.dust[num157].noGravity = true;
            Main.dust[num157].velocity.Y -= 2f;
            if (Main.rand.Next(2) == 0)
            {
                int num158 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100);
                Main.dust[num158].position.X -= 2f;
                Main.dust[num158].position.Y += 2f;
                dust = Main.dust[num158];
                dust.scale += 0.3f + (float)Main.rand.Next(50) * 0.01f;
                Main.dust[num158].noGravity = true;
                dust = Main.dust[num158];
                dust.velocity *= 0.1f;
            }
            if ((double)Projectile.velocity.Y < 0.25 && (double)Projectile.velocity.Y > 0.15)
            {
                Projectile.velocity.X *= 0.8f;
            }
            Projectile.rotation = (0f - Projectile.velocity.X) * 0.05f;

            //Projectile.ai[1 = Projectile.velocity.X;
            //Projectile.ai[2] = Projectile.velocity.Y;

            if (!Projectile.tileCollide)
            {
                var yvel = Projectile.velocity.Y;
                if (yvel >= 0 && yvel <= 4)
                {
                    Projectile.velocity.X *= 0.3f;
                }
            }
        }
    }

    public class CursedCocktailFire2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Cocktail");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.MolotovFire2);
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.Opacity = 0;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 7));
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 7));
        }
        public override void AI()
        {

            if (Projectile.wet)
            {
                Projectile.Kill();
            }
            int num157 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100);
            Main.dust[num157].position.X -= 2f;
            Main.dust[num157].position.Y += 2f;
            Dust dust = Main.dust[num157];
            dust.scale += (float)Main.rand.Next(50) * 0.01f;
            Main.dust[num157].noGravity = true;
            Main.dust[num157].velocity.Y -= 2f;
            if (Main.rand.Next(2) == 0)
            {
                int num158 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100);
                Main.dust[num158].position.X -= 2f;
                Main.dust[num158].position.Y += 2f;
                dust = Main.dust[num158];
                dust.scale += 0.3f + (float)Main.rand.Next(50) * 0.01f;
                Main.dust[num158].noGravity = true;
                dust = Main.dust[num158];
                dust.velocity *= 0.1f;
            }
            if ((double)Projectile.velocity.Y < 0.25 && (double)Projectile.velocity.Y > 0.15)
            {
                Projectile.velocity.X *= 0.8f;
            }
            Projectile.rotation = (0f - Projectile.velocity.X) * 0.05f;

            //Projectile.ai[1 = Projectile.velocity.X;
            //Projectile.ai[2] = Projectile.velocity.Y;

            if (!Projectile.tileCollide)
            {
                var yvel = Projectile.velocity.Y;
                if (yvel >= 0 && yvel <= 4)
                {
                    Projectile.velocity.X *= 0.3f;
                }
            }
        }
    }

    public class CursedCocktailFire3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Cocktail");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.MolotovFire3);
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.Opacity = 0;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 7));
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 7));
        }
        public override void AI()
        {

            if (Projectile.wet)
            {
                Projectile.Kill();
            }
            int num157 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100);
            Main.dust[num157].position.X -= 2f;
            Main.dust[num157].position.Y += 2f;
            Dust dust = Main.dust[num157];
            dust.scale += (float)Main.rand.Next(50) * 0.01f;
            Main.dust[num157].noGravity = true;
            Main.dust[num157].velocity.Y -= 2f;
            if (Main.rand.Next(2) == 0)
            {
                int num158 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100);
                Main.dust[num158].position.X -= 2f;
                Main.dust[num158].position.Y += 2f;
                dust = Main.dust[num158];
                dust.scale += 0.3f + (float)Main.rand.Next(50) * 0.01f;
                Main.dust[num158].noGravity = true;
                dust = Main.dust[num158];
                dust.velocity *= 0.1f;
            }
            if ((double)Projectile.velocity.Y < 0.25 && (double)Projectile.velocity.Y > 0.15)
            {
                Projectile.velocity.X *= 0.8f;
            }
            Projectile.rotation = (0f - Projectile.velocity.X) * 0.05f;

            //Projectile.ai[1 = Projectile.velocity.X;
            //Projectile.ai[2] = Projectile.velocity.Y;

            if (!Projectile.tileCollide)
            {
                var yvel = Projectile.velocity.Y;
                if (yvel >= 0 && yvel <= 4)
                {
                    Projectile.velocity.X *= 0.3f;
                }
            }
        }
    }

}
