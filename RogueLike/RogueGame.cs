using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace RogueLike
{
    public class RogueGame : Game
    {
        //private Room _room;
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private List<GameObject> allObjects = new List<GameObject>();
        private List<GameObject> itemsToBeAdded = new List<GameObject>();
        private List<GameObject> itemsToBeDeleted = new List<GameObject>();
        //private ActualGameState gameState = new ActualGameState(GameState.MENU);
        private GameTime _gameTime;
        Player _player = new Player(33, 230);
        Mediator _mediator;
        //private StartMenu _startMenu;
        //private GameOverMenu _gameOverMenu;

        public RogueGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Mediator.Game = this;
            //_mediator = new Mediator(allObjects, itemsToBeAdded, itemsToBeDeleted, player, room, gameState);
            //_room.mediator = mediator;
            //_room.initRandomLevel();
            itemsToBeAdded.Add(_player);
            _player.mediator = _mediator;
            //allObjects.Add(new HUD(800, 100, mediator));
            //startMenu = new StartMenu(800, 580, mediator, gameTime);
            //gameOverMenu = new GameOverMenu(800, 580, mediator, gameTime);
            //mediator.gameOverMenu = gameOverMenu;
            _graphics.PreferredBackBufferHeight = 580;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            foreach (GameObject gameObject in allObjects)
            {
                gameObject.Load();
            }

            base.LoadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here 

            base.Draw(gameTime);
        }

        protected void PlayUpdate(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // TODO: Add your update logic here
            foreach (var gameObject in allObjects)
            {
                if (_player.hitbox.Intersects(gameObject.hitbox))
                {
                    _player.Collision(gameObject);
                    gameObject.Collision(_player);
                }

                foreach (var otherGameObject in allObjects)
                {
                    if (gameObject.hitbox.Intersects(otherGameObject.hitbox))
                    {
                        gameObject.Collision(otherGameObject);
                    }
                }

                gameObject.Update(gameTime);
            }

            itemsToBeAdded.Sort();

            foreach (var gameObject in itemsToBeAdded)
            {
                gameObject.Load();
            }

            allObjects.AddRange(itemsToBeAdded);
            itemsToBeAdded.Clear();

            foreach (var gameObject in itemsToBeDeleted)
            {
                allObjects.Remove(gameObject);
            }
            itemsToBeDeleted.Clear();

            base.Update(gameTime);
        }

        private void PlayDraw(GameTime gameTime)
        {
            foreach (GameObject gameObject in allObjects)
            {
                gameObject.Draw(_spriteBatch, gameTime);
            }
        }
    }
}