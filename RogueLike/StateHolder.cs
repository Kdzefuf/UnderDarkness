using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace RogueLike
{
    public class StateHolder
    {
        protected Mediator mediator;
        protected List<GameObject> stateObjects = new List<GameObject>();
        protected int x;
        protected int y;
        protected int unit = 32;
        protected GameTime gameTime;

        public StateHolder(Mediator mediator, int x, int y, GameTime gameTime)
        {
            this.mediator = mediator;
            this.x = x;
            this.y = y;
            this.gameTime = gameTime;
        }

        public void MenuBackground()
        {
            Random random = new Random();

            for (int i = 0; i < this.x; i += unit)
            {
                for (int j = 0; j < this.x; j += unit)
                {
                    stateObjects.Add(new HUDTile(i, j, random.Next(3), this.mediator));
                }
            }
        }

        public virtual void StateDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (GameObject gameObject in stateObjects)
            {
                gameObject.Load();
                gameObject.Draw(spriteBatch, gameTime);
            }
        }

        public void StateUpdate(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (GameObject gameObject in stateObjects)
            {
                gameObject.Update(gameTime);
            }
        }

        public List<GameObject> MenuObjects
        {
            get => stateObjects;
            set => stateObjects = value;
        }
    }
}