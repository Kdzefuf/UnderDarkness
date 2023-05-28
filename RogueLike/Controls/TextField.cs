using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс поля текста
    /// </summary>
    public class TextField : GameObject
    {
        // Шрифт
        private SpriteFont font;
        // Текст
        private string text;
        // Цвет текста
        private Color textColor;

        /// <summary>
        /// Поле текста
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        /// <param name="text">Текст</param>
        /// <param name="color">Цвет</param>
        public TextField(int x, int y, Mediator mediator, string text, Color color)
        {
            this.X = x;
            this.Y = y;
            this.mediator = mediator;
            this.text = text;
            this.textColor = color;
        }

        /// <summary>
        /// Рисование спрайта
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(font, text, new Vector2(X, Y), textColor);
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            font = Mediator.Game.Content.Load<SpriteFont>(@"Fonts/Font");
        }
    }
}
