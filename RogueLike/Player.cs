using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RogueSharp;

namespace RogueLike
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Texture2D Sprite { get; set; }
        public int speed = 1;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, new Vector2(X * Sprite.Width, Y * Sprite.Height), null, Color.White, 0.0f, Vector2.One, 1f, SpriteEffects.None, LayerDepth.Figures);
        }

        public bool HandleInput(InputState inputState, IMap map)
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.A) && key.IsKeyDown(Keys.D) && key.IsKeyDown(Keys.S) || key.IsKeyDown(Keys.A) && key.IsKeyDown(Keys.D) && key.IsKeyDown(Keys.W))
            {
                int tempX = X - speed;
                if (map.IsWalkable(tempX, Y))
                {
                    X = tempX;
                    return true;
                }
            }
            if (key.IsKeyDown(Keys.A))
            {
                int tempX = X - speed;
                if (map.IsWalkable(tempX, Y))
                {
                    X = tempX;
                    return true;
                }
            }
            else if (key.IsKeyDown(Keys.D))
            {
                int tempX = X + speed;
                if (map.IsWalkable(tempX, Y))
                {
                    X = tempX;
                    return true;
                }
            }
            else if (key.IsKeyDown(Keys.W))
            {
                int tempY = Y - speed;
                if (map.IsWalkable(X, tempY))
                {
                    Y = tempY;
                    return true;
                }
            }
            else if (key.IsKeyDown(Keys.S))
            {
                int tempY = Y + speed;
                if (map.IsWalkable(X, tempY))
                {
                    Y = tempY;
                    return true;
                }
            }
            return false;
        }
    }
}
