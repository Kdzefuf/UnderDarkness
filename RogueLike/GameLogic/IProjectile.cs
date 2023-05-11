using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    interface IProjectile
    {
        void MoveProjectile();
        void DrawAccordingToDirection(SpriteBatch spriteBatch);
    }
}