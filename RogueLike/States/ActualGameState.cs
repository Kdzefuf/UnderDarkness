namespace RogueLike
{
    /// <summary>
    /// Класс текущего состояния игры
    /// </summary>
    public class ActualGameState : IMediator
    {
        // Состояние игры
        private GameState gameState;

        /// <summary>
        /// Текущее состояние игры
        /// </summary>
        /// <param name="gameState">Состояние игры</param>
        public ActualGameState(GameState gameState)
        {
            this.gameState = gameState;
        }

        /// <summary>
        /// Состояние игры
        /// </summary>
        public GameState State
        {
            get => gameState;
            set => gameState = value;
        }

        // Посредник
        public Mediator mediator { get; set; }
    }
}
