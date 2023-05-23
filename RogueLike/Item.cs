using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    public abstract class Item : GameObject
    {
        protected bool playSoundBool = false;

        public Item(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            this.priority = 3;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

        public override void Load()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
