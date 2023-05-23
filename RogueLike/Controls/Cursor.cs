using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RogueLike
{
    public class Cursor : GameObject
    {
        protected MouseState currentMouseState;
        protected MouseState prevMouse;
        private Texture2D mouseSprite;

        public Cursor()
        {
            this.priority = 5;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(mouseSprite, hitbox, Color.White);
        }

        public override void Load()
        {
            mouseSprite = Mediator.Game.Content.Load<Texture2D>(@"Graphic\UI\Menu\mouse");
        }

        public override void Update(GameTime gameTime)
        {
            prevMouse = currentMouseState;
            currentMouseState = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(currentMouseState.X, currentMouseState.Y, spriteWidth, spriteHeight);
            this.hitbox = mouseRectangle;
        }
    }
}
