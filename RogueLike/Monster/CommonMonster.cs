using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс обычного монстра
    /// </summary>
    internal class CommonMonster : Monster
    {
        // Текстуры монстра
        private Texture2D creepPictureRight;
        private Texture2D creepPictureLeft;

        /// <summary>
        /// Обычный монстр
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        public CommonMonster(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            this.priority = 6;
        }

        /// <summary>
        /// Рисование спрайта
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (this.direction == Direction.Right)
            {
                spriteBatch.Draw(creepPictureRight, hitbox, Color.White);
            }

            if (this.direction == Direction.Up)
            {
                spriteBatch.Draw(creepPictureRight, hitbox, Color.White);
            }

            if (this.direction == Direction.Left)
            {
                spriteBatch.Draw(creepPictureLeft, hitbox, Color.White);
            }

            if (this.direction == Direction.Down)
            {
                spriteBatch.Draw(creepPictureLeft, hitbox, Color.White);
            }
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            creepPictureRight = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Enemies\Boar\boar1");
            creepPictureLeft = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Enemies\Boar\boar5");

            dead = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Boardeath");
        }
    }
}