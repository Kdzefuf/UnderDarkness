using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    public class Tiles : Structures
    {
        private Texture2D tilesPic;

        private int loopCount = 1;

        public Tiles(int X, int Y, int loopCount, Mediator mediator) : base(mediator, X, Y)
        {
            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
            this.loopCount = loopCount;
            this.priority = 0;
        }

        public override bool Collision(GameObject other)
        {
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(tilesPic, hitbox, Color.White);
        }

        public override void Load()
        {
            tilesPic = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\ground");
        }
    }
}