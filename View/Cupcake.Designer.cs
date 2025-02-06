namespace JapaneseCrossword.View
{
    partial class Cupcake
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CupcakeDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)CupcakeDataGridView).BeginInit();
            SuspendLayout();
            // 
            // CupcakeDataGridView
            // 
            CupcakeDataGridView.AllowUserToAddRows = false;
            CupcakeDataGridView.AllowUserToDeleteRows = false;
            CupcakeDataGridView.AllowUserToResizeColumns = false;
            CupcakeDataGridView.AllowUserToResizeRows = false;
            CupcakeDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CupcakeDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CupcakeDataGridView.Location = new Point(12, 12);
            CupcakeDataGridView.Name = "CupcakeDataGridView";
            CupcakeDataGridView.ReadOnly = true;
            CupcakeDataGridView.RowHeadersWidth = 51;
            CupcakeDataGridView.Size = new Size(325, 188);
            CupcakeDataGridView.TabIndex = 0;
            CupcakeDataGridView.SelectionChanged += CupcakeDataGridView_SelectionChanged;
            CupcakeDataGridView.DoubleClick += CupcakeDataGridView_DoubleClick;
            CupcakeDataGridView.KeyPress += CupcakeDataGridView_KeyPress;
            // 
            // Cupcake
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CupcakeDataGridView);
            Name = "Cupcake";
            Text = "Cupcake";
            ((System.ComponentModel.ISupportInitialize)CupcakeDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView CupcakeDataGridView;
    }
}