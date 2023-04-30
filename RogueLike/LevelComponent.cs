using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueSharp;
using RogueSharp.MapCreation;

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
                new RandomRoomsMapCreationStrategy<Map>(Global.MapWidth, Global.MapHeight, 9, 12, 8);
            _map = Map.Create(mapCreationStrategy);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _ground = rogueGame.Content.Load<Texture2D>(@"Graphic\Environment\ground");
            _wall = rogueGame.Content.Load<Texture2D>(@"Graphic\Environment\wall");

            Cell startingCell = GetRandomEmptyCell();
            UpdatePlayerFieldOfView();

            startingCell = GetRandomEmptyCell();
            var pathFromEnemy = new PathToPlayer(_player, _map, rogueGame.Content.Load<Texture2D>(@"Graphic\Enemies\White"));
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
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            int sizeOfSprites = 32;
            foreach (Cell cell in _map.GetAllCells())
            {
                var position = new Vector2(cell.X * Global.SpriteWidth, cell.Y * Global.SpriteHeight);
                if (!cell.IsExplored)
                {
                    continue;
                }
                Color tint = Color.White;
                if (!cell.IsInFov)
                {
                    tint = Color.Gray;
                }
            }

            base.Draw(gameTime);
        }

        private Cell GetRandomEmptyCell()
        {
            while (true)
            {
                int x = Global.Random.Next(55);
                int y = Global.Random.Next(30);
                if (_map.IsWalkable(x, y))
                {
                    return (Cell)_map.GetCell(x, y);
                }
            }
        }

        private void UpdatePlayerFieldOfView()
        {
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
