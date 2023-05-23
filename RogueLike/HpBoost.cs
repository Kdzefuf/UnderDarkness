using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    internal class HpBoost : Item
    {
        private Texture2D filledHpPotion;
        private Texture2D emptyHpPotion;
        private int hpPlus;
        private bool taken = false;

        public HpBoost(int hpPlus, int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            this.hpPlus = hpPlus;
            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
        }

        public override bool Collision(GameObject other)
        {
            if (other is Player)
            {
                playSoundBool = true;
                mediator.player.health = mediator.player.health + hpPlus;
                //mediator.player.OverallHealingDone += hpPlus;
                this.hitbox = Rectangle.Empty;
                this.taken = true;
            }
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!taken)
                spriteBatch.Draw(filledHpPotion, new Rectangle(this.X, this.Y, spriteWidth, spriteHeight), Color.White);
            else
                spriteBatch.Draw(emptyHpPotion, new Rectangle(this.X, this.Y, spriteWidth, spriteHeight), Color.White);
        }

        public override void Load()
        {
            filledHpPotion = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\flask\flasks_4_1");
            emptyHpPotion = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\flask\flasks_4_2");
            //soundEffect = Mediator.Game.Content.Load<SoundEffect>("Sounds/Powerup");
        }

        //public override void PlaySound()
        //{
        //    soundEffect.CreateInstance().Play();
        //}

        public override void Update(GameTime gameTime)
        {
            if (playSoundBool)
            {
                PlaySound();
                playSoundBool = false;
            }
        }
    }
}