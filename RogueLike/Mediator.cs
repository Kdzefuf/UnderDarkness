using System.Collections.Generic;

namespace RogueLike
{
    public class Mediator
    {
        //public static GameMain Game { get; set; }
        public List<GameObject> AllObjects { get; }
        public List<GameObject> itemToBeAdded { get; }
        public List<GameObject> itemToBeDeleted { get; }
        //public ActualGameState State { get; set; }
        //public GameOverMenu gameOverMenu { get; set; }
        public Player player { get; }
        //public Room room { get; set; }

        public Mediator(List<GameObject> allObjects, List<GameObject> itemToBeAdded, List<GameObject> itemToBeDeleted, Player player/*Room room, ActualGameState actual*/)
        {
            this.AllObjects = allObjects;
            this.itemToBeAdded = itemToBeAdded;
            this.itemToBeDeleted = itemToBeDeleted;
            this.player = player;
            //this.room = room;
            //this.State = actual;
        }
    }
}
