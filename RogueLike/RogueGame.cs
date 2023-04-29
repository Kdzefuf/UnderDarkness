using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RogueSharp;
using System.Collections.Generic;
using System.Linq;

namespace RogueLike
{
    public class RogueGame : Game
    {
        public IMap _map;
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        private List<GameComponent> _components;

        public int windowWidth = 1920, windowHeight = 1080;
        public Player _player;

        private Texture2D _ground, _wall;
        private Texture2D itemTexture;
        private Texture2D selectedItemTexture;

        private SpriteFont _font;

        public InputState _inputState;

        public KeyboardState _keyboardState;

        public MouseState _mouseState;

        public RogueGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 50);
            _inputState = new InputState();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = windowWidth;
            _graphics.PreferredBackBufferHeight = windowHeight;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            IsMouseVisible = true;

            LevelComponent level = new LevelComponent(this);

            Components.Add(level);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _font = Content.Load<SpriteFont>(@"Fonts\Font");

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (_inputState.IsExitGame(PlayerIndex.One))
            {
                Exit();
            }

            _inputState.Update();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void ChangeComponentState(GameComponent gameComponent, bool enabled)
        {
            gameComponent.Enabled = enabled;
            if (gameComponent is DrawableGameComponent)
            {
                ((DrawableGameComponent)gameComponent).Visible = enabled;
            }
        }

        public GameComponent[] ReturnComponents()
        {
            return _components.ToArray();
        }

        public void SwitchScene(GameComponent scene)
        {
            GameComponent[] usedComponents = ReturnComponents();
            foreach (GameComponent component in Components)
            {
                bool isUsed = usedComponents.Contains(component);
                ChangeComponentState(component, isUsed);
            }
        }
    }
}