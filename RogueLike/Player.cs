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
        public Weapon weapon;
        private Direction direction;

        public int speed = 2;
        private int spriteWidth = 27;
        private int spriteHeight = 27;
        public int health = 300;
        private bool alive = true;
        public int prevPosX;
        public int prevPosY;
        private int cooldown = 500; //mills between shots
        private double lastShot = 0;
        private bool hurting = false;
        private int levelsCompleted;
        private int projectilesFired;
        private int maxHp = 300;

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
            if (other is Wall)
            {
                this.Y = prevPosY;
                this.X = prevPosX;
            }
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(playerRight, hitbox, Color.White);
            if (direction == Direction.Down)
            {
                spriteBatch.Draw(playerLeft, hitbox, Color.White);
            }
            if (direction == Direction.Up)
            {
                spriteBatch.Draw(playerRight, hitbox, Color.White);
            }
            if (direction == Direction.Left)
            {
                spriteBatch.Draw(playerLeft, hitbox, Color.White);
            }
            if (direction == Direction.Right)
            {
                spriteBatch.Draw(playerRight, hitbox, Color.White);
            }
        }

        private void Fire(int x, int y, Direction direction)
        {
            Projectile defaultProjectile = new Projectile(x, y, direction, mediator);
            this.Load();
            //defaultShoot.CreateInstance().Play();
            defaultProjectile.Load();
            mediator.itemToBeAdded.Add(defaultProjectile);
        }

        private bool isDead()
        {
            if (health <= 0)
            {
                this.alive = false;
                return true;
            }
            return false;
        }

        public override void Load()
        {
            playerRight = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Hero\Stay\stay1right");
            playerLeft = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Hero\Stay\stay1left");

            //defaultShoot = Mediator.Game.Content.Load<SoundEffect>("Sounds/DefaultWeapon");
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

        public void Shooting(GameTime gameTime)
        {
            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Space))
            {
                if (lastShot > cooldown)
                {
                    projectilesFired++;
                    lastShot = 0;

                    if (weapon != null)
                    {
                        mediator.player.weapon.Fire(this.X, this.Y, this.direction);
                    }
                    else if (weapon == null)
                    {
                        Fire(this.X, this.Y, this.direction);
                    }
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            lastShot += gameTime.ElapsedGameTime.TotalMilliseconds;
            Move();
            Shooting(gameTime);

            if (health > maxHp)
            {
                this.speed = 1;
                this.health--;

            }
            else
            {
                this.speed = 2;
                this.cooldown = 500;
            }

            if (isDead())
            {
                mediator.gameOverMenu._player = this;
                mediator.gameOverMenu.GiveStats();
                mediator.State.State = GameState.GameOver;
            }

            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
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

        public int LevelsCompleted
        {
            get => levelsCompleted;
            set => levelsCompleted = value;
        }

        public int ProjectilesFired
        {
            get => projectilesFired;
            set => projectilesFired = value;
        }

        public int playerCooldown
        {
            get { return cooldown; }
            set { cooldown = value; }
        }

        public Weapon Weapon
        {
            get => weapon;
            set => weapon = value;
        }
    }
}
