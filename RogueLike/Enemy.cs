using Microsoft.Xna.Framework.Graphics;
using RogueSharp;

namespace RogueLike
{
    public class Enemy
    {
        public IMap _map;
        public Player _player;
        private readonly PathToPlayer _path;
        public int X { get; set; }
        public int Y { get; set; }
        public Texture2D Sprite { get; set; }

        public Enemy(PathToPlayer path)
        {
            _path = path;
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
