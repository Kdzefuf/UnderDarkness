using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RogueLike
{
    /// <summary>
    /// Класс кнопки выхода
    /// </summary>
    public class ExitButton : Button
    {
        /// <summary>
        /// Кнопка выхода
        /// </summary>
        /// <param name="X">Координата х</param>
        /// <param name="Y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        /// <param name="buttonString">Текст на кнопке</param>
        public ExitButton(int X, int Y, Mediator mediator, string buttonString) : base(X, Y, mediator, buttonString)
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
            Rectangle mouseRect = new Rectangle(currentMouseState.X, currentMouseState.Y, 1, 1);
            isHovered = false;

            if (mouseRect.Intersects(this.hitbox))
            {
                isHovered = true;
                if (currentMouseState.LeftButton == ButtonState.Released && prevMouse.LeftButton == ButtonState.Pressed)
                {
                    Mediator.Game.Exit();
                }
            }
        }
    }
}