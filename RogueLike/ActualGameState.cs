namespace RogueLike
{
    public class ActualGameState : IMediator
    {
        private GameState _gameState;

        public ActualGameState(GameState gameState)
        {
            _gameState = gameState;
        }

        public GameState State
        {
            get => _gameState;
            set => _gameState = value;
        }

        public Mediator mediator { get; set; }
    }
}
