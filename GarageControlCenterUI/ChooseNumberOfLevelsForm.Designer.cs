namespace GarageControlCenterUI
{
    partial class ChooseNumberOfLevelsForm
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
            NumberOfLevelsLabel = new Label();
            NumberOfLevelsSelect = new ComboBox();
            NumberOfLevelsOK = new Button();
            GarageNameTextBox = new TextBox();
            GarageNameLabel = new Label();
            SuspendLayout();
            // 
            // NumberOfLevelsLabel
            // 
            NumberOfLevelsLabel.AutoSize = true;
            NumberOfLevelsLabel.Location = new Point(23, 100);
            NumberOfLevelsLabel.Name = "NumberOfLevelsLabel";
            NumberOfLevelsLabel.Size = new Size(180, 15);
            NumberOfLevelsLabel.TabIndex = 0;
            NumberOfLevelsLabel.Text = "Select a number of garage levels:";
            NumberOfLevelsLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // NumberOfLevelsSelect
            // 
            NumberOfLevelsSelect.FormattingEnabled = true;
            NumberOfLevelsSelect.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            NumberOfLevelsSelect.Location = new Point(244, 97);
            NumberOfLevelsSelect.Name = "NumberOfLevelsSelect";
            NumberOfLevelsSelect.Size = new Size(101, 23);
            NumberOfLevelsSelect.TabIndex = 1;
            // 
            // NumberOfLevelsOK
            // 
            NumberOfLevelsOK.Location = new Point(270, 162);
            NumberOfLevelsOK.Name = "NumberOfLevelsOK";
            NumberOfLevelsOK.Size = new Size(75, 23);
            NumberOfLevelsOK.TabIndex = 2;
            NumberOfLevelsOK.Text = "OK";
            NumberOfLevelsOK.UseVisualStyleBackColor = true;
            NumberOfLevelsOK.Click += NumberOfLevelsOK_Click;
            // 
            // GarageNameTextBox
            // 
            GarageNameTextBox.Location = new Point(151, 47);
            GarageNameTextBox.Name = "GarageNameTextBox";
            GarageNameTextBox.Size = new Size(194, 23);
            GarageNameTextBox.TabIndex = 3;
            // 
            // GarageNameLabel
            // 
            GarageNameLabel.AutoSize = true;
            GarageNameLabel.Location = new Point(23, 50);
            GarageNameLabel.Name = "GarageNameLabel";
            GarageNameLabel.Size = new Size(109, 15);
            GarageNameLabel.TabIndex = 4;
            GarageNameLabel.Text = "Enter garage name:";
            // 
            // ChooseNumberOfLevelsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 206);
            Controls.Add(GarageNameLabel);
            Controls.Add(GarageNameTextBox);
            Controls.Add(NumberOfLevelsOK);
            Controls.Add(NumberOfLevelsSelect);
            Controls.Add(NumberOfLevelsLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChooseNumberOfLevelsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChooseNumberOfLevelsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NumberOfLevelsLabel;
        private ComboBox NumberOfLevelsSelect;
        private Button NumberOfLevelsOK;
        private TextBox GarageNameTextBox;
        private Label GarageNameLabel;
    }
}