using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    internal class Creep : Monster
    {
        private Texture2D creepPictureRight;
        private Texture2D creepPictureLeft;

        public Creep(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            this.priority = 6;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawAccordingToStats(spriteBatch);
        }

        private void DrawAccordingToStats(SpriteBatch spriteBatch)
        {
            {
                if (this.direction == Direction.Right)
                {
                    spriteBatch.Draw(creepPictureRight, hitbox, Color.White);
                }

                if (this.direction == Direction.Up)
                {
                    spriteBatch.Draw(creepPictureRight, hitbox, Color.White);
                }

                if (this.direction == Direction.Left)
                {
                    spriteBatch.Draw(creepPictureLeft, hitbox, Color.White);
                }

                if (this.direction == Direction.Down)
                {
                    spriteBatch.Draw(creepPictureLeft, hitbox, Color.White);
                }
            }
        }

        public override void Load()
        {
            creepPictureRight = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Enemies\Boar\boar1");
            creepPictureLeft = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Enemies\Boar\boar5");

            //dead = Mediator.Game.Content.Load<SoundEffect>("Sounds/CreepDead");
        }
    }
}