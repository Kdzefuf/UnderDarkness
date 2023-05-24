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
            this.projectileTextureUp = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\frozen_arrow_3");
            this.projectileTextureRight = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\frozen_arrow");
            this.projectileTextureLeft = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\frozen_arrow_5");
            this.projectileTextureDown = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\frozen_arrow_7");

            //hitMonster = Mediator.Game.Content.Load<SoundEffect>("Sounds/Hit");
            //hitWall = Mediator.Game.Content.Load<SoundEffect>("Sounds/HitWall");
        }
    }
}