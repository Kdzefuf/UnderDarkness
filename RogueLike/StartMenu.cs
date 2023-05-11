using Microsoft.Xna.Framework;

namespace RogueLike
{
    public class StartMenu : StateHolder
    {
        public StartMenu(int x, int y, Mediator mediator, GameTime gameTime) : base(mediator, x, y, gameTime)
        {
            this.x = x;
            this.y = y;
            this.mediator = mediator;
            InitMenu();
        }

        private void InitMenu()
        {
            MenuBackground();
            stateObjects.Add(new TextField(300, 100, mediator, "Under Darkness", Color.White));
            stateObjects.Add(new PlayButton(400 - 100, 150, mediator, "Play"));
            stateObjects.Add(new ExitButton(400 - 100, 350, mediator, "Exit"));
            stateObjects.Add(new Cursor());
        }
    }
}