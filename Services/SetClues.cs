using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseCrossword.Services
{
    /// <summary>
    /// Реализует установку подсказок.
    /// </summary>
    public class SetClues
    {
        /// <summary>
        /// Делегат установки определенного цвета в подсказку.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="column">Индекс столбца.</param>
        /// <param name="row">Индекс строки.</param>
        public delegate void SetColorInClue(int value, int column, int row);

        /// <summary>
        /// Устанавливает подсказки по вертикали.
        /// </summary>
        /// <param name="offsetByX">Индекс смещения по горизонтали.</param>
        /// <param name="offsetByY">Индекс смещения по веритикали.</param>
        /// <param name="grid">Таблица.</param>
        /// <param name="solution">Матрица с правильным решением.</param>
        /// <param name="setColor">Установка определенного цвета в подсказку.</param>
        public static void ByVertical(int offsetByX, int offsetByY, 
            DataGridView grid, int[,] solution, SetColorInClue setColor)
        {
            for (int i = 0; i < solution.GetLength(1); i++)
            {
                int count = 1;
                int index = offsetByY - 1;
                for (int j = 0; j < solution.GetLength(0) - 1; j++)
                {
                    if (solution[j, i] != 0)
                    {
                        if (solution[j, i] != solution[j + 1, i])
                        {
                            grid.Rows[index].Cells[i + offsetByX].Value
                                = count;
                            setColor(solution[j, i], i + offsetByX, index);
                            count = 1;
                            index--;
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
                    grid.Rows[index].Cells[i + offsetByX].Value = count;
                    setColor(solution[solution.GetLength(0) - 1, i], i + offsetByX, index);
                }
            }
        }

        /// <summary>
        /// Устанавливает подсказки по горизонтали.
        /// </summary>
        /// <param name="offsetByY">Индекс смещения по веритикали.</param>
        /// <param name="offsetByX">Индекс смещения по горизонтали.</param>
        /// <param name="grid">Таблица.</param>
        /// <param name="solution">Матрица с правильным решением.</param>
        /// <param name="setColor">Установка определенного цвета в подсказку.</param>

        public static void ByHorizontal(int offsetByY, int offsetByX,
            DataGridView grid, int[,] solution, SetColorInClue setColor)
        {
            for (int i = 0; i < solution.GetLength(0); i++)
            {
                int count = 1;
                int index = offsetByX - 1;
                for (int j = 0; j < solution.GetLength(1) - 1; j++)
                {
                    if (solution[i, j] != 0)
                    {
                        if (solution[i, j] != solution[i, j + 1])
                        {
                            grid.Rows[i + offsetByY].Cells[index].Value
                                = count;
                            setColor(solution[i, j], index, i + offsetByY);
                            count = 1;
                            index--;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }

                if (solution[i, solution.GetLength(1) - 1] != 0
                    && count == 1)
                {
                    grid.Rows[i + offsetByY].Cells[index].Value = count;
                    setColor(solution[i, solution.GetLength(1) - 1], index, i + offsetByY);
                }
            }
        }
    }
}
