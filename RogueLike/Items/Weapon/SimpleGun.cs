using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс обычного ружья
    /// </summary>
    public class SimpleGun : Weapon
    {
        // Спрайт
        private Texture2D sprite;
        // Звуковой эффект выстрела
        private SoundEffect shoot;

        /// <summary>
        /// Обычное ружье
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        public SimpleGun(int x, int y, Mediator mediator) : base(x, y, mediator)
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
                mediator.player.Weapon = new SimpleGun(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
                mediator.player.weapon.Projectile = new SimpleGunProjectile(x, y, Direction.Up, mediator);
            }
            return true;
        }

        /// <summary>
        /// Рисование спрайта
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.Projectile = new SimpleGunProjectile(0, 0, Direction.Up, mediator);
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
            Projectile simpleGunProjectile = new SimpleGunProjectile(x, y, direction, mediator);
            this.Load();
            shoot.CreateInstance().Play();
            simpleGunProjectile.Load();
            mediator.itemToBeAdded.Add(simpleGunProjectile);
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\simpleGun");
            //pickUp = Mediator.Game.Content.Load<SoundEffect>("Sounds/PickupSimpleGun");
            shoot = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Gun");
        }

        public override string ToString()
        {
            return "Simple Gun";
        }

        /// <summary>
        /// Обновление состояния игры
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {
            PlayPickUp();
        }
    }
}