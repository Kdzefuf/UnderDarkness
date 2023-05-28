using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс структур
    /// </summary>
    public class Structures : GameObject
    {
        // Комната
        protected Room room;
        // Размер структуры
        protected int size = 32;
        // Координаты
        protected int x;
        protected int y;

        /// <summary>
        /// Структуры
        /// </summary>
        protected Structures()
        {

        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mediator">Посредник</param>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        protected Structures(Mediator mediator, int x, int y) : base(mediator, x, y)
        {

        }

        /// <summary>
        /// Рисование структуры
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

        /// <summary>
        /// Загрузка структуры
        /// </summary>
        public override void Load()
        {

        }

        /// <summary>
        /// Обновление состояния структуры
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}