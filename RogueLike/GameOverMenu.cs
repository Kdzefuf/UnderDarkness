using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    public class GameOverMenu : StateHolder
    {
        private SpriteFont _spriteFont;
        private Color _textColor = Color.LightYellow;

        public Player _player = new Player(0, 0);

        public GameOverMenu(int x, int y, Mediator mediator, GameTime gameTime) : base(mediator, x, y, gameTime)
        {

        }

        public void GiveStats()
        {
            stateObjects.Clear();
            MenuBackground();
            stateObjects.Add(new TextField(50, 50, this.mediator, "YOU HAVE DIED", Color.Yellow));
            stateObjects.Add(new TextField(50, 200, this.mediator, "LEVELS COMPLETED: " + _player.LevelsCompleted, Color.Yellow));
            stateObjects.Add(new TextField(50, 400, this.mediator, "PROJECTILES FIRED: " + _player.ProjectilesFired, Color.Yellow));
            stateObjects.Add(new ExitButton(50, 450, this.mediator, "EXIT"));

            stateObjects.Add(new Cursor());
        }
    }
}