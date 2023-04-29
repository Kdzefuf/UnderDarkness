using RogueSharp.Random;

namespace RogueLike
{
    public enum GameStates
    {
        None = 0,
        PlayerTurn = 1,
        EnemyTurn = 2,
        Debugging = 3
    }

    public class Global
    {
        public static readonly int MapWidth = 20;
        public static readonly int MapHeight = 12;
        public static readonly int SpriteWidth = 32;
        public static readonly int SpriteHeight = 32;

        public static readonly Camera Camera = new Camera();

        public static readonly IRandom Random = new DotNetRandom();
        public static GameStates GameState { get; set; }
    }
}
