using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    internal class Wall : Structures
    {
        private Texture2D defaultWall;

        public Wall(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
            this.priority = 6;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(defaultWall, hitbox, Color.White);
        }

        public override void Load()
        {
            defaultWall = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\wall");
        }
    }
}