namespace RogueLike
{
    internal class Door : GameObject
    {
        private int v1;
        private int unitPosY;
        private bool v2;

        public Door(int v1, int unitPosY, Mediator mediator, bool v2)
        {
            this.v1 = v1;
            this.unitPosY = unitPosY;
            this.mediator = mediator;
            this.v2 = v2;
        }
    }
}