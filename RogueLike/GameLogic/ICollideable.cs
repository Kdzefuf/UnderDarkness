namespace RogueLike
{
    /// <summary>
    /// Интерфейс столкновения
    /// </summary>
    interface ICollideable
    {
        /// <summary>
        /// Столкновение
        /// </summary>
        /// <param name="other">Другой объект</param>
        /// <returns>Проверяет объекты на столкновение</returns>
        bool Collision(GameObject other);
    }
}
