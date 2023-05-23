using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    internal class SimpleGunProjectile : Projectile
    {
        public SimpleGunProjectile(int x, int y, Direction direction, Mediator mediator) : base(x, y, direction, mediator)
        {
            this.Damage = 75;
        }

        public override void Load()
        {
            this.projectileTextureUp = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\simpleGun");
            //this.projectileTextureRight = Mediator.Game.Content.Load<Texture2D>("Projectiles/SimpleGunProjectile/iron_shot_2");
            //this.projectileTextureLeft = Mediator.Game.Content.Load<Texture2D>("Projectiles/SimpleGunProjectile/iron_shot_6");
            //this.projectileTextureDown = Mediator.Game.Content.Load<Texture2D>("Projectiles/SimpleGunProjectile/iron_shot_4");

            //hitMonster = Mediator.Game.Content.Load<SoundEffect>("Sounds/Hit");
            //hitWall = Mediator.Game.Content.Load<SoundEffect>("Sounds/HitWall");
        }
    }
}