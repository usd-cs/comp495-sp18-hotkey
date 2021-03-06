﻿namespace HotKey_MainFolder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModeForm));
            this.backButton = new System.Windows.Forms.Button();
            this.modeLabel = new System.Windows.Forms.Label();
            this.hotKeyItemPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addHotKeyButton = new System.Windows.Forms.Button();
            this.activeIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(9, 7);
            this.backButton.Margin = new System.Windows.Forms.Padding(2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(56, 39);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeLabel.Location = new System.Drawing.Point(70, 7);
            this.modeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(284, 39);
            this.modeLabel.TabIndex = 2;
            this.modeLabel.Text = "Set Current Mode";
            // 
            // hotKeyItemPanel
            // 
            this.hotKeyItemPanel.AutoScroll = true;
            this.hotKeyItemPanel.BackColor = System.Drawing.SystemColors.Window;
            this.hotKeyItemPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.hotKeyItemPanel.Location = new System.Drawing.Point(10, 52);
            this.hotKeyItemPanel.Margin = new System.Windows.Forms.Padding(2);
            this.hotKeyItemPanel.Name = "hotKeyItemPanel";
            this.hotKeyItemPanel.Size = new System.Drawing.Size(644, 314);
            this.hotKeyItemPanel.TabIndex = 3;
            this.hotKeyItemPanel.WrapContents = false;
            this.hotKeyItemPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.hotKeyItemPanel_Paint);
            // 
            // addHotKeyButton
            // 
            this.addHotKeyButton.Location = new System.Drawing.Point(572, 370);
            this.addHotKeyButton.Margin = new System.Windows.Forms.Padding(2);
            this.addHotKeyButton.Name = "addHotKeyButton";
            this.addHotKeyButton.Size = new System.Drawing.Size(82, 39);
            this.addHotKeyButton.TabIndex = 4;
            this.addHotKeyButton.Text = "Add Hot Key";
            this.addHotKeyButton.UseVisualStyleBackColor = true;
            this.addHotKeyButton.Click += new System.EventHandler(this.AddHotKeyButton_Click);
            // 
            // activeIcon
            // 
            this.activeIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("activeIcon.Icon")));
            this.activeIcon.Text = "notifyIcon1";
            this.activeIcon.Visible = true;
            this.activeIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.activeIcon_MouseDoubleClick_1);
            // 
            // ModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 419);
            this.Controls.Add(this.addHotKeyButton);
            this.Controls.Add(this.hotKeyItemPanel);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.backButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
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
        private System.Windows.Forms.NotifyIcon activeIcon;
    }
}

