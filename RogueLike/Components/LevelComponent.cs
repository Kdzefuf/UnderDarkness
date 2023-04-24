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

        public LevelComponent(RogueGame rogueGame) : base(rogueGame)
        {
            this.rogueGame = rogueGame;
        }
        public override void Initialize()
        {
            IMapCreationStrategy<Map> mapCreationStrategy =
                new RandomRoomsMapCreationStrategy<Map>(60, 34, 7, 12, 8);
            rogueGame._map = Map.Create(mapCreationStrategy);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _ground = rogueGame.Content.Load<Texture2D>(@"Graphic\Environment\ground");
            _wall = rogueGame.Content.Load<Texture2D>(@"Graphic\Environment\wall");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            rogueGame.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            int sizeOfSprites = 32;
            foreach (Cell cell in rogueGame._map.GetAllCells())
            {
                var position = new Vector2(cell.X * sizeOfSprites, cell.Y * sizeOfSprites);
                if (cell.IsWalkable)
                {
                    rogueGame.spriteBatch.Draw(_ground, position, Color.White);
                }
                else
                {
                    rogueGame.spriteBatch.Draw(_wall, position, Color.White);
                }
            }
            rogueGame._player.Draw(rogueGame.spriteBatch);

            rogueGame.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
