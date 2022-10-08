using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using ReturnOfTheThrower.Content.Projectiles;
using Terraria.Audio;

namespace ReturnOfTheThrower.Common.Players
{
    internal class AncientTornadoPlayer : ModPlayer
    {
        public bool ancientArmorSet;
        public int ancientArmorTimer = 60;

        public override void PostItemCheck()
        {
            Item item = Main.LocalPlayer.HeldItem;
            if (ancientArmorSet == true && ancientArmorTimer == 0 && item.damage > 0 && Main.LocalPlayer.itemAnimation > 0 && (item.DamageType == DamageClass.Throwing || item.DamageType.GetEffectInheritance(DamageClass.Throwing) == true))
            {
                ancientArmorTimer = 60;
                Vector2 center = Main.LocalPlayer.Center;
                Vector2 vector = Player.DirectionTo(Player.ApplyRangeCompensation(0.2f, center, Main.MouseWorld)) * 10f;
                Projectile.NewProjectile(Player.GetSource_FromThis("RotT_Ancient"), center.X, center.Y - 10, vector.X, vector.Y, ModContent.ProjectileType<AncientTornado>(), 25, 5f, Main.LocalPlayer.whoAmI);
                SoundEngine.PlaySound(SoundID.Item20, center);
            }
        }

        public override void ResetEffects()
        {
            if (ancientArmorSet == true && ancientArmorTimer > 0)
            {
                ancientArmorTimer -= 1;
            }
            ancientArmorSet = false;
        }
    }
}
