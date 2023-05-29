using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс снаряда обычного ружья
    /// </summary>
    internal class SimpleGunProjectile : Projectile
    {
        /// <summary>
        /// Снаряд обычного ружья
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="direction">Направление</param>
        /// <param name="mediator">Посредник</param>
        public SimpleGunProjectile(int x, int y, Direction direction, Mediator mediator) : base(x, y, direction, mediator)
        {
            this.spriteHeight = 5;
            this.spriteWidth = 5;
            this.Damage = 75;
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            this.projectileTextureUp = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\simpleGun_bullet");
            this.projectileTextureRight = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\simpleGun_bullet");
            this.projectileTextureLeft = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\simpleGun_bullet");
            this.projectileTextureDown = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\simpleGun_bullet");

            hitMonster = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Shot");
            hitWall = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\bullet");
        }
    }
}