using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс стены
    /// </summary>
    public class Wall : Structures
    {
        // Простая стена
        private Texture2D defaultWall;

        /// <summary>
        /// Стена
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        public Wall(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
            this.priority = 6;
        }

        /// <summary>
        /// Рисование спрайта
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(defaultWall, hitbox, Color.White);
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            defaultWall = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\wall");
        }
    }
}