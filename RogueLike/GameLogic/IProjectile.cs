using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Интерфейс снаряда
    /// </summary>
    interface IProjectile
    {
        /// <summary>
        /// Движение снаряда
        /// </summary>
        void MoveProjectile();
        /// <summary>
        /// Рисование относительно направления
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        void DrawAccordingToDirection(SpriteBatch spriteBatch);
    }
}