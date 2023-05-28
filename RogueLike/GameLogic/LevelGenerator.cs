namespace RogueLike
{
    /// <summary>
    /// Класс генератора уровня
    /// </summary>
    public class LevelGenerator
    {
        // Посредник
        private Mediator mediator;
        private int[,] generatedLevelSlice = new int[,]
        {
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        };

        /// <summary>
        /// Генератор уровня
        /// </summary>
        /// <param name="mediator">Посредник</param>
        public LevelGenerator(Mediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Переустановка уровня к нулю
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int[,] ResetArrayToZero(int[,] array)
        {

            int uBound0 = array.GetUpperBound(0);
            int uBound1 = array.GetUpperBound(1);

            for (int i = 0; i < uBound0; i++)
            {
                for (int j = 0; j < uBound1; j++)
                {
                    array[i, j] = 0;
                }
            }
            return array;
        }

        /// <summary>
        /// Поменять местами элементы
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="ElementOneIndex">Первый элемент</param>
        /// <param name="ElementOneIndexTwo">Первый элемент второго индекса</param>
        /// <param name="ElementTwoIndex">Второй элемент</param>
        /// <param name="ElementTwoIndexTwo">Второй элемент второго индекса</param>
        public void SwapElements(int[,] array, int ElementOneIndex, int ElementOneIndexTwo, int ElementTwoIndex, int ElementTwoIndexTwo)
        {
            int temp = array[ElementOneIndex, ElementOneIndexTwo];
            array[ElementOneIndex, ElementOneIndexTwo] = array[ElementTwoIndex, ElementTwoIndexTwo];
            array[ElementTwoIndex, ElementTwoIndexTwo] = temp;
        }
    }
}
