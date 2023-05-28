using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace RogueLike
{
    /// <summary>
    /// Клетка шипов
    /// </summary>
    public class SpikesTile : Tiles
    {
        // Спрайты
        private Texture2D spriteOne;
        private Texture2D spriteTwo;
        private Texture2D spriteThree;
        private Texture2D spriteFour;
        // Номер спрайта для рисования
        private int show;
        // Последнее движение
        private double lastStir = 0;
        // Пауза между спрайтами
        private int cooldown = 600;

        /// <summary>
        /// Клетка шипов
        /// </summary>
        /// <param name="X">Координата х</param>
        /// <param name="Y">Координата у</param>
        /// <param name="loopCount">Количество повторений</param>
        /// <param name="mediator">Посредник</param>
        public SpikesTile(int X, int Y, int loopCount, Mediator mediator) : base(X, Y, loopCount, mediator)
        {
            this.priority = 1;
        }

        /// <summary>
        /// Столкновение
        /// </summary>
        /// <param name="other">Другой объект</param>
        /// <returns>Проверяет объекты на столкновение</returns>
        public override bool Collision(GameObject other)
        {
            if (other is Player && show != 0)
            {
                if (lastStir >= cooldown - 100)
                {
                    mediator.player.health = mediator.player.health - 1;
                    //mediator.player.OverallDamageTaken = mediator.player.OverallDamageTaken + 1;
                }
            }
            return true;
        }

        /// <summary>
        /// Рисование 
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (show == 0)
            {
                spriteBatch.Draw(spriteOne, hitbox, Color.White);
            }
            if (show == 1)
            {
                spriteBatch.Draw(spriteTwo, hitbox, Color.White);
            }
            if (show == 2)
            {
                spriteBatch.Draw(spriteThree, hitbox, Color.White);
            }
            if (show == 3)
            {
                spriteBatch.Draw(spriteFour, hitbox, Color.White);
            }
        }

        /// <summary>
        /// Загрузка спрайтов
        /// </summary>
        public override void Load()
        {
            spriteOne = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\peaks\peaks_1");
            spriteTwo = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\peaks\peaks_2");
            spriteThree = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\peaks\peaks_3");
            spriteFour = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\peaks\peaks_4");
        }

        /// <summary>
        /// обновление состояния шипов
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {
            lastStir += gameTime.ElapsedGameTime.TotalMilliseconds;
            Random random = new Random();
            if (lastStir > cooldown)
            {
                show = random.Next(4);
                lastStir = 0;
            }
        }

        /// <summary>
        /// Последнее движение
        /// </summary>
        public double LastStir
        {
            get => lastStir;
            set => lastStir = value;
        }
    }
}