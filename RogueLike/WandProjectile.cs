using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    internal class StaffProjectile : Projectile
    {
        public StaffProjectile(int x, int y, Direction direction, Mediator mediator) : base(x, y, direction, mediator)
        {
            this.damage = 100;
        }

        public override void Load()
        {
            this.projectileTextureUp = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\staff_fire");
            this.projectileTextureRight = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\staff_fire");
            this.projectileTextureLeft = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\staff_fire");
            this.projectileTextureDown = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\staff_fire");

            //hitMonster = Mediator.Game.Content.Load<SoundEffect>("Sounds/Hit");
            //hitWall = Mediator.Game.Content.Load<SoundEffect>("Sounds/HitWall");
        }
    }
}