using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using ReturnOfTheThrower.Util;
using Terraria.Audio;

namespace ReturnOfTheThrower.Content.Projectiles
{
    internal class AncientScarabProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            DisplayName.SetDefault("Ancient Scarab"); 
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 32;

            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Throwing; 
            Projectile.friendly = true; 
            Projectile.hostile = false; 
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false; 
            Projectile.timeLeft = 300; 
        }

        public override void AI()
        {
            if (Projectile.ai[1] >= 2) Projectile.ai[1] = 0;
            else Projectile.ai[1] += 1;
            if (Projectile.ai[1] == 2)
            {
                if (Projectile.frame >= 3) Projectile.frame = 0;
                else Projectile.frame++;
            }
            
            float maxDetectRadius = 400f; 
            
            NPC closestNPC = ProjectileUtil.FindClosestNPC(maxDetectRadius, Projectile.Center);
            if (closestNPC != null)
            {
                Projectile.velocity = Vector2.Lerp(Projectile.velocity, (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * Projectile.ai[0], 0.03f);
                Projectile.tileCollide = false;
            }
            else
            {
                Projectile.velocity = Vector2.Lerp(Projectile.velocity, Projectile.velocity.SafeNormalize(Vector2.Zero) * Projectile.ai[0], 0.03f);
                Projectile.tileCollide = true;
            }
        }
        public override void PostAI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Projectile.spriteDirection = Projectile.direction;
        }

        public override void Kill(int timeleft)
        {
            Projectile projectile = Projectile;
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Gold, 0, 0, 0, default(Color), 1);
            }
            SoundEngine.PlaySound(SoundID.NPCHit2, projectile.Center);
        }
    }
}
