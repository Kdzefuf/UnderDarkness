namespace RogueLike
{
    internal class SimpleGun : GameObject
    {
        private object value1;
        private object value2;

        public SimpleGun(object value1, object value2, Mediator mediator)
        {
            this.value1 = value1;
            this.value2 = value2;
            this.mediator = mediator;
        }
    }
}