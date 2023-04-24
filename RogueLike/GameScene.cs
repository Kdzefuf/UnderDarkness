using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace RogueLike
{
    public class GameScene
    {
        private List<GameComponent> components;
        private RogueGame rogueGame;

        public void AddComponent(GameComponent component)
        {
            components.Add(component);
            if (!rogueGame.Components.Contains(component))
            {
                rogueGame.Components.Add(component);
            }
        }

        public void GameScreen(RogueGame rogueGame, params GameComponent[] components)
        {
            this.rogueGame = rogueGame;
            this.components = new List<GameComponent>();
            foreach (GameComponent component in components)
            {
                AddComponent(component);
            }
        }

        public GameComponent[] ReturnComponents()
        {
            return components.ToArray();
        }
    }
}
