using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    internal class FrozenBowProjectile : Projectile
    {
        public FrozenBowProjectile(int x, int y, Direction direction, Mediator mediator) : base(x, y, direction, mediator)
        {
            this.damage = 50;
        }

        public override void Load()
        {
            this.projectileTextureUp = Mediator.Game.Content.Load<Texture2D>("Projectiles/FrozenBowProjectile/icicle_0");
            this.projectileTextureRight = Mediator.Game.Content.Load<Texture2D>("Projectiles/FrozenBowProjectile/icicle_2");
            this.projectileTextureLeft = Mediator.Game.Content.Load<Texture2D>("Projectiles/FrozenBowProjectile/icicle_6");
            this.projectileTextureDown = Mediator.Game.Content.Load<Texture2D>("Projectiles/FrozenBowProjectile/icicle_4");

            hitMonster = Mediator.Game.Content.Load<SoundEffect>("Sounds/Hit");
            hitWall = Mediator.Game.Content.Load<SoundEffect>("Sounds/HitWall");
        }
    }
}