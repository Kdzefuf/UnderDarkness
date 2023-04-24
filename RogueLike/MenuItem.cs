using Microsoft.Xna.Framework;

namespace RogueLike
{
    public class MenuItem
    {
        public string text;
        public Vector2 position;
        public float size;

        public MenuItem(string text, Vector2 position)
        {
            this.text = text;
            this.position = position;
            size = 10f;
        }
    }
}
