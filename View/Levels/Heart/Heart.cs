using JapaneseCrossword.Model;
using JapaneseCrossword.Services;
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

        public Heart()
        {
            InitializeComponent();
            _userSolution = new int[_solution.GetLength(0), _solution.GetLength(1)];
            offsetByX = GetOffsets.ByVertical(_solution);
            offsetByY = GetOffsets.ByHorizontal(_solution);
            CreateGrid.AddRowsAndColumns(HeartDataGridView, _solution,
                offsetByX, offsetByY);
            CreateGrid.ResizeRowsAndColumns(HeartDataGridView);
            _selectedColor = _currentColors.NextColor;
            CreateGrid.SetBoundaries(HeartDataGridView, offsetByX, offsetByY);
            SetCluesByVertical(offsetByX, offsetByY);
            SetCluesByHorizontal(offsetByY, offsetByX);
            CreateGrid.ResizeForm(HeartDataGridView, this);
            SetColor.CurrentColor(_selectedColor, HeartDataGridView,
                offsetByY, offsetByX);
        }

        //private static string imagePath = "C:\\Users\\fgfgf\\source\\repos\\JapaneseCrossword\\" +
        //    "Resources\\2d43c4570ee8728d74f3fc83f8730b3d.jpg";
        //private int[,] _solution = Pictures.ConvertImageToArray(imagePath);

        /// <summary>
        /// Устанавливает подсказки по горизонтали.
        /// </summary>
        /// <param name="offsetByY">Индекс смещения по веритикали.</param>
        /// <param name="offsetByX">Индекс смещения по горизонтали.</param>
        private void SetCluesByHorizontal(int offsetByY, int offsetByX)
        {
            for (int i = 0; i < _solution.GetLength(0); i++)
            {
                int count = 1;
                int index = offsetByX - 1;
                for (int j = 0; j < _solution.GetLength(1) - 1; j++)
                {
                    if (_solution[i, j] != 0)
                    {
                        if (_solution[i, j] != _solution[i, j + 1])
                        {
                            HeartDataGridView.Rows[i + offsetByY].Cells[index].Value
                                = count;
                            ChangeColor(_solution[i, j], index, i + offsetByY);
                            count = 1;
                            index--;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }

                if (_solution[i, _solution.GetLength(1) - 1] != 0
                    && count == 1)
                {
                    HeartDataGridView.Rows[i + offsetByY].Cells[index].Value = count;
                    ChangeColor(_solution[i, _solution.GetLength(1) - 1], index, i + offsetByY);
                }
            }
        }

        /// <summary>
        /// Устанавливает подсказки по вертикали.
        /// </summary>
        /// <param name="offsetByX">Индекс смещения по горизонтали.</param>
        /// <param name="offsetByY">Индекс смещения по веритикали.</param>
        private void SetCluesByVertical(int offsetByX, int offsetByY)
        {
            for (int i = 0; i < _solution.GetLength(1); i++)
            {
                int count = 1;
                int index = offsetByY - 1;
                for (int j = 0; j < _solution.GetLength(0) - 1; j++)
                {
                    if (_solution[j, i] != 0)
                    {
                        if (_solution[j, i] != _solution[j + 1, i])
                        {
                            HeartDataGridView.Rows[index].Cells[i + offsetByX].Value
                                = count;
                            ChangeColor(_solution[j, i], i + offsetByX, index);
                            count = 1;
                            index--;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }

                if (_solution[_solution.GetLength(0) - 1, i] != 0
                    && count == 1)
                {
                    HeartDataGridView.Rows[index].Cells[i + offsetByX].Value = count;
                    ChangeColor(_solution[_solution.GetLength(0) - 1, i], i + offsetByX, index);
                }
            }
        }

        /// <summary>
        /// Изменяет цвет клеток.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="column">Индекс столбца.</param>
        /// <param name="row">Индекс строки.</param>
        private void ChangeColor(int value, int column, int row)
        {
            switch (value)
            {
                case 1:
                    HeartDataGridView.Rows[row].Cells[column].Style.BackColor =
                        Color.Black;
                    HeartDataGridView.Rows[row].Cells[column].Style.ForeColor =
                        Color.White;
                    break;
                case 2:
                    HeartDataGridView.Rows[row].Cells[column].Style.BackColor =
                        Color.Red;
                    HeartDataGridView.Rows[row].Cells[column].Style.ForeColor =
                        Color.Black;
                    break;
            }
        }

        /// <summary>
        /// Устанавливает значение в матрице с решением игрока.
        /// </summary>
        /// <param name="selectedColor">Выбранный цвет.</param>
        /// <param name="row">Индекс строки.</param>
        /// <param name="column">Индекс столбца.</param>
        private void SetUserSolution(Color selectedColor, int row, int column)
        {
            switch (selectedColor.Name)
            {
                case "White":
                    _userSolution[row - offsetByY, column - offsetByX] = 0;
                    break;
                case "Black":
                    _userSolution[row - offsetByY, column - offsetByX] = 1;
                    break;
                case "Red":
                    _userSolution[row - offsetByY, column - offsetByX] = 2;
                    break;
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
                SetCross.ByHorizontal(currentRow, HeartDataGridView,
                    offsetByY, offsetByX, _solution, _userSolution);
                SetCross.ByVertical(currentColumn, HeartDataGridView,
                    offsetByY, offsetByX, _solution, _userSolution);
            }
        }

        private void HeartDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                _selectedColor = _currentColors.NextColor;
                SetColor.CurrentColor(_selectedColor, HeartDataGridView,
                 offsetByY, offsetByX);
            }
        }

        private void HeartDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (HeartDataGridView.CurrentCellAddress.Y >= offsetByY &&
                HeartDataGridView.CurrentCellAddress.X >= offsetByX)
            {
                int currentRow = HeartDataGridView.CurrentCellAddress.Y;
                int currentColumn = HeartDataGridView.CurrentCellAddress.X;
                HeartDataGridView.Rows[currentRow].Cells[currentColumn].Style.BackColor 
                    = Color.White;
                SetUserSolution(Color.White, currentRow, currentColumn);
                SetCross.ByHorizontal(currentRow, HeartDataGridView,
                    offsetByY, offsetByX, _solution, _userSolution);
                SetCross.ByVertical(currentColumn, HeartDataGridView,
                    offsetByY, offsetByX, _solution, _userSolution);
            }
        }

        private void ExaminationButton_Click(object sender, EventArgs e)
        {
            bool isCorrect = Examination.UserSolution(_solution, _userSolution);
            if (!isCorrect)
            {
                MessageBox.Show("К сожалению, кроссворд разгандан не полностью. " +
                    "Попробуйте еще раз.");
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
                CreateGrid.EmptyRectangle(e);
            }
            else
            {
                CreateGrid.BoldBoundaries(e, offsetByY, offsetByX);
            }
        }
    }
}