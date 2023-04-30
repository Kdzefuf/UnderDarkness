using RogueSharp.Random;

namespace RogueLike
{
    public class Global
    {
        public static readonly int MapWidth = 55;
        public static readonly int MapHeight = 30;
        public static readonly int SpriteWidth = 32;
        public static readonly int SpriteHeight = 32;

        public static readonly Camera Camera = new Camera();

        public static readonly IRandom Random = new DotNetRandom();
    }
}
