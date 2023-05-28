using Microsoft.Xna.Framework;

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
            stateObjects.Add(new TextField(300, 100, mediator, "Under Darkness", Color.White));
            stateObjects.Add(new PlayButton(400 - 100, 150, mediator, "Play"));
            stateObjects.Add(new ExitButton(400 - 100, 350, mediator, "Exit"));
            stateObjects.Add(new Cursor());
        }
    }
}