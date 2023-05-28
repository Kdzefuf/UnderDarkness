using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс клеток
    /// </summary>
    public class Tiles : Structures
    {
        // Картинка клетки
        private Texture2D tilesPic;
        // Количество повторений
        private int loopCount = 1;

        /// <summary>
        /// Клетки
        /// </summary>
        /// <param name="X">Координата х</param>
        /// <param name="Y">Координата у</param>
        /// <param name="loopCount">Количество повторений</param>
        /// <param name="mediator">Посредник</param>
        public Tiles(int X, int Y, int loopCount, Mediator mediator) : base(mediator, X, Y)
        {
            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
            this.loopCount = loopCount;
            this.priority = 0;
        }

        /// <summary>
        /// Столкновение
        /// </summary>
        /// <param name="other">Другой объект</param>
        /// <returns></returns>
        public override bool Collision(GameObject other)
        {
            return true;
        }

        /// <summary>
        /// Рисование клетки
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(tilesPic, hitbox, Color.White);
        }

        /// <summary>
        /// Загрузка спрайтов
        /// </summary>
        public override void Load()
        {
            tilesPic = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\ground");
        }
    }
}