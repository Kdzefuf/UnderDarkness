using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    internal class Wand : Weapon
    {
        private Texture2D sprite;
        private SoundEffect shoot;

        public Wand(int x, int y, Mediator mediator) : base(x, y, mediator)
        {

        }

        public override bool Collision(GameObject other)
        {
            if (other is Player)
            {
                taken = true;
                mediator.player.Weapon = new Wand(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
                mediator.player.weapon.Projectile = new WandProjectile(x, y, Direction.Up, mediator);
            }
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.Projectile = new WandProjectile(0, 0, Direction.Up, mediator);
            spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, spriteWidth, spriteHeight), Color.White);
        }

        public override void Fire(int x, int y, Direction direction)
        {
            Projectile wandProjectile = new WandProjectile(x, y, direction, mediator);
            this.Load();
            //shoot.Play();
            wandProjectile.Load();
            mediator.itemToBeAdded.Add(wandProjectile);
        }

        public override void Load()
        {
            //sprite = Mediator.Game.Content.Load<Texture2D>("Items/Weapons/spn_staff_of_dispater_new");
            //shoot = Mediator.Game.Content.Load<SoundEffect>("Sounds/Wand");
            //pickUp = Mediator.Game.Content.Load<SoundEffect>("Sounds/PickupWand");
        }

        public override string ToString()
        {
            return "Wand";
        }

        public override void Update(GameTime gameTime)
        {
            PlayPickUp();
        }
    }
}