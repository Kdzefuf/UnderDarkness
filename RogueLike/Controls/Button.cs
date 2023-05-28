using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace RogueLike
{
    /// <summary>
    /// Класс кнопки
    /// </summary>
    public class Button : GameObject
    {
        // Текущее состояние мыши
        protected MouseState currentMouseState;
        // Шрифт
        protected SpriteFont font;
        // Флаг наведения
        protected bool isHovered;
        // Предыдущее состояние мыши
        protected MouseState prevMouse;
        // Текстура кнопки
        protected Texture2D buttonTexture;
        // Текстура наведенной кнопки
        protected Texture2D buttonTextureHovered;
        // нажатие
        protected event EventHandler click;
        // Флаг нажатия
        protected bool clicked { get; set; }
        // Цвет шрифта
        protected Color fontColor = Color.Red;
        // Позиция
        protected Vector2 pos { get; set; }
        // Высота кнопки
        protected int ButtonHeight = 96;
        // Ширина кнопки
        protected int ButtonWidth = 256;
        // Текст на кнопке
        protected string buttonString;
        // Расположение текста на кнопке
        protected int stringPosX;
        protected int stringPosY;

        /// <summary>
        /// Кнопка
        /// </summary>
        /// <param name="X">Координата х</param>
        /// <param name="Y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        /// <param name="buttonString">Текст на кнопке</param>
        public Button(int X, int Y, Mediator mediator, string buttonString) : base(mediator, X, Y)
        {
            hitbox = new Rectangle(this.X, this.Y, ButtonWidth, ButtonHeight);
            this.buttonString = buttonString;
            stringPosX = X + 100;
            stringPosY = Y + 20;
        }

        /// <summary>
        /// Рисование кнопки
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (isHovered)
            {
                spriteBatch.Draw(buttonTextureHovered, hitbox, Color.White);
                spriteBatch.DrawString(font, buttonString, new Vector2(stringPosX, stringPosY + 12), fontColor);
            }
            else
            {
                spriteBatch.Draw(buttonTexture, hitbox, Color.White);
                spriteBatch.DrawString(font, buttonString, new Vector2(stringPosX, stringPosY), fontColor);
            }
        }

        /// <summary>
        /// Загрузка текстур
        /// </summary>
        public override void Load()
        {
            buttonTexture = Mediator.Game.Content.Load<Texture2D>(@"Graphic\UI\Menu\Buttons\button");
            buttonTextureHovered = Mediator.Game.Content.Load<Texture2D>(@"Graphic\UI\Menu\Buttons\buttonpress");
            font = Mediator.Game.Content.Load<SpriteFont>(@"Fonts/Font");
        }

        /// <summary>
        /// Обновление состояния кнопки
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Прямоугольник кнопки
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)pos.X, (int)pos.Y, buttonTexture.Width, buttonTexture.Height);
            }
        }
    }
}
