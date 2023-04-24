using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace RogueLike
{
    public class MenuItemsComponent : DrawableGameComponent
    {
        private RogueGame rogueGame;
        private List<MenuItem> items;

        public MenuItem selectedItem;
        private Vector2 position;

        private Texture2D itemTexture;
        private Texture2D selectedItemTexture;

        private int textSize;

        public MenuItemsComponent(RogueGame rogueGame, Vector2 position, Texture2D itemTexture,
            Texture2D selectedItemTexture, int textSize) : base(rogueGame)
        {
            this.rogueGame = rogueGame;
            this.position = position;
            this.itemTexture = itemTexture;
            this.selectedItemTexture = selectedItemTexture;
            this.textSize = textSize;
            items = new List<MenuItem>();
            selectedItem = null;
        }

        public override void Initialize()
        {


            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (rogueGame._mouseState.Position.Equals(position))


                base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            rogueGame.spriteBatch.Begin();
            foreach (MenuItem item in items)
            {
                Texture2D texture = itemTexture;
                if (item == selectedItem)
                    texture = selectedItemTexture;
            }
            rogueGame.spriteBatch.End();

            base.Draw(gameTime);
        }

        public void AddItem(string text)
        {
            Vector2 pos = new Vector2(position.X, position.Y + items.Count * textSize);
            MenuItem item = new MenuItem(text, pos);
            items.Add(item);
            if (selectedItem == null)
                selectedItem = item;
        }

        public void SelectNext()
        {
            int index = items.IndexOf(selectedItem);
            if (index < items.Count - 1)
                selectedItem = items[index + 1];
            else
                selectedItem = items[0];
        }

        public void SelectPrevious()
        {
            int index = items.IndexOf(selectedItem);
            if (index > 0)
                selectedItem = items[index - 1];
            else
                selectedItem = items[items.Count - 1];
        }
    }
}
