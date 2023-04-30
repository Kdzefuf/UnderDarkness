using Microsoft.Xna.Framework;
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
            _path._pathFinder.ShortestPath(_map.GetCell(X, Y),
                _map.GetCell(_player.X, _player.Y)); ;
            X = _path.FirstCell.X;
            Y = _path.FirstCell.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float multiplier = Sprite.Width;
            spriteBatch.Draw(Sprite, new Vector2(X * multiplier, Y * multiplier), null,
                Color.White, 0.0f, Vector2.One, 1f, SpriteEffects.None, LayerDepth.Figures);
        }
    }
}
