using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseCrossword.Services
{
    /// <summary>
    /// Реализует проверку правильности заполнения.
    /// </summary>
    public class Examination
    {
        /// <summary>
        /// Проверяет, что строка заполнена правильно.
        /// </summary>
        /// <param name="currentRow">Выбранная строка.</param>
        /// <param name="solution">Матрица с правильным решением.</param>
        /// <param name="userSolution">Матрица с решением игрока.</param>
        /// <param name="offsetByY">Индекс смещения по веритикали.</param>
        /// <returns>false, если заполнено неправильно, иначе true.</returns>
        public static bool Horizontal(int currentRow, int[,] solution, 
            int[,] userSolution, int offsetByY)
        {
            for (int i = currentRow; i < currentRow + 1; i++)
            {
                for (int j = 0; j < solution.GetLength(1); j++)
                {
                    if (solution[i - offsetByY, j] != userSolution[i - offsetByY, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Проверяет, что столбец заполнен правильно.
        /// </summary>
        /// <param name="currentColumn">Выбранный столбец.</param>
        /// <param name="solution">Матрица с правильным решением.</param>
        /// <param name="userSolution">Матрица с решением игрока.</param>
        /// <param name="offsetByX">Индекс смещения по горизонтали.</param>
        /// <returns>false, если заполнено неправильно, иначе true.</returns>
        public static bool Vertical(int currentColumn, int[,] solution, 
            int[,] userSolution, int offsetByX)
        {
            for (int i = 0; i < solution.GetLength(1); i++)
            {
                for (int j = currentColumn; j < currentColumn + 1; j++)
                {
                    if (solution[i, j - offsetByX] != userSolution[i, j - offsetByX])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Проверяет решение игрока.
        /// </summary>
        /// <param name="solution">Матрица с правильным решением.</param>
        /// <param name="userSolution">Матрица с решением игрока.</param>
        /// <returns>false, если решение неправильное, иначе true.</returns>
        public static bool UserSolution(int[,] solution, int[,] userSolution)
        {
            for (int i = 0; i < solution.GetLength(0); i++)
            {
                for (int j = 0; j < solution.GetLength(1); j++)
                {
                    if (solution[i, j] != userSolution[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
