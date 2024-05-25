namespace GarageControlCenterUI
{
    partial class GarageListDialog
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
            GaragesListBox = new ListBox();
            SelectGarageButton = new Button();
            SuspendLayout();
            // 
            // GaragesListBox
            // 
            GaragesListBox.FormattingEnabled = true;
            GaragesListBox.ItemHeight = 15;
            GaragesListBox.Location = new Point(12, 12);
            GaragesListBox.Name = "GaragesListBox";
            GaragesListBox.Size = new Size(107, 274);
            GaragesListBox.TabIndex = 0;
            // 
            // SelectGarageButton
            // 
            SelectGarageButton.DialogResult = DialogResult.OK;
            SelectGarageButton.Location = new Point(140, 127);
            SelectGarageButton.Name = "SelectGarageButton";
            SelectGarageButton.Size = new Size(111, 23);
            SelectGarageButton.TabIndex = 1;
            SelectGarageButton.Text = "Select";
            SelectGarageButton.UseVisualStyleBackColor = true;
            SelectGarageButton.Click += SelectGarageButton_Click;
            // 
            // GarageListDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 301);
            Controls.Add(SelectGarageButton);
            Controls.Add(GaragesListBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GarageListDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Garages";
            ResumeLayout(false);
        }

        #endregion

        private ListBox GaragesListBox;
        private Button SelectGarageButton;
    }
}