using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    internal class Staff : Weapon
    {
        private Texture2D sprite;
        private SoundEffect shoot;

        public Staff(int x, int y, Mediator mediator) : base(x, y, mediator)
        {

        }

        public override bool Collision(GameObject other)
        {
            if (other is Player)
            {
                taken = true;
                mediator.player.Weapon = new Staff(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
                mediator.player.weapon.Projectile = new StaffProjectile(x, y, Direction.Up, mediator);
            }
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.Projectile = new StaffProjectile(0, 0, Direction.Up, mediator);
            spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, spriteWidth, spriteHeight), Color.White);
        }

        public override void Fire(int x, int y, Direction direction)
        {
            Projectile wandProjectile = new StaffProjectile(x, y, direction, mediator);
            this.Load();
            //shoot.Play();
            wandProjectile.Load();
            mediator.itemToBeAdded.Add(wandProjectile);
        }

        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\staff");
            //shoot = Mediator.Game.Content.Load<SoundEffect>("Sounds/Wand");
            //pickUp = Mediator.Game.Content.Load<SoundEffect>("Sounds/PickupWand");
        }

        public override string ToString()
        {
            return "Staff";
        }

        public override void Update(GameTime gameTime)
        {
            PlayPickUp();
        }
    }
}