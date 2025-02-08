using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseCrossword.Services
{
    /// <summary>
    /// Реализует нахождения границ для подсказок.
    /// </summary>
    public class GetOffsets
    {
        /// <summary>
        /// Получает максимальный индекс для подсказок по веритикали.
        /// </summary>
        /// <param name="solution">Матрица с правильным решением.</param>
        /// <returns>Индекс по горизонтали, с которого начинается игровое поле.</returns>
        public static int ByVertical(int[,] solution)
        {
            int maxIndex = 0;
            for (int i = 0; i < solution.GetLength(0); i++)
            {
                int count = 1;
                int index = 0;
                for (int j = 0; j < solution.GetLength(1) - 1; j++)
                {
                    if (solution[i, j] != 0)
                    {
                        if (solution[i, j] != solution[i, j + 1])
                        {
                            count = 1;
                            index++;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
                if (solution[i, solution.GetLength(0) - 1] != 0
                    && count == 1)
                {
                    index++;
                }
                if (index > maxIndex)
                {
                    maxIndex = index;
                }
            }
            return maxIndex;
        }

        /// <summary>
        /// Получает максимальный индекс для подсказок по горизонтали.
        /// </summary>
        /// <param name="solution">Матрица с правильным решением.</param>
        /// <returns>Индекс по вертикали, с которого начинается игровое поле.</returns>
        public static int ByHorizontal(int[,] solution)
        {
            int maxIndex = 0;
            for (int i = 0; i < solution.GetLength(1); i++)
            {
                int count = 1;
                int index = 0;
                for (int j = 0; j < solution.GetLength(0) - 1; j++)
                {
                    if (solution[j, i] != 0)
                    {
                        if (solution[j, i] != solution[j + 1, i])
                        {
                            count = 1;
                            index++;
                        }
                        else
                        {
                            count++;
                        }

                    }
                }
                if (solution[solution.GetLength(0) - 1, i] != 0
                    && count == 1)
                {
                    index++;
                }
                if (index > maxIndex)
                {
                    maxIndex = index;
                }
            }
            return maxIndex;
        }
    }
}
