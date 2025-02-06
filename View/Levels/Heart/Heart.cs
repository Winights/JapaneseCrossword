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
            maxIndexX = GetBiasVertical();
            maxIndexY = GetBiasHorizontal();
            LoadHeartDataGrid();
            ResizeDataGrid();
            _selectedColor = _currentColors.NextColor;
            SetBoundaries();
            CluesVertical(maxIndexX);
            CluesHorizontal(maxIndexY);
            SetCurrentColor(_selectedColor);
        }

        //private static string imagePath = "C:\\Users\\fgfgf\\source\\repos\\JapaneseCrossword\\" +
        //    "Resources\\2d43c4570ee8728d74f3fc83f8730b3d.jpg";
        //private int[,] _solution = Pictures.ConvertImageToArray(imagePath);
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


        private int[,] _userSolution;
        private Colors _currentColors = new Colors(new List<Color>
        {
            Color.Black, Color.Red,
        });
        private Color _selectedColor;
        private int maxIndexX;
        private int maxIndexY;

        private void LoadHeartDataGrid()
        {
            for (int i = 0; i < _solution.GetLength(1) + maxIndexX; i++)
            {
                HeartDataGridView.Columns.Add($"column {i}", "Заголовок столбца");
            }
            for (int i = 0; i < _solution.GetLength(0) + maxIndexY; i++)
            {
                HeartDataGridView.Rows.Add();
            }
        }

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

            HeartDataGridView.Width = 52 * HeartDataGridView.ColumnCount;
            HeartDataGridView.Height = 50 * HeartDataGridView.Rows.Count;
            this.ClientSize = new System.Drawing.Size(50 * HeartDataGridView.ColumnCount,
                53 * (HeartDataGridView.Rows.Count + 1));
        }

        private void SetBoundaries()
        {
            for (int i = 0; i < HeartDataGridView.Columns.Count; i++)
            {
                for (int j = 0; j < HeartDataGridView.Rows.Count; j++)
                {
                    if (i < maxIndexX || j < maxIndexY)
                    {
                        HeartDataGridView.Rows[j].Cells[i].Style.BackColor = Color.LightGray;
                    }
                    if (i < maxIndexX && j < maxIndexY)
                    {
                        HeartDataGridView.Rows[j].Cells[i].Style.BackColor = Color.White;
                    }
                }
            }
        }
        private int GetBiasVertical()
        {
            int maxIndex = 0;
            for (int i = 0; i < _solution.GetLength(0); i++)
            {
                int index = 0;
                for (int j = 0; j < _solution.GetLength(1) - 1; j++)
                {
                    if (_solution[i, j] != 0 && _solution[i, j] != _solution[i, j + 1])
                    {
                        index++;
                    }
                }
                if (_solution[i, _solution.GetLength(0) - 1] != 0)
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

        private int GetBiasHorizontal()
        {
            int maxIndex = 0;
            for (int i = 0; i < _solution.GetLength(1); i++)
            {
                int index = 0;
                for (int j = 0; j < _solution.GetLength(0) - 1; j++)
                {
                    if (_solution[j, i] != 0 && _solution[j, i] != _solution[j + 1, i])
                    {
                        index++;
                    }
                }
                if (_solution[_solution.GetLength(0) - 1, i] != 0)
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

        private void SetUserSolution(Color selectedColor, int row, int cell)
        {
            switch (selectedColor.Name)
            {
                case "Black":
                    _userSolution[row - maxIndexY, cell - maxIndexX] = 1;
                    break;
                case "Red":
                    _userSolution[row - maxIndexY, cell - maxIndexX] = 2;
                    break;
                case "White":
                    _userSolution[row - maxIndexY, cell - maxIndexX] = 0;
                    break;
            }
        }

        private void CluesHorizontal(int maxIndex)
        {
            for (int i = 0; i < _solution.GetLength(0); i++)
            {
                int count = 1;
                int index = 0;
                for (int j = 0; j < _solution.GetLength(1) - 1; j++)
                {
                    if (_solution[i, j] != 0 && _solution[i, j] != _solution[i, j + 1])
                    {
                        HeartDataGridView.Rows[i + maxIndex].Cells[index].Value = count;
                        ChangeColor(_solution[i, j], index, i + maxIndex);
                        count = 1;
                        index++;
                    }
                    else if (_solution[i, j] != 0 && _solution[i, j] == _solution[i, j + 1])
                    {
                        count++;
                    }
                }

                if (_solution[i, _solution.GetLength(1) - 1] != 0)
                {
                    HeartDataGridView.Rows[i + maxIndex].Cells[index].Value = count;
                    ChangeColor(_solution[i, _solution.GetLength(1) - 1], index, i + maxIndex);
                }
            }
        }

        private void CluesVertical(int maxIndex)
        {
            for (int i = 0; i < _solution.GetLength(1); i++)
            {
                int count = 1;
                int index = 0;
                for (int j = 0; j < _solution.GetLength(0) - 1; j++)
                {
                    if (_solution[j, i] != 0 && _solution[j, i] != _solution[j + 1, i])
                    {
                        HeartDataGridView.Rows[index].Cells[i + maxIndex].Value = count;
                        ChangeColor(_solution[j, i], i + maxIndex, index);
                        count = 1;
                        index++;
                    }
                    else if (_solution[j, i] != 0 && _solution[j, i] == _solution[j + 1, i])
                    {
                        count++;
                    }
                }

                if (_solution[_solution.GetLength(0) - 1, i] != 0)
                {
                    HeartDataGridView.Rows[index].Cells[i + maxIndex].Value = count;
                    ChangeColor(_solution[_solution.GetLength(0) - 1, i], i + maxIndex, index);
                }
            }
        }

        private void SetCurrentColor(Color currentColor)
        {
            for (int i = 0; i < maxIndexY; i++)
            {
                for (int j = 0; j < maxIndexX; j++)
                {
                    HeartDataGridView.Rows[i].Cells[j].Style.BackColor =
                        currentColor;
                }
            }
        }


        private void HeartDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (HeartDataGridView.CurrentCellAddress.Y >= maxIndexY &&
                HeartDataGridView.CurrentCellAddress.X >= maxIndexX)
            {
                int currentRow = HeartDataGridView.CurrentCellAddress.Y;
                int currentCell = HeartDataGridView.CurrentCellAddress.X;
                foreach (DataGridViewCell cell in HeartDataGridView.SelectedCells)
                {
                    cell.Style.BackColor = _selectedColor;
                    SetUserSolution(_selectedColor, cell.RowIndex, cell.ColumnIndex);
                }
                SetUserSolution(_selectedColor, currentRow, currentCell);
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
            if (HeartDataGridView.CurrentCellAddress.Y >= maxIndexY &&
                HeartDataGridView.CurrentCellAddress.X >= maxIndexX)
            {
                int currentRow = HeartDataGridView.CurrentCellAddress.Y;
                int currentCell = HeartDataGridView.CurrentCellAddress.X;
                HeartDataGridView.Rows[currentRow].Cells[currentCell].Style.BackColor = Color.White;
                SetUserSolution(Color.White, currentRow, currentCell);
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
                MessageBox.Show("К сожалению, Ваше решение неверно. Попробуйте еще раз.");
                return;
            }
            MessageBox.Show("Поздравляю! Вы решили кроссворд!");


        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            for (int i = maxIndexY; i < HeartDataGridView.Rows.Count; i++)
            {
                for (int j = maxIndexX; j < HeartDataGridView.Columns.Count; j++)
                {
                    HeartDataGridView.Rows[i].Cells[j].Style.BackColor = Color.White;
                    SetUserSolution(Color.White, i, j);
                }
            }
        }

        private void HeartDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < maxIndexY && e.ColumnIndex < maxIndexX)
            {
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            }
            else if (e.RowIndex < maxIndexY && e.ColumnIndex == maxIndexX)
            {
                e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.Single;
                
            }
            else if (e.RowIndex == maxIndexY && e.ColumnIndex < maxIndexX)
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
            }
            else
            {
                return;

            }
        }
    }
}