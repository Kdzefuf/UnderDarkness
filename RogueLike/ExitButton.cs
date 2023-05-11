using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RogueLike
{
    internal class ExitButton : Button
    {
        public ExitButton(int X, int Y, Mediator mediator, string buttonString) : base(X, Y, mediator, buttonString)
        {

        }

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