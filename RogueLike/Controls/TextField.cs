using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    public class TextField : GameObject
    {
        private SpriteFont font;
        private string text;
        private Color textColor;

        public TextField(int x, int y, Mediator mediator, string text, Color color)
        {
            this.X = x;
            this.Y = y;
            this.mediator = mediator;
            this.text = text;
            this.textColor = color;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(font, text, new Vector2(X, Y), textColor);
        }

        public override void Load()
        {
            font = Mediator.Game.Content.Load<SpriteFont>(@"Fonts/Font");
        }
    }
}
