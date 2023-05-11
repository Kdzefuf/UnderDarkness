using Microsoft.Xna.Framework.Graphics;
using RogueSharp;

namespace RogueLike
{
    public class Enemy
    {
        public IMap _map;
        public Player _player;
        public int X { get; set; }
        public int Y { get; set; }
        public Texture2D Sprite { get; set; }

        public Enemy()
        {
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float multiplier = Sprite.Width;
        }
    }
}
