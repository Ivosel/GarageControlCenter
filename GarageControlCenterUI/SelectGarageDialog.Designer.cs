namespace GarageControlCenterUI
{
    partial class SelectGarageDialog
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
            CreateGarageButton = new Button();
            SelectGarageButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // CreateGarageButton
            // 
            CreateGarageButton.DialogResult = DialogResult.Yes;
            CreateGarageButton.Location = new Point(22, 120);
            CreateGarageButton.Name = "CreateGarageButton";
            CreateGarageButton.Size = new Size(106, 23);
            CreateGarageButton.TabIndex = 0;
            CreateGarageButton.Text = "Create a garage";
            CreateGarageButton.UseVisualStyleBackColor = true;
            // 
            // SelectGarageButton
            // 
            SelectGarageButton.DialogResult = DialogResult.No;
            SelectGarageButton.Location = new Point(253, 120);
            SelectGarageButton.Name = "SelectGarageButton";
            SelectGarageButton.Size = new Size(106, 23);
            SelectGarageButton.TabIndex = 1;
            SelectGarageButton.Text = "Select a garage";
            SelectGarageButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(117, 59);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 2;
            label1.Text = "Create or select a garage!";
            // 
            // SelectGarageDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 169);
            Controls.Add(label1);
            Controls.Add(SelectGarageButton);
            Controls.Add(CreateGarageButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectGarageDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select a garage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CreateGarageButton;
        private Button SelectGarageButton;
        private Label label1;
    }
}