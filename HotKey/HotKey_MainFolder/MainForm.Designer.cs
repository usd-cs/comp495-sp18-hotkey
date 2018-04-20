namespace HotKey_MainFolder
{
    partial class MainForm
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
            this.testModeFormButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testModeFormButton
            // 
            this.testModeFormButton.Location = new System.Drawing.Point(12, 12);
            this.testModeFormButton.Name = "testModeFormButton";
            this.testModeFormButton.Size = new System.Drawing.Size(164, 61);
            this.testModeFormButton.TabIndex = 0;
            this.testModeFormButton.Text = "TEST MODE";
            this.testModeFormButton.UseVisualStyleBackColor = true;
            this.testModeFormButton.Click += new System.EventHandler(this.TestModeFormButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 516);
            this.Controls.Add(this.testModeFormButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "HotKey";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button testModeFormButton;
    }
}