using System;

namespace RogueLike
{
    /// <summary>
    /// Класс комнаты
    /// </summary>
    public class Room : GameObject
    {
        // Размер спрайта
        private int unit = 32;
        // Доступная координаты
        private int unitsAvailableX;
        private int unitsAvailableY;
        // Расположение спрайтов
        private int unitPosX;
        private int unitPosY;
        // Предыдущее расположение
        private int prevUnitPosX;
        private int prevUnitPosY;
        // Количество врагов
        private int enemyCount = 0;
        // Множитель
        private int multiplier = 1;
        // Случайное число
        private Random random = new Random();

        /// <summary>
        /// Комната
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посрденик</param>
        public Room(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            this.unitsAvailableX = x / this.unit;
            this.unitsAvailableY = y / this.unit;
        }

        /// <summary>
        /// инициализация случайного уровня
        /// </summary>
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

            GetLayFloor();
            GetRoomBoarders();
            int randomLevelOne = random.Next(level.LevelList.Count);
            int randomLevelTwo = random.Next(level.LevelList.Count);
            int randomLevelThree = random.Next(level.LevelList.Count);

            GetTraverseLevelArray(UnitCoordinate(2), UnitCoordinate(1), level.LevelList[randomLevelOne]);
            GetTraverseLevelArray(UnitCoordinate(9), UnitCoordinate(1), level.LevelList[randomLevelTwo]);
            GetTraverseLevelArray(UnitCoordinate(16), UnitCoordinate(1), level.LevelList[randomLevelThree]);
        }

        /// <summary>
        /// Установка координаты
        /// </summary>
        /// <param name="coordinate">Координата</param>
        /// <returns>Возвращает Установленную координату</returns>
        private int UnitCoordinate(int coordinate)
        {
            int unitCoordinates = coordinate * unit;
            return unitCoordinates;
        }

        /// <summary>
        /// Простой лабиринт
        /// </summary>
        public void GetSimpleMaze()
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
                mediator.AllObjects.Add(new HpFlask(200 / multiplier, UnitCoordinate(random
                    .Next(unitsAvailableX)), UnitCoordinate(random.Next(unitsAvailableY)), mediator));
            }
        }

        /// <summary>
        /// Список уровней для перехода
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="level">Уровень</param>
        private void GetTraverseLevelArray(int x, int y, int[,] level)
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

            // Границы
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
                            mediator.itemToBeAdded.Add(new SimpleBow(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            break;
                        case 4:
                            mediator.itemToBeAdded.Add(new HpFlask(60, x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            break;
                        case 5:
                            mediator.itemToBeAdded.Add(new CommonMonster(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            enemyCount++;
                            break;
                        case 6:
                            mediator.itemToBeAdded.Add(new FrozenBow(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            break;
                        case 7:
                            mediator.itemToBeAdded.Add(new SimpleGun(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            break;
                        case 8:
                            mediator.itemToBeAdded.Add(new Staff(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
                            break;
                        case 9:
                            mediator.itemToBeAdded.Add(new Boss(x + UnitCoordinate(i), y + UnitCoordinate(j), mediator));
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

        /// <summary>
        /// Границы комнаты
        /// </summary>
        private void GetRoomBoarders()
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

        /// <summary>
        /// Укладка пола
        /// </summary>
        private void GetLayFloor()
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

        /// <summary>
        /// Количество врагов
        /// </summary>
        public int EnemyCount
        {
            get => enemyCount;
            set => enemyCount = value;
        }

        /// <summary>
        /// Множитель
        /// </summary>
        public int Multiplier
        {
            get => multiplier;
            set => multiplier = value;
        }
    }
}