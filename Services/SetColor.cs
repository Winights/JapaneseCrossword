using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseCrossword.Services
{
    /// <summary>
    /// Реализует отображение текущего цвета.
    /// </summary>
    public class SetColor
    {
        /// <summary>
        /// Устанавливает выбранный цвет в пустое поле, как отображение текущего цвета.
        /// </summary>
        /// <param name="currentColor">Выбранный цвет.</param>
        /// <param name="grid">Таблица.</param>
        /// <param name="offsetByY">Индекс смещения по веритикали.</param>
        /// <param name="offsetByX">Индекс смещения по горизонтали.</param>
        public static void CurrentColor(Color currentColor, DataGridView grid,
            int offsetByY, int offsetByX)
        {
            for (int i = 0; i < offsetByY; i++)
            {
                for (int j = 0; j < offsetByX; j++)
                {
                    grid.Rows[i].Cells[j].Style.BackColor =
                        currentColor;
                }
            }
        }
    }
}
