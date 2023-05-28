using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс снаряда посоха
    /// </summary>
    internal class StaffProjectile : Projectile
    {
        /// <summary>
        /// Снаряд посоха
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="direction">Направление</param>
        /// <param name="mediator">Посредник</param>
        public StaffProjectile(int x, int y, Direction direction, Mediator mediator) : base(x, y, direction, mediator)
        {
            this.damage = 100;
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
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