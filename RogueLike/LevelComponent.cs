using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueSharp;
using RogueSharp.MapCreation;
using RogueSharp.Random;

namespace RogueLike
{
    public class LevelComponent : DrawableGameComponent
    {
        private RogueGame rogueGame;
        private Texture2D _ground;
        private Texture2D _wall;
        public Player _player;
        public IMap _map;

        public LevelComponent(RogueGame rogueGame) : base(rogueGame)
        {
            this.rogueGame = rogueGame;
        }
        public override void Initialize()
        {
            IMapCreationStrategy<Map> mapCreationStrategy =
                new RandomRoomsMapCreationStrategy<Map>(60, 34, 9, 12, 8);
            _map = Map.Create(mapCreationStrategy);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _ground = rogueGame.Content.Load<Texture2D>(@"Graphic\Environment\ground");
            _wall = rogueGame.Content.Load<Texture2D>(@"Graphic\Environment\wall");
            Cell startingCell = GetRandomEmptyCell();
            _player = new Player
            {
                X = startingCell.X,
                Y = startingCell.Y,
                Sprite = rogueGame.Content.Load<Texture2D>(@"Graphic\Hero\Stay\стоит1")
            };
            UpdatePlayerFieldOfView();

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (rogueGame._inputState.IsExitGame(PlayerIndex.One))
            {
                rogueGame.Exit();
            }
            else
            {
                if (_player.HandleInput(rogueGame._inputState, _map))
                {
                    UpdatePlayerFieldOfView();
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            rogueGame._spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            int sizeOfSprites = 32;
            foreach (Cell cell in _map.GetAllCells())
            {
                var position = new Vector2(cell.X * sizeOfSprites, cell.Y * sizeOfSprites);
                if (!cell.IsExplored)
                {
                    continue;
                }
                Color tint = Color.White;
                if (!cell.IsInFov)
                {
                    tint = Color.Gray;
                }
                if (cell.IsWalkable)
                {
                    rogueGame._spriteBatch.Draw(_ground, position, tint);
                }
                else
                {
                    rogueGame._spriteBatch.Draw(_wall, position, tint);
                }
            }
            _player.Draw(rogueGame._spriteBatch);

            rogueGame._spriteBatch.End();

            base.Draw(gameTime);
        }

        private Cell GetRandomEmptyCell()
        {
            IRandom random = new DotNetRandom();

            while (true)
            {
                int x = random.Next(55);
                int y = random.Next(32);
                if (_map.IsWalkable(x, y))
                {
                    return (Cell)_map.GetCell(x, y);
                }
            }
        }

        private void UpdatePlayerFieldOfView()
        {
            _map.ComputeFov(_player.X, _player.Y, 30, true);
            foreach (Cell cell in _map.GetAllCells())
            {
                if (_map.IsInFov(cell.X, cell.Y))
                {
                    _map.SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
                }
            }
        }
    }
}
