using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace RogueLike
{
    public abstract class GameObject : IMediator, IUpdateable, IComparable, IDrawable, ICollideable
    {
        private Texture2D defaultSprite;
        public Rectangle hitbox;
        protected int X;
        protected int Y;
        protected int spriteWidth = 32;
        protected int spriteHeight = 32;
        protected SoundEffect effect;
        protected int priority = 2;
        protected bool yelled;
        protected SoundEffect soundEffect;

        public Mediator mediator { get; set; }

        public GameObject()
        {

        }

        public GameObject(Mediator mediator, int x, int y)
        {
            this.mediator = mediator;
            this.X = x;
            this.Y = y;
        }

        public int CompareTo(object obj)
        {
            GameObject gameObject = (GameObject)obj;
            int rtn = 0;

            if (this.priority < gameObject.priority) { rtn = -1; }
            if (this.priority > gameObject.priority) { rtn = +1; }
            return rtn;
        }

        public virtual bool Collision(GameObject other)
        {
            return true;
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

        public void drawHitbox()
        {

        }

        public virtual void Load()
        {

        }

        public virtual void playEffect()
        {
            if (effect != null)
            {
                effect.Play();
            }
        }

        public virtual void playSound()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(this.X, this.Y, defaultSprite.Width, defaultSprite.Height);
            }
        }

        public int x
        {
            get => X;
            set => X = value;
        }

        public int y
        {
            get => Y;
            set => Y = value;
        }
    }
}
