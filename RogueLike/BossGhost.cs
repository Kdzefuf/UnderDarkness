using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    class BossGhost : Monster
    {
        private Texture2D bossRight;
        private Texture2D bossLeft;

        private Direction direction;

        public BossGhost(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            this.hitbox = new Rectangle(this.X, this.Y, 64, 64);
            this.priority = 10;
            this.health = 250;
            this.spriteWidth = 25;
            this.spriteHeight = 25;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawAccordingToStats(spriteBatch);
        }

        private void DrawAccordingToStats(SpriteBatch spriteBatch)
        {
            if (this.direction == Direction.Right)
            {
                spriteBatch.Draw(bossRight, hitbox, Color.White);
            }

            if (this.direction == Direction.Up)
            {
                spriteBatch.Draw(bossRight, hitbox, Color.White);
            }

            if (this.direction == Direction.Left)
            {
                spriteBatch.Draw(bossLeft, hitbox, Color.White);
            }

            if (this.direction == Direction.Down)
            {
                spriteBatch.Draw(bossLeft, hitbox, Color.White);
            }
        }

        public override void Load()
        {
            this.bossLeft = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Enemies\Boar\boar_attack_left");
            this.bossRight = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Enemies\Boar\boar_attack_right");

            //dead = Mediator.Game.Content.Load<SoundEffect>("Sounds/MonsterDead");
        }

        public override void moveTo(Player player)
        {
            this.hitbox.X = X;
            this.hitbox.Y = Y;

            if (this.X < player.getX())
            {
                this.prevX = this.X;
                this.direction = Direction.Right;
                this.X = this.X + this.movementspeed;
            }

            if (this.Y < player.getY())
            {
                this.prevY = this.Y;
                this.direction = Direction.Down;
                this.Y = this.Y + this.movementspeed;
            }

            if (this.X > player.getX())
            {
                this.prevX = this.X;
                this.direction = Direction.Left;
                this.X = this.X - this.movementspeed;
            }

            if (this.Y > player.getY())
            {
                this.prevY = this.Y;
                this.direction = Direction.Up;
                this.Y = this.Y - this.movementspeed;
            }
        }

        public override bool Collision(GameObject other)
        {
            if (other is Player)
            {
                mediator.player.health = mediator.player.health - 2;
                //mediator.player.OverallDamgeTaken = mediator.player.OverallDamgeTaken + 2;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}