using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace RogueLike
{
    class HUD : GameObject
    {
        private Player _player;
        private Level _level;
        private int unitsAvailableX;
        private int unitsAvailableY;
        private int unit = 32;
        private SpriteFont _spriteFont;
        private Color textColor = Color.LightYellow;

        public HUD(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            unitsAvailableX = X / unit;
            unitsAvailableY = Y / unit;

            InitHUDBackground();
        }

        public void DisplayDamage(SpriteBatch spriteBatch)
        {
            int x = unit * 8;
            int y = 480 + unit;

            if (mediator.player.Weapon == null)
            {
                Projectile p = new Projectile(0, 0, Direction.Up, mediator);
                spriteBatch.DrawString(_spriteFont, "DMG " + p.Damage, new Vector2(x, y), textColor);
            }
            else if (mediator.player.Weapon != null)
            {
                spriteBatch.DrawString(_spriteFont, "DMG ", new Vector2(x, y), textColor);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            StaticHUDText(spriteBatch);
        }

        private void InitHUDBackground()
        {
            Random random = new Random();

            for (int i = 0; i < X; i += unit)
            {
                for (int j = 0; j < Y; j += unit)
                {
                    mediator.AllObjects.Add(new HUDTile(i, j + 480, random.Next(3), mediator));
                }
            }
        }

        public override void Load()
        {
            _spriteFont = Mediator.Game.Content.Load<SpriteFont>(@"Fonts\Font");
        }

        private void StaticHUDText(SpriteBatch spriteBatch)
        {
            if (mediator.player.health > 0)
            {
                spriteBatch.DrawString(_spriteFont, "HP: " + mediator.player.health, new Vector2(0 + 10, 480), textColor);
            }
            else
            {
                spriteBatch.DrawString(_spriteFont, "DEAD", new Vector2(0 + 10, 480), textColor);
            }
            DisplayDamage(spriteBatch);
        }

        public int UnitCoord(int coordinates)
        {
            int unitCoord = coordinates * unit;
            return unitCoord;
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
