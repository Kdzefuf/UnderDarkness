using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Diagnostics;

namespace RogueLike
{
    public class Monster : GameObject
    {
        protected int movementspeed = 1;
        protected int health = 100;
        protected Boolean alive = true;
        protected int prevX;
        protected int prevY;
        protected Direction direction;
        protected bool shouldDraw = true;
        protected bool stuck;
        protected Vector2 previousPosition;
        protected int bounceBack = 3;
        protected SoundEffect dead;
        protected Rectangle rallyPoint;
        protected Rectangle randomRallyPoint;
        protected int randomRallyPointCoord = 999;
        protected int spriteWidth = 25;
        protected int spriteHeight = 25;

        public Monster(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            Random random = new Random();
            this.hitbox = new Rectangle(X, Y, spriteWidth, spriteHeight);
            this.rallyPoint = new Rectangle(X, Y, spriteWidth, spriteHeight);
            this.randomRallyPoint = new Rectangle(X + random.Next(-randomRallyPointCoord, randomRallyPointCoord), Y + random.Next(-randomRallyPointCoord, randomRallyPointCoord), spriteHeight, spriteWidth);
        }

        public override bool Collision(GameObject other)
        {
            if (other is Player)
            {
                mediator.player.health = mediator.player.health - 1;
                //mediator.player.OverallDamageTaken = mediator.player.OverallDamageTaken + 1;
                return true;
            }

            if (other is Wall || other is Creep && other != this)
            {
                Random random = new Random();
                moveTo(rallyPoint);

                if (other is Creep && other != this)
                {
                    moveTo(randomRallyPoint);
                    this.randomRallyPoint.X = this.X + random.Next(-randomRallyPointCoord, randomRallyPointCoord);
                    this.randomRallyPoint.Y = this.Y + random.Next(-randomRallyPointCoord, randomRallyPointCoord);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Die()
        {
            mediator.room.EnemyCount--;
            mediator.itemToBeDeleted.Add(this);
        }

        public override void Load()
        {
            dead = Mediator.Game.Content.Load<SoundEffect>("Sounds/MonsterDead");
        }

        private void moveTo(Rectangle where)
        {
            if (this.X < where.X)
            {
                this.direction = Direction.Right;
                this.X = this.X + this.movementspeed;
            }

            if (this.Y < where.Y)
            {
                this.direction = Direction.Down;
                this.Y = this.Y + this.movementspeed;
            }

            if (this.X > where.X)
            {
                this.direction = Direction.Left;
                this.X = this.X - this.movementspeed;
            }

            if (this.Y > where.Y)
            {
                this.direction = Direction.Up;
                this.Y = this.Y - this.movementspeed;
            }
        }

        public virtual void moveTo(Player where)
        {
            this.hitbox.X = X;
            this.hitbox.Y = Y;

            if (this.X < where.getX())
            {
                this.direction = Direction.Right;
                this.X = this.X + this.movementspeed;
            }

            if (this.Y < where.getY())
            {
                this.direction = Direction.Down;
                this.Y = this.Y + this.movementspeed;
            }

            if (this.X > where.getX())
            {
                this.direction = Direction.Left;
                this.X = this.X - this.movementspeed;
            }

            if (this.Y > where.getY())
            {
                this.direction = Direction.Up;
                this.Y = this.Y - this.movementspeed;
            }
        }

        public void setX(int x)
        {
            this.X = x;
        }
        public void setY(int y)
        {
            this.Y = y;
        }

        public override void Update(GameTime gameTime)
        {
            Debug.WriteLine(stuck);
            this.prevX = this.X;
            this.prevY = this.Y;

            if (health <= 0)
            {
                alive = false;
                dead.Play();
            }

            if (!alive)
            {
                Die();
            }
            moveTo(mediator.player);
        }

        public int Health
        {
            get => health;
            set => health = value;
        }
    }
}