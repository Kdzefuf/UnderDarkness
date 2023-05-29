using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    internal class WinImage : GameObject
    {
        // Текстура кнопки
        protected Texture2D winGemImage;
        // Позиция
        protected Vector2 pos { get; set; }
        // Высота кнопки
        protected int Height = 138;
        // Ширина кнопки
        protected int Width = 84;

        /// <summary>
        /// Кнопка
        /// </summary>
        /// <param name="X">Координата х</param>
        /// <param name="Y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        /// <param name="buttonString">Текст на кнопке</param>
        public WinImage(int X, int Y, Mediator mediator) : base(mediator, X, Y)
        {
            hitbox = new Rectangle(this.X, this.Y, Width, Height);
        }

        /// <summary>
        /// Рисование кнопки
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(winGemImage, hitbox, Color.White);
        }

        /// <summary>
        /// Загрузка текстур
        /// </summary>
        public override void Load()
        {
            winGemImage = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\Gems\WinGem");
        }

        /// <summary>
        /// Поле изображения
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)pos.X, (int)pos.Y, winGemImage.Width, winGemImage.Height);
            }
        }
    }
}
