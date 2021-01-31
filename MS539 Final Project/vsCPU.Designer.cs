
namespace MS539_Final_Project
{
    partial class vsCPU
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
            this.difficultyGroupBox = new System.Windows.Forms.GroupBox();
            this.kingKongRadioButton = new System.Windows.Forms.RadioButton();
            this.grapeApeRadioButton = new System.Windows.Forms.RadioButton();
            this.begginerRadioButton = new System.Windows.Forms.RadioButton();
            this.noviceRadioButton = new System.Windows.Forms.RadioButton();
            this.beginButton = new System.Windows.Forms.Button();
            this.mainMenuButton = new System.Windows.Forms.Button();
            this.difficultyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // difficultyGroupBox
            // 
            this.difficultyGroupBox.Controls.Add(this.kingKongRadioButton);
            this.difficultyGroupBox.Controls.Add(this.grapeApeRadioButton);
            this.difficultyGroupBox.Controls.Add(this.begginerRadioButton);
            this.difficultyGroupBox.Controls.Add(this.noviceRadioButton);
            this.difficultyGroupBox.Location = new System.Drawing.Point(14, 14);
            this.difficultyGroupBox.Name = "difficultyGroupBox";
            this.difficultyGroupBox.Size = new System.Drawing.Size(209, 146);
            this.difficultyGroupBox.TabIndex = 0;
            this.difficultyGroupBox.TabStop = false;
            this.difficultyGroupBox.Text = "Difficulty";
            // 
            // kingKongRadioButton
            // 
            this.kingKongRadioButton.AutoSize = true;
            this.kingKongRadioButton.Location = new System.Drawing.Point(6, 115);
            this.kingKongRadioButton.Name = "kingKongRadioButton";
            this.kingKongRadioButton.Size = new System.Drawing.Size(106, 24);
            this.kingKongRadioButton.TabIndex = 4;
            this.kingKongRadioButton.TabStop = true;
            this.kingKongRadioButton.Text = "King Kong";
            this.kingKongRadioButton.UseVisualStyleBackColor = true;
            // 
            // grapeApeRadioButton
            // 
            this.grapeApeRadioButton.AutoSize = true;
            this.grapeApeRadioButton.Location = new System.Drawing.Point(6, 85);
            this.grapeApeRadioButton.Name = "grapeApeRadioButton";
            this.grapeApeRadioButton.Size = new System.Drawing.Size(112, 24);
            this.grapeApeRadioButton.TabIndex = 3;
            this.grapeApeRadioButton.TabStop = true;
            this.grapeApeRadioButton.Text = "Grape Ape";
            this.grapeApeRadioButton.UseVisualStyleBackColor = true;
            // 
            // begginerRadioButton
            // 
            this.begginerRadioButton.AutoSize = true;
            this.begginerRadioButton.Location = new System.Drawing.Point(6, 55);
            this.begginerRadioButton.Name = "begginerRadioButton";
            this.begginerRadioButton.Size = new System.Drawing.Size(98, 24);
            this.begginerRadioButton.TabIndex = 2;
            this.begginerRadioButton.TabStop = true;
            this.begginerRadioButton.Text = "Beginner";
            this.begginerRadioButton.UseVisualStyleBackColor = true;
            // 
            // noviceRadioButton
            // 
            this.noviceRadioButton.AutoSize = true;
            this.noviceRadioButton.Location = new System.Drawing.Point(6, 25);
            this.noviceRadioButton.Name = "noviceRadioButton";
            this.noviceRadioButton.Size = new System.Drawing.Size(81, 24);
            this.noviceRadioButton.TabIndex = 1;
            this.noviceRadioButton.TabStop = true;
            this.noviceRadioButton.Text = "Novice";
            this.noviceRadioButton.UseVisualStyleBackColor = true;
            this.noviceRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // beginButton
            // 
            this.beginButton.Location = new System.Drawing.Point(20, 166);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(203, 55);
            this.beginButton.TabIndex = 1;
            this.beginButton.Text = "Begin";
            this.beginButton.UseVisualStyleBackColor = true;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // mainMenuButton
            // 
            this.mainMenuButton.Location = new System.Drawing.Point(20, 227);
            this.mainMenuButton.Name = "mainMenuButton";
            this.mainMenuButton.Size = new System.Drawing.Size(203, 55);
            this.mainMenuButton.TabIndex = 2;
            this.mainMenuButton.Text = "Main Menu";
            this.mainMenuButton.UseVisualStyleBackColor = true;
            this.mainMenuButton.Click += new System.EventHandler(this.mainMenuButton_Click);
            // 
            // vsCPU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 294);
            this.Controls.Add(this.mainMenuButton);
            this.Controls.Add(this.beginButton);
            this.Controls.Add(this.difficultyGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "vsCPU";
            this.Text = "Difficulty";
            this.difficultyGroupBox.ResumeLayout(false);
            this.difficultyGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox difficultyGroupBox;
        private System.Windows.Forms.RadioButton noviceRadioButton;
        private System.Windows.Forms.RadioButton kingKongRadioButton;
        private System.Windows.Forms.RadioButton grapeApeRadioButton;
        private System.Windows.Forms.RadioButton begginerRadioButton;
        private System.Windows.Forms.Button beginButton;
        private System.Windows.Forms.Button mainMenuButton;
    }
}