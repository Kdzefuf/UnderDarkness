using System;

namespace RogueLike
{
    public class Room : GameObject
    {
        private int unit = 32;
        private int unitsAvailableX;
        private int unitsAvailableY;
        private int unitPosX;
        private int unitPosY;
        private int prevUnitPosX;
        private int prevUnitPosY;
        private int enemyCount = 0;
        private int multiplier = 1;
        private Random random = new Random();

        public Room(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            this.unitsAvailableX = x / this.unit;
            this.unitsAvailableY = y / this.unit;
        }

        public void InitializeRandomLevel()
        {
            foreach (var gameObject in mediator.AllObjects)
            {
                if (!(gameObject is Player || gameObject is HUDTile ||
                    gameObject is HUD))
                {
                    mediator.itemToBeDeleted.Add(gameObject);
                }
            }

            Level level = new Level();
            Random random = new Random();

            LayFloor();
            RoomBoarders();
            int randomLevelOne = random.Next(level.LevelList.Count);
            int randomLevelTwo = random.Next(level.LevelList.Count);
            int randomLevelTree = random.Next(level.LevelList.Count);

            TraverseLevelArray(UnitCoordinate(2), UnitCoordinate(1), level.LevelList[randomLevelOne]);
            TraverseLevelArray(UnitCoordinate(9), UnitCoordinate(1), level.LevelList[randomLevelTwo]);
            TraverseLevelArray(UnitCoordinate(16), UnitCoordinate(1), level.LevelList[randomLevelTree]);
        }

        private int UnitCoordinate(int coordinate)
        {
            int unitCoordinates = coordinate * unit;
            return unitCoordinates;
        }

        public void SimpleMaze()
        {
            Random random = new Random();

            for (int i = 0; i < multiplier; i++)
            {
                mediator.AllObjects.Add(new SpikesTile(UnitCoordinate(random.Next(unitsAvailableX)), UnitCoordinate(random.Next(unitsAvailableY)), 1, mediator));
            }

            for (int i = unit * 3; i < X - unit * 3; i += unit)
            {
                mediator.AllObjects.Add(new Wall(i, Y - (Y / 3 * 2) - unit, mediator));
                mediator.AllObjects.Add(new Wall(i, Y - Y / 3, mediator));
            }

            mediator.AllObjects.Add(new Wall(UnitCoordinate(3), UnitCoordinate(5), mediator));
            mediator.AllObjects.Add(new Wall(UnitCoordinate(3), UnitCoordinate(9), mediator));
            mediator.AllObjects.Add(new Wall(UnitCoordinate(21), UnitCoordinate(5), mediator));
            mediator.AllObjects.Add(new Wall(UnitCoordinate(21), UnitCoordinate(9), mediator));

            for (int i = 0; i < multiplier; i++)
            {
                mediator.AllObjects.Add(new HpBoost(200 / multiplier, UnitCoordinate(random
                    .Next(unitsAvailableX)), UnitCoordinate(random.Next(unitsAvailableY)), mediator));
            }
        }

        private void TraverseLevelArray(int x, int y, int[,] level)
        {
            /*
             * 0 = Ingenting
             * 1 = wall
             * 2 = lavatile
             * 3 = crossbow
             * 4 = Hp boost
             * 5 = Creep
             * 6 = FrozenBow
             * 7 = SimpleGun
             * 8 = Wand
             * 9 = BossGhost
             */

            int uBound0 = level.GetUpperBound(0);
            int uBound1 = level.GetUpperBound(1);

            for (int i = 0; i <= uBound0; i++)
            {
                for (int j = 0; j <= uBound1; j++)
                {
                    switch (level[i, j])
                    {
                        case 1:
                            mediator.itemToBeAdded.Add(new Wall(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            break;
                        case 2:
                            mediator.itemToBeAdded.Add(new SpikesTile(x + UnitCoordinate(i), y + UnitCoordinate(j), 0, mediator));
                            break;
                        case 3:
                            mediator.itemToBeAdded.Add(new Crossbow(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            break;
                        case 4:
                            mediator.itemToBeAdded.Add(new HpBoost(60, x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            break;
                        case 5:
                            mediator.itemToBeAdded.Add(new Creep(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            enemyCount++;
                            break;
                        case 6:
                            mediator.itemToBeAdded.Add(new FrozenBow(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            break;
                        case 7:
                            mediator.itemToBeAdded.Add(new SimpleGun(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            break;
                        case 8:
                            mediator.itemToBeAdded.Add(new Wand(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            break;
                        case 9:
                            mediator.itemToBeAdded.Add(new BossGhost(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            enemyCount++;
                            break;
                        case 10:
                            mediator.itemToBeAdded.Add(new Fiend(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            enemyCount++;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void RoomBoarders()
        {
            for (int i = 0; i < unitsAvailableX; i++)
            {
                mediator.itemToBeAdded.Add(new Wall(unitPosX, 0, mediator));
                mediator.itemToBeAdded.Add(new Wall(unitPosX, this.Y - unit, mediator));
                prevUnitPosX = unitPosX;
                unitPosX += unit;
            }
            for (int i = 0; i < unitsAvailableY; i++)
            {
                if (unitPosY == UnitCoordinate(7))
                {
                    mediator.itemToBeAdded.Add(new Door(UnitCoordinate(0), unitPosY, mediator, false));
                    mediator.itemToBeAdded.Add(new Door(UnitCoordinate(24), unitPosY, mediator, true));
                }
                else
                {
                    mediator.itemToBeAdded.Add(new Wall(0, unitPosY, mediator));
                    mediator.itemToBeAdded.Add(new Wall(X - unit, unitPosY, mediator));
                }

                prevUnitPosY = unitPosY;
                unitPosY = unitPosY + unit;
            }
        }

        private void LayFloor()
        {
            unitPosX = 0;
            unitPosY = 0;

            for (int i = 0; i < X; i += unit)
            {
                for (int j = 0; j < Y; j += unit)
                {
                    mediator.itemToBeAdded.Add(new Tiles(i, j, random.Next(3) + 1, this.mediator));
                }
            }
        }
    }
}