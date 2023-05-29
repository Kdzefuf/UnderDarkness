using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Снаряд замораживающего лука
    /// </summary>
    internal class FrozenBowProjectile : Projectile
    {
        /// <summary>
        /// Снаряд замораживающего лука
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="direction">Направление</param>
        /// <param name="mediator">Посредник</param>
        public FrozenBowProjectile(int x, int y, Direction direction, Mediator mediator) : base(x, y, direction, mediator)
        {
            this.damage = 50;
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            this.projectileTextureUp = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\frozen_arrow_3");
            this.projectileTextureRight = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\frozen_arrow");
            this.projectileTextureLeft = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\frozen_arrow_5");
            this.projectileTextureDown = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\frozen_arrow_7");

            hitMonster = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Shot");
            hitWall = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Arrow");
        }
    }
}