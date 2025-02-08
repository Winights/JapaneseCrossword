using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseCrossword.Services
{
    /// <summary>
    /// Реализует создание таблицы определенных размеров и ее оформления.
    /// </summary>
    public class CreateGrid
    {
        /// <summary>
        /// Устанавливает размер таблицы и самой формы на ее основе.
        /// </summary>
        /// <param name="grid">Таблица.</param>
        public static void ResizeRowsAndColumns(DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.Width = 50;
            }

            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Height = 50;
            }
        }

        /// <summary>
        /// Устанавливает границы для подсказок и игрового поля.
        /// </summary>
        /// <param name="grid">Таблица.</param>
        /// <param name="offsetByX">Индекс смещения по горизонтали.</param>
        /// <param name="offsetByY">Индекс смещения по веритикали.</param>
        public static void SetBoundaries(DataGridView grid, int offsetByX, int offsetByY)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                for (int j = 0; j < grid.Rows.Count; j++)
                {
                    if (i < offsetByX || j < offsetByY)
                    {
                        grid.Rows[j].Cells[i].Style.BackColor = Color.LightGray;
                    }
                    if (i < offsetByX && j < offsetByY)
                    {
                        grid.Rows[j].Cells[i].Style.BackColor = Color.White;
                    }
                }
            }
        }

        /// <summary>
        /// Добавляет столбцы и строки в таблицу.
        /// </summary>
        /// <param name="grid">Таблица.</param>
        /// <param name="solution">Матрица с правильным решением.</param>
        /// <param name="offsetByX">Индекс смещения по горизонтали.</param>
        /// <param name="offsetByY">Индекс смещения по веритикали.</param>
        public static void AddRowsAndColumns(DataGridView grid, int[,] solution,
            int offsetByX, int offsetByY)
        {
            for (int i = 0; i < solution.GetLength(1) + offsetByX; i++)
            {
                grid.Columns.Add($"column {i}", "Заголовок столбца");
            }
            for (int i = 0; i < solution.GetLength(0) + offsetByY; i++)
            {
                grid.Rows.Add();
            }
        }

        /// <summary>
        /// Изменяет размер окна в зависимости от игрового поля.
        /// </summary>
        /// <param name="grid">Таблица.</param>
        /// <param name="mainForm">Окно с уровнем.</param>
        public static void ResizeForm(DataGridView grid, Form mainForm)
        {
            grid.Width = 52 * grid.ColumnCount;
            grid.Height = 50 * grid.Rows.Count;
            mainForm.ClientSize = new System.Drawing.Size(50 * grid.ColumnCount,
                53 * (grid.Rows.Count + 1));
        }

        /// <summary>
        /// Очищает от лишних границ, для создания пустого прямоугольника.
        /// </summary>
        /// <param name="cell">Событие отображающее отрисовку ячейки.</param>
        public static void EmptyRectangle(DataGridViewCellPaintingEventArgs cell)
        {
            cell!.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            cell!.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
        }

        /// <summary>
        /// Делает жирные границы для ограничения подсказок и игрового поля.
        /// </summary>
        /// <param name="cell">Событие отображающее отрисовку ячейки.</param>
        /// <param name="offsetByY">Индекс смещения по веритикали.</param>
        /// <param name="offsetByX">Индекс смещения по горизонтали.</param>
        public static void BoldBoundaries(DataGridViewCellPaintingEventArgs cell,
            int offsetByY, int offsetByX)
        {
            cell!.AdvancedBorderStyle.Top = (cell.RowIndex == offsetByY
                    && cell.ColumnIndex >= offsetByX)
                    ? DataGridViewAdvancedCellBorderStyle.OutsetDouble
                    : DataGridViewAdvancedCellBorderStyle.None;
            cell!.AdvancedBorderStyle.Left = (cell.RowIndex >= offsetByY
                && cell.ColumnIndex == offsetByX)
                ? DataGridViewAdvancedCellBorderStyle.OutsetDouble
                : DataGridViewAdvancedCellBorderStyle.None;
        }
    }
}
