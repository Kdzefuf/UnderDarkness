using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    public class SimpleGun : Weapon
    {
        private Texture2D sprite;
        private SoundEffect shoot;

        public SimpleGun(int x, int y, Mediator mediator) : base(x, y, mediator)
        {

        }

        public override bool Collision(GameObject other)
        {
            if (other is Player)
            {
                taken = true;
                mediator.player.Weapon = new SimpleGun(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
                mediator.player.weapon.Projectile = new SimpleGunProjectile(x, y, Direction.Up, mediator);
            }
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.Projectile = new SimpleGunProjectile(0, 0, Direction.Up, mediator);
            spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, spriteWidth, spriteHeight), Color.White);
        }

        public override void Fire(int x, int y, Direction direction)
        {
            Projectile simpleGunProjectile = new SimpleGunProjectile(x, y, direction, mediator);
            this.Load();
            //shoot.CreateInstance().Play();
            simpleGunProjectile.Load();
            mediator.itemToBeAdded.Add(simpleGunProjectile);
        }

        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\simpleGun");
            //pickUp = Mediator.Game.Content.Load<SoundEffect>("Sounds/PickupSimpleGun");
            //shoot = Mediator.Game.Content.Load<SoundEffect>("Sounds/SimpleGun");
        }

        public override string ToString()
        {
            return "Simple Gun";
        }

        public override void Update(GameTime gameTime)
        {
            PlayPickUp();
        }
    }
}