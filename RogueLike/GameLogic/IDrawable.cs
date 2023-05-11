using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    interface IDrawable
    {
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        void Load();
    }
}
