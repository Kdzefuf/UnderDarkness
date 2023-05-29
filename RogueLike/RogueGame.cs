using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace RogueLike
{
    /// <summary>
    /// Класс игры
    /// </summary>
    public class RogueGame : Game
    {
        // Комната
        private Room room;
        GraphicsDeviceManager _graphics;
        Rectangle nativeWindowRectangle;
        SpriteBatch _spriteBatch;
        // Список всех объектов
        private List<GameObject> allObjects = new List<GameObject>();
        // Список предметов на добавление
        private List<GameObject> itemsToBeAdded = new List<GameObject>();
        // Список предметов на удаление
        private List<GameObject> itemsToBeDeleted = new List<GameObject>();
        // Состояние игры
        private ActualGameState gameState = new ActualGameState(GameState.Menu);
        // Игровое время
        private GameTime gameTime;
        // Игрок
        Player player = new Player(33, 230);
        // Посредник
        Mediator mediator;
        // Начальное меню
        private StartMenu startMenu;
        // Меню конца игры
        private GameOverMenu gameOverMenu;
        private Song menuSong;
        private Song gameSong;
        private Song gameOverSong;

        /// <summary>
        /// Конструктор
        /// </summary>
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
        /// Рисование
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
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
        /// Инициализирует игровую логику
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
        /// Загрузка контента
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach (GameObject gameObject in allObjects)
            {
                gameObject.Load();
            }
            menuSong = Mediator.Game.Content.Load<Song>(@"Graphic\music\StartMenu");
            gameSong = Mediator.Game.Content.Load<Song>(@"Graphic\music\Boss");
            gameOverSong = Mediator.Game.Content.Load<Song>(@"Graphic\music\GameOverMenu");
            if (gameState.State == GameState.Menu)
            {
                MediaPlayer.Play(menuSong);
                MediaPlayer.IsRepeating = true;
            }
            else if (gameState.State == GameState.GameOver)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(gameOverSong);
                MediaPlayer.IsRepeating = true;
            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Рисование в игре
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        private void PlayDraw(GameTime gameTime)
        {
            foreach (GameObject gameObject in allObjects)
            {
                gameObject.Draw(_spriteBatch, gameTime);
            }
        }

        /// <summary>
        /// Игровое обновление
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
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
        /// Обновление текущего состояния игры
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
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