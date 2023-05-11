namespace RogueLike
{
    internal class SpikesTile : GameObject
    {
        private object value1;
        private object value2;
        private int v;

        public SpikesTile(object value1, object value2, int v, Mediator mediator)
        {
            this.value1 = value1;
            this.value2 = value2;
            this.v = v;
            this.mediator = mediator;
        }
    }
}