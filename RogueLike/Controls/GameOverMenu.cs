using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс меню окончания игры
    /// </summary>
    public class GameOverMenu : StateHolder
    {
        // Шрифт
        private SpriteFont spriteFont;
        // Цвет текста
        private Color textColor = Color.LightYellow;

        // Игрок
        public Player player = new Player(0, 0);

        /// <summary>
        /// Меню окончания игры
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public GameOverMenu(int x, int y, Mediator mediator, GameTime gameTime) : base(mediator, x, y, gameTime)
        {

        }

        /// <summary>
        /// Дать статистику
        /// </summary>
        public void GiveStats()
        {
            stateObjects.Clear();
            MenuBackground();
            stateObjects.Add(new TextField(50, 50, this.mediator, "YOU HAVE DIED", Color.Yellow));
            stateObjects.Add(new TextField(50, 200, this.mediator, "LEVELS COMPLETED: " + player.LevelsCompleted, Color.Yellow));
            stateObjects.Add(new TextField(50, 400, this.mediator, "PROJECTILES FIRED: " + player.ProjectilesFired, Color.Yellow));
            stateObjects.Add(new ExitButton(50, 450, this.mediator, "EXIT"));

            stateObjects.Add(new Cursor());
        }
    }
}