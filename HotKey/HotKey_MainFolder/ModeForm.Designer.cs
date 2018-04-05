namespace HotKey_MainFolder
{
    partial class ModeForm
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
            this.backButton = new System.Windows.Forms.Button();
            this.modeLabel = new System.Windows.Forms.Label();
            this.hotKeyItemPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addHotKeyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 9);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 48);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeLabel.Location = new System.Drawing.Point(93, 9);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(348, 48);
            this.modeLabel.TabIndex = 2;
            this.modeLabel.Text = "Set Current Mode";
            // 
            // hotKeyItemPanel
            // 
            this.hotKeyItemPanel.AutoScroll = true;
            this.hotKeyItemPanel.BackColor = System.Drawing.SystemColors.Window;
            this.hotKeyItemPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.hotKeyItemPanel.Location = new System.Drawing.Point(13, 64);
            this.hotKeyItemPanel.Name = "hotKeyItemPanel";
            this.hotKeyItemPanel.Size = new System.Drawing.Size(859, 386);
            this.hotKeyItemPanel.TabIndex = 3;
            this.hotKeyItemPanel.WrapContents = false;
            // 
            // addHotKeyButton
            // 
            this.addHotKeyButton.Location = new System.Drawing.Point(762, 456);
            this.addHotKeyButton.Name = "addHotKeyButton";
            this.addHotKeyButton.Size = new System.Drawing.Size(110, 48);
            this.addHotKeyButton.TabIndex = 4;
            this.addHotKeyButton.Text = "Add Hot Key";
            this.addHotKeyButton.UseVisualStyleBackColor = true;
            this.addHotKeyButton.Click += new System.EventHandler(this.AddHotKeyButton_Click);
            // 
            // ModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 516);
            this.Controls.Add(this.addHotKeyButton);
            this.Controls.Add(this.hotKeyItemPanel);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.backButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModeForm";
            this.Text = "HotKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.FlowLayoutPanel hotKeyItemPanel;
        private System.Windows.Forms.Button addHotKeyButton;
    }
}

