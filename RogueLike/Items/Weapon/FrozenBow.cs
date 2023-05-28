using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс замораживающего лука
    /// </summary>
    internal class FrozenBow : Weapon
    {
        // Спрайт
        private Texture2D sprite;
        // Выстрел
        private SoundEffect shoot;

        /// <summary>
        /// Замораживающий лук
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координат у</param>
        /// <param name="mediator">Посредник</param>
        public FrozenBow(int x, int y, Mediator mediator) : base(x, y, mediator)
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
                mediator.player.Weapon = new FrozenBow(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
                mediator.player.weapon.Projectile = new FrozenBowProjectile(x, y, Direction.Up, mediator);
            }
            return true;
        }

        /// <summary>
        /// Рисование лука
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, spriteWidth, spriteHeight), Color.White);
            this.Projectile = new FrozenBowProjectile(0, 0, Direction.Up, mediator);
        }

        /// <summary>
        /// Выстрелы
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="direction">Направление</param>
        public override void Fire(int x, int y, Direction direction)
        {
            Projectile frozenBowProjectile = new FrozenBowProjectile(x, y, direction, mediator);
            this.Load();
            //shoot.CreateInstance().Play();
            frozenBowProjectile.Load();
            mediator.itemToBeAdded.Add(frozenBowProjectile);
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\frozen_bow");
            //pickUp = Mediator.Game.Content.Load<SoundEffect>("Sounds/PickupFrozenBow");
            //shoot = Mediator.Game.Content.Load<SoundEffect>("Sounds/FrozenBow");
        }

        public override string ToString()
        {
            return "Frozen Bow";
        }

        /// <summary>
        /// Обновление состояния замораживающего лука
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {
            PlayPickUp();
        }
    }
}