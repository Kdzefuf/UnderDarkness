namespace RogueLike
{
    internal class FrozenBow : GameObject
    {
        private object value1;
        private object value2;

        public FrozenBow(object value1, object value2, Mediator mediator)
        {
            this.value1 = value1;
            this.value2 = value2;
            this.mediator = mediator;
        }
    }
}