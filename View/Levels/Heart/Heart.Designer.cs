namespace JapaneseCrossword.Levels.Heart
{
    partial class Heart
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
            HeartDataGridView = new DataGridView();
            ExaminationButton = new Button();
            ClearButton = new Button();
            ((System.ComponentModel.ISupportInitialize)HeartDataGridView).BeginInit();
            SuspendLayout();
            // 
            // HeartDataGridView
            // 
            HeartDataGridView.AllowUserToAddRows = false;
            HeartDataGridView.AllowUserToDeleteRows = false;
            HeartDataGridView.AllowUserToResizeColumns = false;
            HeartDataGridView.AllowUserToResizeRows = false;
            HeartDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            HeartDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            HeartDataGridView.ColumnHeadersVisible = false;
            HeartDataGridView.Location = new Point(0, 0);
            HeartDataGridView.Name = "HeartDataGridView";
            HeartDataGridView.ReadOnly = true;
            HeartDataGridView.RowHeadersVisible = false;
            HeartDataGridView.RowHeadersWidth = 51;
            HeartDataGridView.Size = new Size(603, 416);
            HeartDataGridView.TabIndex = 0;
            HeartDataGridView.CellPainting += HeartDataGridView_CellPainting;
            HeartDataGridView.SelectionChanged += HeartDataGridView_SelectionChanged;
            HeartDataGridView.DoubleClick += HeartDataGridView_DoubleClick;
            HeartDataGridView.KeyPress += HeartDataGridView_KeyPress;
            // 
            // ExaminationButton
            // 
            ExaminationButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ExaminationButton.Location = new Point(12, 444);
            ExaminationButton.Name = "ExaminationButton";
            ExaminationButton.Size = new Size(184, 32);
            ExaminationButton.TabIndex = 1;
            ExaminationButton.Text = "Проверить решение";
            ExaminationButton.UseVisualStyleBackColor = true;
            ExaminationButton.Click += ExaminationButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ClearButton.Location = new Point(407, 448);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(184, 28);
            ClearButton.TabIndex = 2;
            ClearButton.Text = "Очистить поле";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // Heart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 488);
            Controls.Add(ClearButton);
            Controls.Add(ExaminationButton);
            Controls.Add(HeartDataGridView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Heart";
            Text = "Heart";
            ((System.ComponentModel.ISupportInitialize)HeartDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView HeartDataGridView;
        private Button ExaminationButton;
        private Button ClearButton;
    }
}