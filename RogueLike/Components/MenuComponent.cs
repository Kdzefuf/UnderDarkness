using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    public class MenuComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private RogueGame rogueGame;
        private Texture2D background;
        private MenuItemsComponent menuItems;

        public MenuComponent(RogueGame rogueGame, MenuItemsComponent menuItems) : base(rogueGame)
        {
            this.rogueGame = rogueGame;
            this.menuItems = menuItems;
        }

        public override void Initialize()
        {




            base.Initialize();
        }

        protected override void LoadContent()
        {
            background = rogueGame.Content.Load<Texture2D>(@"Graphic\UI\Menu\mainmenu");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            rogueGame.spriteBatch.Begin();
            rogueGame.spriteBatch.Draw(background, new Vector2(400, 0), null, Color.White, 0f, Vector2.Zero, 8.45f, SpriteEffects.None, 0f);
            rogueGame.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
