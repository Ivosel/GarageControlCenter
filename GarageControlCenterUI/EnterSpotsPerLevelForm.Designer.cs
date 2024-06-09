namespace GarageControlCenterUI
{
    partial class EnterSpotsPerLevelForm
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
            tableLayoutPanel = new TableLayoutPanel();
            CreateGarageButton = new Button();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Size = new Size(0, 0);
            tableLayoutPanel.TabIndex = 0;
            // 
            // CreateGarageButton
            // 
            CreateGarageButton.DialogResult = DialogResult.OK;
            CreateGarageButton.Location = new Point(12, 56);
            CreateGarageButton.Name = "CreateGarageButton";
            CreateGarageButton.Size = new Size(114, 23);
            CreateGarageButton.TabIndex = 1;
            CreateGarageButton.Text = "Create Garage";
            CreateGarageButton.UseVisualStyleBackColor = true;
            CreateGarageButton.Click += CreateGarageButton_Click;
            // 
            // EnterSpotsPerLevelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(131, 92);
            Controls.Add(CreateGarageButton);
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EnterSpotsPerLevelForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Parking Spots per Level";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Button CreateGarageButton;
    }
}