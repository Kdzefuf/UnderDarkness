using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Абстрактный класс предмета
    /// </summary>
    public abstract class Item : GameObject
    {
        // Флаг проигрывания звука
        protected bool playSoundBool = false;

        /// <summary>
        /// Предмет
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        public Item(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            this.priority = 3;
        }

        /// <summary>
        /// Рисование
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {

        }

        /// <summary>
        /// Обновление состояния предмета
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {

        }
    }
}
