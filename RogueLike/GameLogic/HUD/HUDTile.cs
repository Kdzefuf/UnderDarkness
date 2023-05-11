using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    class HUDTile : Tiles
    {
        private Texture2D backgroundOne;
        private Texture2D backgroundTwo;
        private Texture2D backgroundThree;

        private int show = 0;

        public HUDTile(int X, int Y, int loopCount, Mediator mediator) : base(X, Y, loopCount, mediator)
        {
            show = loopCount;
            this.priority = 0;
        }

        public override bool Collision(GameObject other)
        {
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (show == 0)
            {
                spriteBatch.Draw(backgroundOne, hitbox, Color.White);
            }
            if (show == 1)
            {
                spriteBatch.Draw(backgroundTwo, hitbox, Color.White);
            }
            if (show == 2)
            {
                spriteBatch.Draw(backgroundTwo, hitbox, Color.White);
            }
        }

        public override void Load()
        {
            backgroundOne = Mediator.Game.Content.Load<Texture2D>(@"Graphic\UI\Menu\background1");
            backgroundTwo = Mediator.Game.Content.Load<Texture2D>(@"Graphic\UI\Menu\background2");
            backgroundThree = Mediator.Game.Content.Load<Texture2D>(@"Graphic\UI\Menu\background3");
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
