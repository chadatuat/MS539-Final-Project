
namespace MS539_Final_Project
{
    partial class MainMonkey
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
            this.onePlayerButton = new System.Windows.Forms.Button();
            this.onlinePlayButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // onePlayerButton
            // 
            this.onePlayerButton.Location = new System.Drawing.Point(12, 12);
            this.onePlayerButton.Name = "onePlayerButton";
            this.onePlayerButton.Size = new System.Drawing.Size(203, 55);
            this.onePlayerButton.TabIndex = 0;
            this.onePlayerButton.Text = "vs. CPU";
            this.onePlayerButton.UseVisualStyleBackColor = true;
            this.onePlayerButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // onlinePlayButton
            // 
            this.onlinePlayButton.Location = new System.Drawing.Point(12, 73);
            this.onlinePlayButton.Name = "onlinePlayButton";
            this.onlinePlayButton.Size = new System.Drawing.Size(203, 55);
            this.onlinePlayButton.TabIndex = 1;
            this.onlinePlayButton.Text = "vs. Player";
            this.onlinePlayButton.UseVisualStyleBackColor = true;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(12, 134);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(203, 55);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "Lose (Quit)";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // MainMonkey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 198);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.onlinePlayButton);
            this.Controls.Add(this.onePlayerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainMonkey";
            this.Text = "Monkey Mayhem!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button onePlayerButton;
        private System.Windows.Forms.Button onlinePlayButton;
        private System.Windows.Forms.Button quitButton;
    }
}

