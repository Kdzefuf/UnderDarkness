using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueSharp;

namespace RogueLike
{
    public class LevelComponent : DrawableGameComponent
    {
        private RogueGame rogueGame;
        private Texture2D _ground;
        private Texture2D _wall;
        public Player _player;
        public Enemy _enemy;
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

            Global.Camera.ViewportWidth = rogueGame._graphics.GraphicsDevice.Viewport.Width;
            Global.Camera.ViewportHeight = rogueGame._graphics.GraphicsDevice.Viewport.Height;

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

            startingCell = GetRandomEmptyCell();
            var pathFromEnemy = new PathToPlayer(_player, _map, rogueGame.Content.Load<Texture2D>(@"Graphic\Enemies\White"));
            pathFromEnemy._pathFinder.ShortestPath(_map.GetCell(startingCell.X, startingCell.Y),
                _map.GetCell(_player.X, _player.Y));
            _enemy = new Enemy(pathFromEnemy)
            {
                X = startingCell.X,
                Y = startingCell.Y,
                Sprite = rogueGame.Content.Load<Texture2D>(@"Graphic\Enemies\Boar\boar1")
            };

            Global.Camera.CenterOn(startingCell);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            Global.Camera.HandleInput(rogueGame._inputState, PlayerIndex.One);

            if (rogueGame._inputState.IsExitGame(PlayerIndex.One))
            {
                rogueGame.Exit();
            }
            // New code to handle switching modes when spacebar is pressed
            else if (rogueGame._inputState.IsSpace(PlayerIndex.One))
            {
                if (Global.GameState == GameStates.PlayerTurn)
                {
                    Global.GameState = GameStates.Debugging;
                }
                else if (Global.GameState == GameStates.Debugging)
                {
                    Global.GameState = GameStates.PlayerTurn;
                }
            }
            else
            {
                if (_player.HandleInput(rogueGame._inputState, _map))
                {
                    Global.Camera.CenterOn((Cell)_map.GetCell(_player.X, _player.Y));
                    UpdatePlayerFieldOfView();
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            rogueGame._spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, Global.Camera.TranslationMatrix);
            int sizeOfSprites = 32;
            foreach (Cell cell in _map.GetAllCells())
            {
                var position = new Vector2(cell.X * sizeOfSprites, cell.Y * sizeOfSprites);
                if (!cell.IsExplored && Global.GameState != GameStates.Debugging)
                {
                    continue;
                }
                Color tint = Color.White;
                if (!cell.IsInFov && Global.GameState != GameStates.Debugging)
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
            if (Global.GameState == GameStates.Debugging
                || _map.IsInFov(_enemy.X, _enemy.Y))
            {
                _enemy.Draw(rogueGame._spriteBatch);
            }

            rogueGame._spriteBatch.End();

            base.Draw(gameTime);
        }

        private Cell GetRandomEmptyCell()
        {
            while (true)
            {
                int x = Global.Random.Next(55);
                int y = Global.Random.Next(32);
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
