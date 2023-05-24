using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    public class Projectile : GameObject, IProjectile
    {
        protected Texture2D projectileTextureLeft;
        protected Texture2D projectileTextureRight;
        protected Texture2D projectileTextureUp;
        protected Texture2D projectileTextureDown;
        protected Texture2D projectileTextureNorthEast;
        protected Texture2D projectileTextureNorthWest;
        protected Texture2D projectileTextureSouthEast;
        protected Texture2D projectileTextureSouthWest;

        protected SoundEffect hitMonster;
        protected SoundEffect hitWall;

        protected bool shouldDraw = true;
        protected int damage = 33;
        protected Direction direction;
        protected bool visible; // is the projectile visible
        protected int shootSpeed = 8; //the speed the projectile moves

        protected const int Height = 30;
        protected const int Width = 30;
        protected const int actualHeight = 1;
        protected const int actualWidth = 1;
        protected bool hasHit = false;

        public Projectile(int x, int y, Direction direction, Mediator mediator) : base(mediator, x, y)
        {
            this.hitbox = new Rectangle(this.X, this.Y, actualWidth, actualHeight);
            this.direction = direction;
            this.priority = 4;
        }

        public override bool Collision(GameObject other)
        {
            if (other is Monster)
            {
                hasHit = true;
                Monster p = (Monster)other;
                p.Health = p.Health - damage;
                //mediator.player.OverallDamegeDone += damage;
                mediator.itemToBeDeleted.Add(this);
            }

            if (other is Wall || other is Door)
            {
                //hitWall.CreateInstance().Play();
                mediator.itemToBeDeleted.Add(this);
            }
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawAccordingToDirection(spriteBatch);
        }

        public virtual void DrawAccordingToDirection(SpriteBatch spriteBatch)
        {
            if (shouldDraw)
            {
                if (this.direction == Direction.Up)
                {
                    spriteBatch.Draw(projectileTextureUp, hitbox, Color.White);
                }
                else if (this.direction == Direction.Down)
                {
                    spriteBatch.Draw(projectileTextureDown, hitbox, Color.White);
                }
                else if (this.direction == Direction.Right)
                {
                    spriteBatch.Draw(projectileTextureRight, hitbox, Color.White);
                }
                else if (this.direction == Direction.Left)
                {
                    spriteBatch.Draw(projectileTextureLeft, hitbox, Color.White);
                }
            }
        }

        // draws the hitbox of the projectile
        public void drawHitbox(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Texture2D texture = new Texture2D(projectileTextureLeft.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.Aqua });
            spriteBatch.Draw(texture, hitbox, Color.White);

            spriteBatch.Draw(projectileTextureLeft, hitbox, Color.White);
        }

        //loading our projectile image
        public override void Load()
        {
            projectileTextureLeft =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_5");
            projectileTextureRight =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow");
            projectileTextureUp =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_3");
            projectileTextureDown =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_7");

            //hitMonster = Mediator.Game.Content.Load<SoundEffect>("Sounds/Hit");
            //hitWall = Mediator.Game.Content.Load<SoundEffect>("Sounds/HitWall");
        }

        public void MoveProjectile()
        {
            if (this.direction == Direction.Up)
            {
                Y -= shootSpeed;
            }
            else if (this.direction == Direction.Down)
            {
                Y += shootSpeed;
            }
            else if (this.direction == Direction.Right)
            {
                X += shootSpeed;
            }
            else if (this.direction == Direction.Left)
            {
                X -= shootSpeed;
            }
        }

        private void PlayShot()
        {
            //hitMonster.CreateInstance().Play();
        }

        public override void Update(GameTime gameTime)
        {
            MoveProjectile();
            this.hitbox = new Rectangle(this.X, this.Y, Width, Height);

            if (hasHit)
            {
                PlayShot();
                hasHit = false;
            }
        }

        public int Damage
        {
            get => damage;
            set => damage = value;
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle(this.X, this.Y, projectileTextureLeft.Width, projectileTextureLeft.Height); }
        }
    }
}