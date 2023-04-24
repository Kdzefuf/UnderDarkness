
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueSharp;

namespace RogueLike
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Texture2D Sprite { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            float multiplier = Sprite.Width;
            spriteBatch.Draw(Sprite, new Vector2(X * multiplier, Y * multiplier), null, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }

        public bool HandleInput(InputState inputState, IMap map)
        {
            if (inputState.IsLeft(PlayerIndex.One))
            {
                int tempX = X - 1;
                if (map.IsWalkable(tempX, Y))
                {
                    X = tempX;
                    return true;
                }
            }
            else if (inputState.IsRight(PlayerIndex.One))
            {
                int tempX = X + 1;
                if (map.IsWalkable(tempX, Y))
                {
                    X = tempX;
                    return true;
                }
            }
            else if (inputState.IsUp(PlayerIndex.One))
            {
                int tempY = Y - 1;
                if (map.IsWalkable(X, tempY))
                {
                    Y = tempY;
                    return true;
                }
            }
            else if (inputState.IsDown(PlayerIndex.One))
            {
                int tempY = Y + 1;
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
