using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using SharpDX.XInput;
using System;

namespace RogueLike
{
    /// <summary>
    /// Класс начального меню
    /// </summary>
    public class StartMenu : StateHolder
    {
        /// <summary>
        /// Начальное меню
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public StartMenu(int x, int y, Mediator mediator, GameTime gameTime) : base(mediator, x, y, gameTime)
        {
            this.x = x;
            this.y = y;
            this.mediator = mediator;
            InitializeMenu();
        }

        /// <summary>
        /// Инициализация меню
        /// </summary>
        private void InitializeMenu()
        {
            MenuBackground();
            stateObjects.Add(new TextField(280, 100, mediator, "Under Darkness", Color.White));
            stateObjects.Add(new PlayButton(250, 150, mediator, "Play"));
            stateObjects.Add(new ExitButton(250, 350, mediator, "Exit"));
            stateObjects.Add(new Cursor());
        }

        public override void Load()
        {
            menuSong = Mediator.Game.Content.Load<Song>(@"Graphic\music\StartMenu");
            MediaPlayer.Play(menuSong);
            MediaPlayer.IsRepeating = true;
        }

        public static explicit operator State(StartMenu v)
        {
            throw new NotImplementedException();
        }
    }
}