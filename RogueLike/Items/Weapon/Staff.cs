using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс посоха
    /// </summary>
    internal class Staff : Weapon
    {
        // Спрайт
        private Texture2D sprite;
        // Звук выстрела
        private SoundEffect shoot;

        /// <summary>
        /// Посох
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        public Staff(int x, int y, Mediator mediator) : base(x, y, mediator)
        {

        }

        /// <summary>
        /// Столкновение
        /// </summary>
        /// <param name="other">Другой объект</param>
        /// <returns>Проверяет объекты на столкновение</returns>
        public override bool Collision(GameObject other)
        {
            if (other is Player)
            {
                taken = true;
                mediator.player.Weapon = new Staff(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
                mediator.player.weapon.Projectile = new StaffProjectile(x, y, Direction.Up, mediator);
            }
            return true;
        }

        /// <summary>
        /// Рисование спрайтов
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.Projectile = new StaffProjectile(0, 0, Direction.Up, mediator);
            spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, spriteWidth, spriteHeight), Color.White);
        }

        /// <summary>
        /// Выстрел
        /// </summary>
        /// <param name="x">Координата ч</param>
        /// <param name="y">Координата у</param>
        /// <param name="direction">направление</param>
        public override void Fire(int x, int y, Direction direction)
        {
            // Снаряд посоха
            Projectile staffProjectile = new StaffProjectile(x, y, direction, mediator);
            this.Load();
            shoot.Play();
            staffProjectile.Load();
            mediator.itemToBeAdded.Add(staffProjectile);
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\staff");
            shoot = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\staff");
        }

        public override string ToString()
        {
            return "Staff";
        }

        /// <summary>
        /// Обновление состояния посоха
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {
        }
    }
}