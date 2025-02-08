using JapaneseCrossword.Model;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapaneseCrossword.Levels.Heart
{
    public partial class Heart : Form
    {
        public Heart()
        {
            InitializeComponent();
            _userSolution = new int[_solution.GetLength(0), _solution.GetLength(1)];
            offsetByX = GetOffsetByVertical();
            offsetByY = GetOffsetByHorizontal();
            LoadHeartDataGrid();
            ResizeDataGrid();
            _selectedColor = _currentColors.NextColor;
            SetBoundaries();
            SetCluesByVertical(offsetByX, offsetByY);
            SetCluesByHorizontal(offsetByY, offsetByX);
            SetCurrentColor(_selectedColor);

            HeartDataGridView.Width = 52 * HeartDataGridView.ColumnCount;
            HeartDataGridView.Height = 50 * HeartDataGridView.Rows.Count;
            this.ClientSize = new System.Drawing.Size(50 * HeartDataGridView.ColumnCount,
                53 * (HeartDataGridView.Rows.Count + 1));
        }

        //private static string imagePath = "C:\\Users\\fgfgf\\source\\repos\\JapaneseCrossword\\" +
        //    "Resources\\2d43c4570ee8728d74f3fc83f8730b3d.jpg";
        //private int[,] _solution = Pictures.ConvertImageToArray(imagePath);
        /// <summary>
        /// Правильное решение.
        /// </summary>
        private int[,] _solution =
        {
            {0, 1, 1, 0, 1, 1, 0 },
            {1, 2, 2, 1, 2, 2, 1 },
            {1, 2, 2, 2, 2, 2, 1 },
            {1, 2, 2, 2, 2, 2, 1 },
            {0, 1, 2, 2, 2, 1, 0 },
            {0, 0, 1, 2, 1, 0, 0 },
            {0, 0, 0, 1, 0, 0, 0 }
        };

        /// <summary>
        /// Решение игрока.
        /// </summary>
        private int[,] _userSolution;

        /// <summary>
        /// Доступные цвета.
        /// </summary>
        private Colors _currentColors = new Colors(new List<Color>
        {
            Color.Black, Color.Red,
        });

        /// <summary>
        /// Выбранный цвет.
        /// </summary>
        private Color _selectedColor;

        /// <summary>
        /// Смещение по горизонтали.
        /// </summary>
        private int offsetByX;

        /// <summary>
        /// Смещение по вертикали.
        /// </summary>
        private int offsetByY;

        /// <summary>
        /// Добавляет столбцы и строки в таблицу.
        /// </summary>
        private void LoadHeartDataGrid()
        {
            for (int i = 0; i < _solution.GetLength(1) + offsetByX; i++)
            {
                HeartDataGridView.Columns.Add($"column {i}", "Заголовок столбца");
            }
            for (int i = 0; i < _solution.GetLength(0) + offsetByY; i++)
            {
                HeartDataGridView.Rows.Add();
            }
        }

        /// <summary>
        /// Устанавливает размер таблицы и самой формы на ее основе.
        /// </summary>
        private void ResizeDataGrid()
        {
            foreach (DataGridViewColumn column in HeartDataGridView.Columns)
            {
                column.Width = 50;
            }

            foreach (DataGridViewRow row in HeartDataGridView.Rows)
            {
                row.Height = 50;
            }
        }

        /// <summary>
        /// Устанавливает границы для подсказок и игрового поля.
        /// </summary>
        private void SetBoundaries()
        {
            for (int i = 0; i < HeartDataGridView.Columns.Count; i++)
            {
                for (int j = 0; j < HeartDataGridView.Rows.Count; j++)
                {
                    if (i < offsetByX || j < offsetByY)
                    {
                        HeartDataGridView.Rows[j].Cells[i].Style.BackColor = Color.LightGray;
                    }
                    if (i < offsetByX && j < offsetByY)
                    {
                        HeartDataGridView.Rows[j].Cells[i].Style.BackColor = Color.White;
                    }
                }
            }
        }

        /// <summary>
        /// Получает максимальный индекс для подсказок по веритикали.
        /// </summary>
        private int GetOffsetByVertical()
        {
            int maxIndex = 0;
            for (int i = 0; i < _solution.GetLength(0); i++)
            {
                int count = 1;
                int index = 0;
                for (int j = 0; j < _solution.GetLength(1) - 1; j++)
                {
                    if (_solution[i, j] != 0)
                    {
                        if (_solution[i, j] != _solution[i, j + 1])
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
                if (_solution[i, _solution.GetLength(0) - 1] != 0 && count == 1)
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
        private int GetOffsetByHorizontal()
        {
            int maxIndex = 0;
            for (int i = 0; i < _solution.GetLength(1); i++)
            {
                int count = 1;
                int index = 0;
                for (int j = 0; j < _solution.GetLength(0) - 1; j++)
                {
                    if (_solution[j, i] != 0)
                    {
                        if (_solution[j, i] != _solution[j + 1, i])
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
                if (_solution[_solution.GetLength(0) - 1, i] != 0 && count == 1)
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
        /// Изменяет цвет клеток.
        /// </summary>
        private void ChangeColor(int value, int index, int row)
        {
            switch (value)
            {
                case 1:
                    HeartDataGridView.Rows[row].Cells[index].Style.BackColor =
                        Color.Black;
                    HeartDataGridView.Rows[row].Cells[index].Style.ForeColor =
                        Color.White;
                    break;
                case 2:
                    HeartDataGridView.Rows[row].Cells[index].Style.BackColor =
                        Color.Red;
                    HeartDataGridView.Rows[row].Cells[index].Style.ForeColor =
                        Color.Black;
                    break;
            }
        }

        /// <summary>
        /// Устанавливает значение в матрице с решением игрока.
        /// </summary>
        private void SetUserSolution(Color selectedColor, int row, int cell)
        {
            switch (selectedColor.Name)
            {
                case "Black":
                    _userSolution[row - offsetByY, cell - offsetByX] = 1;
                    break;
                case "Red":
                    _userSolution[row - offsetByY, cell - offsetByX] = 2;
                    break;
                case "White":
                    _userSolution[row - offsetByY, cell - offsetByX] = 0;
                    break;
            }
        }

        /// <summary>
        /// Устанавливает подсказки по горизонтали.
        /// </summary>
        private void SetCluesByHorizontal(int maxIndex, int offset)
        {
            for (int i = 0; i < _solution.GetLength(0); i++)
            {
                int count = 1;
                int index = offset - 1;
                for (int j = 0; j < _solution.GetLength(1) - 1; j++)
                {
                    if (_solution[i, j] != 0)
                    {
                        if (_solution[i, j] != _solution[i, j + 1])
                        {
                            HeartDataGridView.Rows[i + maxIndex].Cells[index].Value = count;
                            ChangeColor(_solution[i, j], index, i + maxIndex);
                            count = 1;
                            index--;
                        }   
                        else
                        {
                            count++;
                        }
                    }
                }

                if (_solution[i, _solution.GetLength(1) - 1] != 0 && count == 1)
                {
                    HeartDataGridView.Rows[i + maxIndex].Cells[index].Value = count;
                    ChangeColor(_solution[i, _solution.GetLength(1) - 1], index, i + maxIndex);
                }
            }
        }

        /// <summary>
        /// Устанавливает подсказки по вертикали.
        /// </summary>
        private void SetCluesByVertical(int maxIndex, int offset)
        {
            for (int i = 0; i < _solution.GetLength(1); i++)
            {
                int count = 1;
                int index = offset - 1;
                for (int j = 0; j < _solution.GetLength(0) - 1; j++)
                {
                    if (_solution[j, i] != 0)
                    {
                        if(_solution[j, i] != _solution[j + 1, i])
                        {
                            HeartDataGridView.Rows[index].Cells[i + maxIndex].Value = count;
                            ChangeColor(_solution[j, i], i + maxIndex, index);
                            count = 1;
                            index--;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }

                if (_solution[_solution.GetLength(0) - 1, i] != 0 && count == 1)
                {
                    HeartDataGridView.Rows[index].Cells[i + maxIndex].Value = count;
                    ChangeColor(_solution[_solution.GetLength(0) - 1, i], i + maxIndex, index);
                }
            }
        }

        /// <summary>
        /// Устанавливает выбранный цвет.
        /// </summary>
        private void SetCurrentColor(Color currentColor)
        {
            for (int i = 0; i < offsetByY; i++)
            {
                for (int j = 0; j < offsetByX; j++)
                {
                    HeartDataGridView.Rows[i].Cells[j].Style.BackColor =
                        currentColor;
                }
            }
        }

        /// <summary>
        /// Проверка, что строка заполнена правильно.
        /// </summary>
        private bool ExaminationHorizontal(int currentRow)
        {
            for (int i = currentRow; i < currentRow+1; i++)
            {
                for (int j = 0; j < _solution.GetLength(1); j++)
                {
                    if (_solution[i - offsetByY, j] != _userSolution[i - offsetByY, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Проверка, что столбец заполнен правильно.
        /// </summary>
        private bool ExaminationVertical(int currentRow)
        {
            for (int i = 0; i < _solution.GetLength(1); i++)
            {
                for (int j = currentRow; j < currentRow+1; j++)
                {
                    if (_solution[i, j - offsetByX] != _userSolution[i, j - offsetByX])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Установка крестиков по горизонтали.
        /// </summary>
        private void SetCrossByHorizontal(int currentRow)
        {
            bool isCorrect = ExaminationHorizontal(currentRow);
            if (isCorrect)
            {
                for (int i = currentRow; i < currentRow + 1; i++)
                {
                    for (int j = offsetByX; j < _solution.GetLength(1)+offsetByX; j++)
                    {
                        if (_solution[i-offsetByY, j-offsetByX] == 0)
                        {
                            HeartDataGridView.Rows[i].Cells[j].Value = "❌";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Установка крестиков по вертикали.
        /// </summary>
        private void SetCrossByVertical(int currentColumn)
        {
            bool isCorrect = ExaminationVertical(currentColumn);
            if (isCorrect)
            {
                for (int i = offsetByY; i < _solution.GetLength(1) + offsetByY; i++)
                {
                    for (int j = currentColumn; j < currentColumn + 1; j++)
                    {
                        if (_solution[i - offsetByY, j - offsetByX] == 0)
                        {
                            HeartDataGridView.Rows[i].Cells[j].Value = "❌";
                        }
                    }
                }
            }
        }


        private void HeartDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (HeartDataGridView.CurrentCellAddress.Y >= offsetByY &&
                HeartDataGridView.CurrentCellAddress.X >= offsetByX)
            {
                foreach (DataGridViewCell cell in HeartDataGridView.SelectedCells)
                {
                    cell.Style.BackColor = _selectedColor;
                    SetUserSolution(_selectedColor, cell.RowIndex, cell.ColumnIndex);
                }
                int currentRow = HeartDataGridView.CurrentCellAddress.Y;
                int currentColumn = HeartDataGridView.CurrentCellAddress.X;
                SetUserSolution(_selectedColor, currentRow, currentColumn);
                SetCrossByHorizontal(currentRow);
                SetCrossByVertical(currentColumn);
            }
        }

        private void HeartDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                _selectedColor = _currentColors.NextColor;
                SetCurrentColor(_selectedColor);
            }
        }

        private void HeartDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (HeartDataGridView.CurrentCellAddress.Y >= offsetByY &&
                HeartDataGridView.CurrentCellAddress.X >= offsetByX)
            {
                int currentRow = HeartDataGridView.CurrentCellAddress.Y;
                int currentColumn = HeartDataGridView.CurrentCellAddress.X;
                HeartDataGridView.Rows[currentRow].Cells[currentColumn].Style.BackColor = Color.White;
                SetUserSolution(Color.White, currentRow, currentColumn);
                SetCrossByHorizontal(currentRow);
                SetCrossByVertical(currentColumn);
            }
        }

        private void ExaminationButton_Click(object sender, EventArgs e)
        {
            bool isCorrect = true;
            for (int i = 0; i < _solution.GetLength(0); i++)
            {
                for (int j = 0; j < _solution.GetLength(1); j++)
                {
                    if (_solution[i, j] != _userSolution[i, j])
                    {
                        isCorrect = false;
                    }
                }
            }

            if (!isCorrect)
            {
                MessageBox.Show("К сожалению, кроссворд разгандан не полностью. Попробуйте еще раз.");
                return;
            }
            MessageBox.Show("Поздравляю! Кроссворд полностью разгадан!");
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            for (int i = offsetByY; i < HeartDataGridView.Rows.Count; i++)
            {
                for (int j = offsetByX; j < HeartDataGridView.Columns.Count; j++)
                {
                    HeartDataGridView.Rows[i].Cells[j].Style.BackColor = Color.White;
                    HeartDataGridView.Rows[i].Cells[j].Value = null;
                    SetUserSolution(Color.White, i, j);
                }
            }
        }

        private void HeartDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < offsetByY && e.ColumnIndex < offsetByX)
            {
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = (e.RowIndex == offsetByY && e.ColumnIndex >= offsetByX)
                    ? DataGridViewAdvancedCellBorderStyle.OutsetDouble
                    : DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Left = (e.RowIndex >= offsetByY && e.ColumnIndex == offsetByX)
                    ? DataGridViewAdvancedCellBorderStyle.OutsetDouble
                    : DataGridViewAdvancedCellBorderStyle.None;
            }
        }
    }
}