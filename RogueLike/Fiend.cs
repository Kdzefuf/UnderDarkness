namespace RogueLike
{
    internal class Fiend : GameObject
    {
        private int v1;
        private int v2;

        public Fiend(int v1, int v2, Mediator mediator)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.mediator = mediator;
        }
    }
}