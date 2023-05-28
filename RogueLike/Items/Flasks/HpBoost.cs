using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Колба здоровья
    /// </summary>
    internal class HpFlask : Item
    {
        // Полная колба
        private Texture2D filledHpPotion;
        // Пустая колба
        private Texture2D emptyHpPotion;
        // Добавление здоровья
        private int hpPlus;
        // Флаг 
        private bool isTaken = false;

        /// <summary>
        /// Колба здоровья
        /// </summary>
        /// <param name="hpPlus">Добавление здоровья</param>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        public HpFlask(int hpPlus, int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            this.hpPlus = hpPlus;
            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
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
                playSoundBool = true;
                mediator.player.health = mediator.player.health + hpPlus;
                //mediator.player.OverallHealingDone += hpPlus;
                this.hitbox = Rectangle.Empty;
                this.isTaken = true;
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
            if (!isTaken)
                spriteBatch.Draw(filledHpPotion, new Rectangle(this.X, this.Y, spriteWidth, spriteHeight), Color.White);
            else
                spriteBatch.Draw(emptyHpPotion, new Rectangle(this.X, this.Y, spriteWidth, spriteHeight), Color.White);
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            filledHpPotion = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\flask\flasks_4_1");
            emptyHpPotion = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\flask\flasks_4_2");
            //soundEffect = Mediator.Game.Content.Load<SoundEffect>("Sounds/Powerup");
        }

        //public override void PlaySound()
        //{
        //    soundEffect.CreateInstance().Play();
        //}

        /// <summary>
        /// Обновление столкновения объекта
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {
            if (playSoundBool)
            {
                PlaySound();
                playSoundBool = false;
            }
        }
    }
}