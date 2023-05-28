using System.Collections.Generic;

namespace RogueLike
{
    /// <summary>
    /// Класс посредника
    /// </summary>
    public class Mediator
    {
        // Игра
        public static RogueGame Game { get; set; }
        // Список всех объектов
        public List<GameObject> AllObjects { get; }
        // Предметы для добавления
        public List<GameObject> itemToBeAdded { get; }
        // Предметы для удаления
        public List<GameObject> itemToBeDeleted { get; }
        // Состояние игры
        public ActualGameState State { get; set; }
        // Меню окончания игры
        public GameOverMenu gameOverMenu { get; set; }
        // Игрок
        public Player player { get; }
        // Комната
        public Room room { get; set; }

        /// <summary>
        /// Посредник
        /// </summary>
        /// <param name="allObjects">Все объекты</param>
        /// <param name="itemToBeAdded">Предметы для добавления</param>
        /// <param name="itemToBeDeleted">Предметы для удаления</param>
        /// <param name="player">Игрок</param>
        /// <param name="room">Комната</param>
        /// <param name="actual">Текущее состояние</param>
        public Mediator(List<GameObject> allObjects, List<GameObject> itemToBeAdded, List<GameObject> itemToBeDeleted, Player player, Room room, ActualGameState actual)
        {
            this.AllObjects = allObjects;
            this.itemToBeAdded = itemToBeAdded;
            this.itemToBeDeleted = itemToBeDeleted;
            this.player = player;
            this.room = room;
            this.State = actual;
        }
    }
}
