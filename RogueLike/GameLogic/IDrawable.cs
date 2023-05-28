using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Интерфейс рисования
    /// </summary>
    interface IDrawable
    {
        /// <summary>
        /// Рисование спрайта
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        /// <summary>
        /// Загрузка контента
        /// </summary>
        void Load();
    }
}
