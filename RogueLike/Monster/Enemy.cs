using Microsoft.Xna.Framework.Graphics;
using RogueSharp;

namespace RogueLike
{
    /// <summary>
    /// Класс врага
    /// </summary>
    public class Enemy
    {
        // Карта
        public IMap _map;
        // Игрок
        public Player _player;
        // Координаты
        public int X { get; set; }
        public int Y { get; set; }
        // Спрайт
        public Texture2D Sprite { get; set; }

        /// <summary>
        /// Враг
        /// </summary>
        public Enemy()
        {
        }

        /// <summary>
        /// Обновление состояния игры
        /// </summary>
        public void Update()
        {

        }

        /// <summary>
        /// Рисование спрайта
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            float multiplier = Sprite.Width;
        }
    }
}
