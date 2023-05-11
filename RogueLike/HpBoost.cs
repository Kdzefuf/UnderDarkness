namespace RogueLike
{
    internal class HpBoost : GameObject
    {
        private int v1;
        private int v2;
        private int v3;

        public HpBoost(int v1, int v2, int v3, Mediator mediator)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.mediator = mediator;
        }
    }
}