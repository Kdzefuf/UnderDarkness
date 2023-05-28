using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RogueLike
{
    /// <summary>
    /// Класс курсора
    /// </summary>
    public class Cursor : GameObject
    {
        // Текущее состояние мыши
        protected MouseState currentMouseState;
        // Предыдущее состояние мыши
        protected MouseState prevMouse;
        // Спрайт мыши
        private Texture2D mouseSprite;

        /// <summary>
        /// Курсор
        /// </summary>
        public Cursor()
        {
            this.priority = 5;
        }

        /// <summary>
        /// Рисование спрайта
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(mouseSprite, hitbox, Color.White);
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            mouseSprite = Mediator.Game.Content.Load<Texture2D>(@"Graphic\UI\Menu\mouse");
        }

        /// <summary>
        /// Обновление состояния курсора
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {
            prevMouse = currentMouseState;
            currentMouseState = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(currentMouseState.X, currentMouseState.Y, spriteWidth, spriteHeight);
            this.hitbox = mouseRectangle;
        }
    }
}
