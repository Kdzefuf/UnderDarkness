using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    public class Weapon : Item
    {
        protected Projectile projectile;
        private Texture2D sprite;
        protected SoundEffect pickUp;
        protected SoundEffect shoot;
        protected bool taken = false;

        public Weapon(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
        }

        public virtual void Fire(int x, int y, Direction direction)
        {

        }

        public virtual void PlayPickUp()
        {
            if (taken)
            {
                //pickUp.CreateInstance().Play();
                taken = false;
            }
        }

        public Projectile Projectile
        {
            get => projectile;
            set => projectile = value;
        }
    }
}