using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RogueLike
{
    /// <summary>
    /// Класс начала игры
    /// </summary>
    internal class PlayButton : Button
    {
        /// <summary>
        /// Кнопка начала игры
        /// </summary>
        /// <param name="X">Координата х</param>
        /// <param name="Y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        /// <param name="buttonString">Текст на кнопке</param>
        public PlayButton(int X, int Y, Mediator mediator, string buttonString) : base(X, Y, mediator, buttonString)
        {

        }

        /// <summary>
        /// Обновление состояния кнопки
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {
            prevMouse = currentMouseState;
            currentMouseState = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(currentMouseState.X, currentMouseState.Y, 1, 1);

            isHovered = false;

            if (mouseRectangle.Intersects(this.hitbox))
            {
                isHovered = true;
                if (currentMouseState.LeftButton == ButtonState.Released && prevMouse.LeftButton == ButtonState.Pressed)
                {
                    this.mediator.State.State = GameState.Play;
                }
            }
        }
    }
}