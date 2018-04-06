namespace HotKey_MainFolder
{
    partial class HotKeyControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.actionLabel = new System.Windows.Forms.Label();
            this.keybindButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // actionLabel
            // 
            this.actionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLabel.Location = new System.Drawing.Point(3, 0);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(413, 50);
            this.actionLabel.TabIndex = 1;
            this.actionLabel.Text = "Example Action";
            this.actionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // keybindButton
            // 
            this.keybindButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keybindButton.Location = new System.Drawing.Point(422, 4);
            this.keybindButton.Name = "keybindButton";
            this.keybindButton.Size = new System.Drawing.Size(395, 43);
            this.keybindButton.TabIndex = 2;
            this.keybindButton.Text = "keybind";
            this.keybindButton.UseVisualStyleBackColor = true;
            this.keybindButton.Enter += new System.EventHandler(this.KeybindButton_Enter);
            this.keybindButton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeybindButton_KeyUp);
            this.keybindButton.Leave += new System.EventHandler(this.KeybindButton_Leave);
            // 
            // HotKeyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.keybindButton);
            this.Controls.Add(this.actionLabel);
            this.Name = "HotKeyControl";
            this.Size = new System.Drawing.Size(820, 50);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Button keybindButton;
    }
}
