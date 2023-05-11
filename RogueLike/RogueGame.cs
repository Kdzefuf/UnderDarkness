using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace RogueLike
{
    public class RogueGame : Game
    {
        private Room room;
        GraphicsDeviceManager _graphics;
        RenderTarget2D _nativeRenderTarget;
        Rectangle nativeWindowRectangle;
        Rectangle windowBoxingRect;
        float WindowAspect { get { return Window.ClientBounds.Width / (float)Window.ClientBounds.Height; } }
        float nativeAspect;
        SpriteBatch _spriteBatch;
        private List<GameObject> allObjects = new List<GameObject>();
        private List<GameObject> itemsToBeAdded = new List<GameObject>();
        private List<GameObject> itemsToBeDeleted = new List<GameObject>();
        private ActualGameState gameState = new ActualGameState(GameState.Menu);
        private GameTime gameTime;
        Player player = new Player(33, 230);
        Mediator mediator;
        private StartMenu startMenu;
        private GameOverMenu gameOverMenu;

        public RogueGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            room = new Room(800, 480, mediator);
            Mediator.Game = this;
            Content.RootDirectory = "Content";
            mediator = new Mediator(allObjects, itemsToBeAdded, itemsToBeDeleted, player, room, gameState);
            room.mediator = mediator;
            room.InitializeRandomLevel();
            itemsToBeAdded.Add(player);
            player.mediator = mediator;
            allObjects.Add(new HUD(800, 100, mediator));
            startMenu = new StartMenu(800, 580, mediator, gameTime);
            gameOverMenu = new GameOverMenu(800, 580, mediator, gameTime);
            mediator.gameOverMenu = gameOverMenu;
            _graphics.PreferredBackBufferHeight = 580;
            _graphics.ApplyChanges();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.SetRenderTarget(_nativeRenderTarget);
            GraphicsDevice.Clear(Color.Azure);
            _spriteBatch.Begin();

            switch (this.gameState.State)
            {
                case GameState.Play:
                    PlayDraw(gameTime);
                    break;

                case GameState.Menu:
                    startMenu.StateDraw(gameTime, _spriteBatch);
                    break;
                case GameState.GameOver:
                    gameOverMenu.StateDraw(gameTime, _spriteBatch);
                    break;
            }

            base.Draw(gameTime);
            _spriteBatch.End();
        }

        //protected override void EndDraw()
        //{
        //    GraphicsDevice.SetRenderTarget(null); // Sets target to back buffer
        //    GraphicsDevice.Clear(Color.Black); // Clears for black windowboxing

        //    _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null);
        //    _spriteBatch.Draw(_nativeRenderTarget, windowBoxingRect, Color.White); // Draw the _nativeRenderTarget as a texture
        //    _spriteBatch.End();
        //}

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //// Window
            //Window.AllowUserResizing = true;

            //// Graphics --------
            //nativeWindowRectangle = new Rectangle(0, 0, 1024, 576); // x y w h
            //nativeAspect = nativeWindowRectangle.Width / (float)nativeWindowRectangle.Height;
            //_graphics.PreferredBackBufferWidth = nativeWindowRectangle.Width;
            //_graphics.PreferredBackBufferHeight = nativeWindowRectangle.Height;
            //_graphics.SynchronizeWithVerticalRetrace = true; // Vsync, prevents screen tearing
            //_graphics.HardwareModeSwitch = true; // false is borderless window fullscreen, true is true fullscreen
            //_graphics.ApplyChanges(); // Makes the magic happen

            //_nativeRenderTarget = new RenderTarget2D(GraphicsDevice, nativeWindowRectangle.Width, nativeWindowRectangle.Height);
            //windowBoxingRect = nativeWindowRectangle;
            //Window.ClientSizeChanged += UpdateWindowBoxingRect;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach (GameObject gameObject in allObjects)
            {
                gameObject.Load();
            }

            // Create a new SpriteBatch, which can be used to draw textures
            // TODO: use this.Content to load your game content here
        }

        private void PlayDraw(GameTime gameTime)
        {
            foreach (GameObject gameObject in allObjects)
            {
                gameObject.Draw(_spriteBatch, gameTime);
            }
        }

        private void PlayUpdate(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var gameObject in allObjects)
            {
                if (player.hitbox.Intersects(gameObject.hitbox))
                {
                    player.Collision(gameObject);
                    gameObject.Collision(player);
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

        private void UpdateWindowBoxingRect(object sender, EventArgs e) // Updates windowBoxingRect
        {
            // Calculates dimensions of black bars on sides of screen
            int windowWidth, windowHeight;
            if (_graphics.IsFullScreen) { windowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; windowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; }
            else { windowWidth = Window.ClientBounds.Width; windowHeight = Window.ClientBounds.Height; }

            if (WindowAspect <= nativeAspect)
            {
                //Smaller output means taller than native, meaning top bars
                int presentHeight = (int)((windowWidth / nativeAspect) + 0.5f);
                int barHeight = (windowHeight - presentHeight) / 2;
                windowBoxingRect = new Rectangle(0, barHeight, windowWidth, presentHeight);
            }
            else
            {
                //Larger output means wider than native, meaning side bars
                int presentWidth = (int)((windowHeight * nativeAspect) + 0.5f);
                int barWidth = (windowWidth - presentWidth) / 2;
                windowBoxingRect = new Rectangle(barWidth, 0, presentWidth, windowHeight);
            }
        }

        private void ToggleFullscreen()
        {
            _graphics.IsFullScreen = !_graphics.IsFullScreen;
            if (_graphics.IsFullScreen)
            {
                _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            }
            else { _graphics.PreferredBackBufferWidth = nativeWindowRectangle.Width; _graphics.PreferredBackBufferHeight = nativeWindowRectangle.Height; }
            _graphics.ApplyChanges();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
            switch (this.gameState.State)
            {
                case GameState.Play:
                    PlayUpdate(gameTime);
                    break;
                case GameState.Menu:
                    startMenu.StateUpdate(gameTime, _spriteBatch);
                    break;
                case GameState.GameOver:
                    gameOverMenu.StateUpdate(gameTime, _spriteBatch);
                    break;
            }
        }
    }
}