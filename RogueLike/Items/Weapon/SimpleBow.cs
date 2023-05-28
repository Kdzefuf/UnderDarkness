using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Обычный лук
    /// </summary>
    internal class SimpleBow : Weapon
    {
        // Спрайт
        private Texture2D sprite;
        // Звуковой эффект выстрела
        private SoundEffect shoot;

        /// <summary>
        /// Обычный лук
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        public SimpleBow(int x, int y, Mediator mediator) : base(x, y, mediator)
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
                mediator.player.Weapon = new SimpleBow(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
                mediator.player.weapon.Projectile = new SimpleBowProjectile(x, y, Direction.Up, mediator);
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
            spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, spriteWidth, spriteHeight), Color.White);
        }

        /// <summary>
        /// Выстрел
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="direction">Направление</param>
        public override void Fire(int x, int y, Direction direction)
        {
            Projectile crossbowProjectile = new SimpleBowProjectile(x, y, direction, mediator);
            this.Load();
            //shoot.CreateInstance().Play();
            crossbowProjectile.Load();
            mediator.itemToBeAdded.Add(crossbowProjectile);
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\comon_bow");
            //pickUp = Mediator.Game.Content.Load<SoundEffect>("Sounds/PickupCrossbow");
            //shoot = Mediator.Game.Content.Load<SoundEffect>("Sounds/CrossBow");
        }

        public override string ToString()
        {
            return "Crossbow";
        }

        /// <summary>
        /// Обновление состояния игры
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            PlayPickUp();
        }
    }
}