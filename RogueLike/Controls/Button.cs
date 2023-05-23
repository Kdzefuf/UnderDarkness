using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace RogueLike
{
    public class Button : GameObject
    {
        protected MouseState currentMouseState;
        protected SpriteFont font;
        protected bool isHovered;
        protected MouseState prevMouse;
        protected Texture2D buttonTexture;
        protected Texture2D buttonTextureHovered;
        protected event EventHandler click;
        protected bool clicked { get; set; }
        protected Color fontColor = Color.Red;
        protected Vector2 pos { get; set; }
        protected int ButtonHeight = 96;
        protected int ButtonWidth = 256;
        protected string buttonString;
        protected int stringPosX;
        protected int stringPosY;

        public Button(int X, int Y, Mediator mediator, string buttonString) : base(mediator, X, Y)
        {
            hitbox = new Rectangle(this.X, this.Y, ButtonWidth, ButtonHeight);
            this.buttonString = buttonString;
            stringPosX = X + 100;
            stringPosY = Y + 20;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (isHovered)
            {
                spriteBatch.Draw(buttonTextureHovered, hitbox, Color.White);
                spriteBatch.DrawString(font, buttonString, new Vector2(stringPosX, stringPosY), fontColor);
            }
            else
            {
                spriteBatch.Draw(buttonTexture, hitbox, Color.White);
                spriteBatch.DrawString(font, buttonString, new Vector2(stringPosX, stringPosY), fontColor);
            }
        }

        public override void Load()
        {
            buttonTexture = Mediator.Game.Content.Load<Texture2D>(@"Graphic\UI\Menu\Buttons\button");
            buttonTextureHovered = Mediator.Game.Content.Load<Texture2D>(@"Graphic\UI\Menu\Buttons\buttonpress");
            font = Mediator.Game.Content.Load<SpriteFont>(@"Fonts/Font");
        }

        public override void Update(GameTime gameTime)
        {

        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)pos.X, (int)pos.Y, buttonTexture.Width, buttonTexture.Height);
            }
        }
    }
}
