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
            LoadHeartDataGrid();
            ResizeColumns();
            _selectedColor = _currentColors.NextColor;
            maxIndexX = GetBiasVertical();
            maxIndexY = GetBiasHorizontal();
            CluesVertical(maxIndexX);
            CluesHorizontal(maxIndexY);
        }

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
        private int[,] _userSolution = new int[7, 7];
        private Colors _currentColors = new Colors(new List<Color>
        {
            Color.Black, Color.Red,
        });
        private Color _selectedColor;
        private int maxIndexX;
        private int maxIndexY;

        private void LoadHeartDataGrid()
        {
            for (int i = 0; i < HeartDataGridView.ColumnCount - 2; i++)
            {
                HeartDataGridView.Rows.Add();
            }
        }

        private void ResizeColumns()
        {
            foreach (DataGridViewColumn column in HeartDataGridView.Columns)
            {
                column.Width = 50;
            }
        }
        private int GetBiasVertical()
        {
            int maxIndex = 0;
            for (int i = 0; i < 7; i++)
            {
                int index = 0;
                for (int j = 0; j < 6; j++)
                {
                    if (_solution[i, j] != 0)
                    {
                        if (_solution[i, j] != _solution[i, j + 1])
                        {
                            index++;
                        }
                    }
                }
                if (_solution[i, 6] != 0)
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
            for (int i = 0; i < 7; i++)
            {
                int index = 0;
                for (int j = 0; j < 6; j++)
                {
                    if (_solution[j, i] != 0)
                    {
                        if (_solution[j, i] != _solution[j + 1, i])
                        {
                            index++;
                        }
                    }
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
                        Color.White;
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
            for (int i = 0; i < 7; i++)
            {
                int count = 1;
                int index = 0;
                for (int j = 0; j < 6; j++)
                {
                    if (_solution[i, j] != 0)
                    {
                        if (_solution[i, j] != _solution[i, j + 1])
                        {
                            HeartDataGridView.Rows[i + maxIndex].Cells[index].Value = count;
                            ChangeColor(_solution[i, j], index, i + maxIndex);
                            count = 1;
                            index++;
                        }
                        else if (_solution[i, j] == _solution[i, j + 1])
                        {
                            count++;
                        }
                    }
                }

                if (_solution[i, 6] != 0)
                {
                    HeartDataGridView.Rows[i + maxIndex].Cells[index].Value = count;
                    ChangeColor(_solution[i, 6], index, i + maxIndex);
                }
            }
        }

        private void CluesVertical(int maxIndex)
        {
            for (int i = 0; i < 7; i++)
            {
                int count = 1;
                int index = 0;
                for (int j = 0; j < 6; j++)
                {
                    if (_solution[j, i] != 0)
                    {
                        if (_solution[j, i] != _solution[j + 1, i])
                        {
                            HeartDataGridView.Rows[index].Cells[i + maxIndex].Value = count;
                            ChangeColor(_solution[j, i], i + maxIndex, index);
                            count = 1;
                            index++;
                        }
                        else if (_solution[j, i] == _solution[j + 1, i])
                        {
                            count++;
                        }
                    }
                }

                if (_solution[6, i] != 0)
                {
                    HeartDataGridView.Rows[index].Cells[i + maxIndex].Value = count;
                    ChangeColor(_solution[6, i], i + maxIndex, index);
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
                HeartDataGridView.Rows[currentRow].Cells[currentCell].Style.BackColor = _selectedColor;
                SetUserSolution(_selectedColor, currentRow, currentCell);
            }
        }

        private void HeartDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                _selectedColor = _currentColors.NextColor;
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
    }
}