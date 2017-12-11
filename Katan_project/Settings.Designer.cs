namespace Katan_project
{
    partial class Settings
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
            this.MusicCheck = new System.Windows.Forms.CheckBox();
            this.Save_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.RandomCheck = new System.Windows.Forms.CheckBox();
            this.CheatModeCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // MusicCheck
            // 
            this.MusicCheck.AutoSize = true;
            this.MusicCheck.Location = new System.Drawing.Point(34, 108);
            this.MusicCheck.Name = "MusicCheck";
            this.MusicCheck.Size = new System.Drawing.Size(54, 17);
            this.MusicCheck.TabIndex = 1;
            this.MusicCheck.Text = "Music";
            this.MusicCheck.UseVisualStyleBackColor = true;
            this.MusicCheck.CheckedChanged += new System.EventHandler(this.MusicCheck_CheckedChanged);
            // 
            // Save_button
            // 
            this.Save_button.Location = new System.Drawing.Point(34, 178);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(109, 44);
            this.Save_button.TabIndex = 2;
            this.Save_button.Text = "Save";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(149, 178);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(109, 44);
            this.Cancel_button.TabIndex = 3;
            this.Cancel_button.Text = "Cancel";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // RandomCheck
            // 
            this.RandomCheck.AutoSize = true;
            this.RandomCheck.Location = new System.Drawing.Point(34, 85);
            this.RandomCheck.Name = "RandomCheck";
            this.RandomCheck.Size = new System.Drawing.Size(90, 17);
            this.RandomCheck.TabIndex = 4;
            this.RandomCheck.Text = "Random Map";
            this.RandomCheck.UseVisualStyleBackColor = true;
            this.RandomCheck.CheckedChanged += new System.EventHandler(this.RandomCheck_CheckedChanged);
            // 
            // CheatModeCheck
            // 
            this.CheatModeCheck.AutoSize = true;
            this.CheatModeCheck.Location = new System.Drawing.Point(34, 131);
            this.CheatModeCheck.Name = "CheatModeCheck";
            this.CheatModeCheck.Size = new System.Drawing.Size(84, 17);
            this.CheatModeCheck.TabIndex = 5;
            this.CheatModeCheck.Text = "Cheat Mode";
            this.CheatModeCheck.UseVisualStyleBackColor = true;
            this.CheatModeCheck.CheckedChanged += new System.EventHandler(this.CheatModeCheck_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 240);
            this.Controls.Add(this.CheatModeCheck);
            this.Controls.Add(this.RandomCheck);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Save_button);
            this.Controls.Add(this.MusicCheck);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox MusicCheck;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.CheckBox RandomCheck;
        private System.Windows.Forms.CheckBox CheatModeCheck;
    }
}