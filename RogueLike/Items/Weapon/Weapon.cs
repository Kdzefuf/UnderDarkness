using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс оружия
    /// </summary>
    public class Weapon : Item
    {
        // Снаряд
        protected Projectile projectile;
        // Спрайт
        private Texture2D sprite;
        // Звуковые эффекты
        protected SoundEffect pickUp;
        protected SoundEffect shoot;
        // Флаг поднятия
        protected bool taken = false;

        /// <summary>
        /// Оружие
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        public Weapon(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
        }

        /// <summary>
        /// Выстрел
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="direction">Направление</param>
        public virtual void Fire(int x, int y, Direction direction)
        {

        }

        /// <summary>
        /// Проигрывание поднятия оружия
        /// </summary>
        public virtual void PlayPickUp()
        {
            if (taken)
            {
                //pickUp.CreateInstance().Play();
                taken = false;
            }
        }

        /// <summary>
        /// Снаряд
        /// </summary>
        public Projectile Projectile
        {
            get => projectile;
            set => projectile = value;
        }
    }
}