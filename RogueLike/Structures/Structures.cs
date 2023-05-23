using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    public class Structures : GameObject
    {
        protected Room room;
        protected int unit = 32;
        protected int x;
        protected int y;

        protected Structures()
        {

        }

        protected Structures(Mediator mediator, int x, int y) : base(mediator, x, y)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

        public override void Load()
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}