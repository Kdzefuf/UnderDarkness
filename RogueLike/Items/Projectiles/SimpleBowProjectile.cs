using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс снаряда обычного лука
    /// </summary>
    internal class SimpleBowProjectile : Projectile
    {
        /// <summary>
        /// Снаряд обычного лука
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="direction">Направление</param>
        /// <param name="mediator">Посредник</param>
        public SimpleBowProjectile(int x, int y, Direction direction, Mediator mediator) : base(x, y, direction, mediator)
        {
            this.damage = 50;
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            projectileTextureLeft =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_5");
            projectileTextureRight =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow");
            projectileTextureUp =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_3");
            projectileTextureDown =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_7");

            hitMonster = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Shot");
            hitWall = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Arrow");
        }
    }
}