using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс клетки визуального интерфейса
    /// </summary>
    class HUDTile : Tiles
    {
        // Задний фон
        private Texture2D backgroundOne;
        private Texture2D backgroundTwo;
        private Texture2D backgroundThree;

        // Рисование клетки
        private int show = 0;

        /// <summary>
        /// Клетка визуального интерфейса
        /// </summary>
        /// <param name="X">Координата х</param>
        /// <param name="Y">Координата у</param>
        /// <param name="loopCount">Количество повторений</param>
        /// <param name="mediator">Посредник</param>
        public HUDTile(int X, int Y, int loopCount, Mediator mediator) : base(X, Y, loopCount, mediator)
        {
            show = loopCount;
            this.priority = 0;
        }

        /// <summary>
        /// Столкновение
        /// </summary>
        /// <param name="other">Другой объект</param>
        /// <returns>Проверяет объекты на столкновение</returns>
        public override bool Collision(GameObject other)
        {
            return true;
        }

        /// <summary>
        /// Рисование клетки
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (show == 0)
            {
                spriteBatch.Draw(backgroundOne, hitbox, Color.White);
            }
            if (show == 1)
            {
                spriteBatch.Draw(backgroundTwo, hitbox, Color.White);
            }
            if (show == 2)
            {
                spriteBatch.Draw(backgroundThree, hitbox, Color.White);
            }
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            backgroundOne = Mediator.Game.Content.Load<Texture2D>(@"Graphic\UI\Menu\background1");
            backgroundTwo = Mediator.Game.Content.Load<Texture2D>(@"Graphic\UI\Menu\background2");
            backgroundThree = Mediator.Game.Content.Load<Texture2D>(@"Graphic\UI\Menu\background3");
        }

        /// <summary>
        /// Обновление состояния клеток
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {

        }
    }
}
