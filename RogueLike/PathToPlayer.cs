using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueSharp;
using System.Collections.Generic;
using System.Linq;

namespace RogueLike
{
    public class PathToPlayer
    {
        public PathFinder _pathFinder;
        private readonly Player _player;
        private readonly IMap _map;
        private readonly Texture2D _sprite;
        private IEnumerable<Cell> _cells;

        public PathToPlayer(Player player, IMap map, Texture2D sprite)
        {
            _player = player;
            _map = map;
            _sprite = sprite;
            _pathFinder = new PathFinder(map);
        }

        public Cell FirstCell
        {
            get
            {
                return _cells.First();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_cells != null)
            {
                foreach (Cell cell in _cells)
                {
                    if (_cells != null)
                    {
                        float multiplier = _sprite.Width;
                        spriteBatch.Draw(_sprite, new Vector2(cell.X * multiplier, cell.Y * multiplier),
                            null, Color.Blue * .2f, 0.0f, Vector2.Zero, 0f, SpriteEffects.None, 0.6f);
                    }
                }
            }
        }
    }
}
