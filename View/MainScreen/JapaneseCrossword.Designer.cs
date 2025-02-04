namespace JapaneseCrossword
{
    partial class JapaneseCrossword
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JapaneseCrossword));
            StartButton = new Button();
            SelectLevelComboBox = new ComboBox();
            ChooseLabel = new Label();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.Location = new Point(232, 248);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(185, 73);
            StartButton.TabIndex = 0;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // SelectLevelComboBox
            // 
            SelectLevelComboBox.FormattingEnabled = true;
            SelectLevelComboBox.Location = new Point(197, 159);
            SelectLevelComboBox.Name = "SelectLevelComboBox";
            SelectLevelComboBox.Size = new Size(249, 28);
            SelectLevelComboBox.TabIndex = 1;
            SelectLevelComboBox.SelectedIndexChanged += this.SelectLevelComboBox_SelectedIndexChanged;
            // 
            // ChooseLabel
            // 
            ChooseLabel.AutoSize = true;
            ChooseLabel.BackColor = Color.Transparent;
            ChooseLabel.ForeColor = Color.Red;
            ChooseLabel.Location = new Point(279, 105);
            ChooseLabel.Name = "ChooseLabel";
            ChooseLabel.Size = new Size(105, 20);
            ChooseLabel.TabIndex = 2;
            ChooseLabel.Text = "Choose a level";
            // 
            // JapaneseCrossword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(682, 444);
            Controls.Add(ChooseLabel);
            Controls.Add(SelectLevelComboBox);
            Controls.Add(StartButton);
            Name = "JapaneseCrossword";
            Text = "Japanese Crossword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartButton;
        private ComboBox SelectLevelComboBox;
        private Label ChooseLabel;
    }
}
