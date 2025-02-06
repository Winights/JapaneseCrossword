using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapaneseCrossword.View
{
    public partial class Cupcake : Form
    {
        public Cupcake()
        {
            InitializeComponent();
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

        private void CupcakeDataGridView_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void CupcakeDataGridView_DoubleClick(object sender, EventArgs e)
        {

        }

        private void CupcakeDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
