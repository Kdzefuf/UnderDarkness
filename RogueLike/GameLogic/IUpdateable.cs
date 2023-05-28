using Microsoft.Xna.Framework;

namespace RogueLike
{
    /// <summary>
    /// Интерфейс обновления
    /// </summary>
    interface IUpdateable
    {
        /// <summary>
        /// Обновление состояния игры
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        void Update(GameTime gameTime);
    }
}
