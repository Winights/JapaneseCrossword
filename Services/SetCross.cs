using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseCrossword.Services
{
    /// <summary>
    /// Реализует отображение крестиков.
    /// </summary>
    public class SetCross
    {
        /// <summary>
        /// Установливает крестики по вертикали.
        /// </summary>
        /// <param name="currentColumn">Выбранный столбец.</param>
        /// <param name="grid">Таблица.</param>
        /// <param name="offsetByY">Индекс смещения по веритикали.</param>
        /// <param name="offsetByX">Индекс смещения по горизонтали.</param>
        /// <param name="solution">Матрица с правильным решением.</param>
        /// <param name="userSolution">Матрица с решением игрока.</param>
        public static void ByVertical(int currentColumn, DataGridView grid,
            int offsetByY, int offsetByX, int[,] solution, int[,] userSolution)
        {
            bool isCorrect = Examination.Vertical(currentColumn, solution, 
                userSolution, offsetByX);
            if (isCorrect)
            {
                for (int i = offsetByY; i < solution.GetLength(1) + offsetByY; i++)
                {
                    for (int j = currentColumn; j < currentColumn + 1; j++)
                    {
                        if (solution[i - offsetByY, j - offsetByX] == 0)
                        {
                            grid.Rows[i].Cells[j].Value = "❌";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Установливает крестики по горизонтали.
        /// </summary>
        /// <param name="currentRow">Выбранная строка.</param>
        /// <param name="grid">Таблица.</param>
        /// <param name="offsetByY">Индекс смещения по веритикали.</param>
        /// <param name="offsetByX">Индекс смещения по горизонтали.</param>
        /// <param name="solution">Матрица с правильным решением.</param>
        /// <param name="userSolution">Матрица с решением игрока.</param>
        public static void ByHorizontal(int currentRow, DataGridView grid,
            int offsetByY, int offsetByX, int[,] solution, int[,] userSolution)
        {
            bool isCorrect = Examination.Horizontal(currentRow, solution,
                userSolution, offsetByY);
            if (isCorrect)
            {
                for (int i = currentRow; i < currentRow + 1; i++)
                {
                    for (int j = offsetByX; j < solution.GetLength(1) + offsetByX; j++)
                    {
                        if (solution[i - offsetByY, j - offsetByX] == 0)
                        {
                            grid.Rows[i].Cells[j].Value = "❌";
                        }
                    }
                }
            }
        }
    }
}
