using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    internal class FrozenBow : Weapon
    {
        private Texture2D sprite;
        private SoundEffect shoot;

        public FrozenBow(int x, int y, Mediator mediator) : base(x, y, mediator)
        {

        }

        public override bool Collision(GameObject other)
        {
            if (other is Player)
            {
                taken = true;
                mediator.player.Weapon = new FrozenBow(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
                mediator.player.weapon.Projectile = new FrozenBowProjectile(x, y, Direction.Up, mediator);
            }
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, spriteWidth, spriteHeight), Color.White);
            this.Projectile = new FrozenBowProjectile(0, 0, Direction.Up, mediator);
        }

        public override void Fire(int x, int y, Direction direction)
        {
            Projectile frozenBowProjectile = new FrozenBowProjectile(x, y, direction, mediator);
            this.Load();
            //shoot.CreateInstance().Play();
            frozenBowProjectile.Load();
            mediator.itemToBeAdded.Add(frozenBowProjectile);
        }

        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\frozen_bow");
            //pickUp = Mediator.Game.Content.Load<SoundEffect>("Sounds/PickupFrozenBow");
            //shoot = Mediator.Game.Content.Load<SoundEffect>("Sounds/FrozenBow");
        }

        public override string ToString()
        {
            return "Frozen Bow";
        }

        public override void Update(GameTime gameTime)
        {
            PlayPickUp();
        }
    }
}