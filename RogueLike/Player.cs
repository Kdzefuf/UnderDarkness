using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RogueLike
{
    public class Player : GameObject
    {
        private Texture2D playerRight;
        private Texture2D playerLeft;

        private SoundEffect defaultShoot;
        public Rectangle hitbox;
        //public Weapon weapon;
        private Direction direction;
        //private TextField bloodRushText;

        public int speed = 2;
        private int spriteWidth = 32;
        private int spriteHeight = 32;
        public int health = 100;
        private bool alive = true;
        public int prevPosX;
        public int prevPosY;
        //private int cooldown = 500; //mills between shots
        //private double lastShot = 0;
        //private bool hurting = false;
        //private int kills = 0;
        //private int levelsCompleted;
        //private int overallDamageTaken;
        //private int overallDamageDone;
        //private int overallHealingDone;
        //private int projectilesFired;
        //private int maxHp = 3;
        //private int bloodRushHp = 25;
        //private bool bloodRush = false;
        //private bool hybris = false;

        public Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.prevPosX = x;
            this.prevPosY = y;
            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
            this.priority = 5;
        }

        public override bool Collision(GameObject other)
        {
            //if (other is Wall)
            //{
            //    this.Y = prevPosY;
            //    this.X = prevPosX;
            //}
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(playerRight, hitbox, Color.White);
            if (direction == Direction.Right)
            {
                spriteBatch.Draw(playerRight, hitbox, Color.White);
            }

            if (direction == Direction.Left)
            {
                spriteBatch.Draw(playerLeft, hitbox, Color.White);
            }
        }

        public void Move()
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.A) && key.IsKeyDown(Keys.D) && key.IsKeyDown(Keys.S) || key.IsKeyDown(Keys.A) && key.IsKeyDown(Keys.D) && key.IsKeyDown(Keys.W))
            {
                this.direction = Direction.Left;
                this.X = this.X - this.speed;
            }

            if (key.IsKeyDown(Keys.D))
            {
                this.direction = Direction.Right;
                this.prevPosX = this.X;
                this.X = this.X + this.speed;
            }

            if (key.IsKeyDown(Keys.A))
            {
                this.direction = Direction.Left;
                this.prevPosX = this.X;
                this.X = this.X - this.speed;
            }

            if (key.IsKeyDown(Keys.S))
            {
                this.direction = Direction.Down;
                this.prevPosY = this.Y;
                this.Y = this.Y + this.speed;
            }

            if (key.IsKeyDown(Keys.W))
            {
                this.direction = Direction.Up;
                this.prevPosY = this.Y;
                this.Y = this.Y - this.speed;
            }
        }

        public int getX()
        {
            return this.X;
        }

        public int getY()
        {
            return this.Y;
        }

        public void setX(int x)
        {
            this.X = x;
        }

        public void setY(int y)
        {
            this.Y = y;
        }
    }
}
