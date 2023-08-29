namespace AmericanCheckers
{
    partial class GameSetting
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.RadioButtonSize6 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSize8 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSize10 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Player1TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Player2CheckBox = new System.Windows.Forms.CheckBox();
            this.ButtonDone = new System.Windows.Forms.Button();
            this.Player2TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Board Size:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // RadioButtonSize6
            // 
            this.RadioButtonSize6.AutoSize = true;
            this.RadioButtonSize6.Location = new System.Drawing.Point(32, 43);
            this.RadioButtonSize6.Name = "RadioButtonSize6";
            this.RadioButtonSize6.Size = new System.Drawing.Size(75, 29);
            this.RadioButtonSize6.TabIndex = 1;
            this.RadioButtonSize6.TabStop = true;
            this.RadioButtonSize6.Text = "6 x 6";
            this.RadioButtonSize6.UseVisualStyleBackColor = true;
            this.RadioButtonSize6.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // RadioButtonSize8
            // 
            this.RadioButtonSize8.AutoSize = true;
            this.RadioButtonSize8.Location = new System.Drawing.Point(117, 43);
            this.RadioButtonSize8.Name = "RadioButtonSize8";
            this.RadioButtonSize8.Size = new System.Drawing.Size(75, 29);
            this.RadioButtonSize8.TabIndex = 2;
            this.RadioButtonSize8.TabStop = true;
            this.RadioButtonSize8.Text = "8 x 8";
            this.RadioButtonSize8.UseVisualStyleBackColor = true;
            this.RadioButtonSize8.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // RadioButtonSize10
            // 
            this.RadioButtonSize10.AutoSize = true;
            this.RadioButtonSize10.Location = new System.Drawing.Point(202, 43);
            this.RadioButtonSize10.Name = "RadioButtonSize10";
            this.RadioButtonSize10.Size = new System.Drawing.Size(95, 29);
            this.RadioButtonSize10.TabIndex = 3;
            this.RadioButtonSize10.TabStop = true;
            this.RadioButtonSize10.Text = "10 x 10";
            this.RadioButtonSize10.UseVisualStyleBackColor = true;
            this.RadioButtonSize10.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Players:";
            // 
            // Player1TextBox
            // 
            this.Player1TextBox.Location = new System.Drawing.Point(147, 126);
            this.Player1TextBox.Name = "Player1TextBox";
            this.Player1TextBox.Size = new System.Drawing.Size(150, 31);
            this.Player1TextBox.TabIndex = 6;
            this.Player1TextBox.TextChanged += new System.EventHandler(this.Player1TextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Player 1 ";
            // 
            // Player2CheckBox
            // 
            this.Player2CheckBox.AutoSize = true;
            this.Player2CheckBox.Location = new System.Drawing.Point(32, 179);
            this.Player2CheckBox.Name = "Player2CheckBox";
            this.Player2CheckBox.Size = new System.Drawing.Size(104, 29);
            this.Player2CheckBox.TabIndex = 7;
            this.Player2CheckBox.Text = "Player 2:";
            this.Player2CheckBox.UseVisualStyleBackColor = true;
            this.Player2CheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ButtonDone
            // 
            this.ButtonDone.Location = new System.Drawing.Point(185, 231);
            this.ButtonDone.Name = "ButtonDone";
            this.ButtonDone.Size = new System.Drawing.Size(112, 34);
            this.ButtonDone.TabIndex = 9;
            this.ButtonDone.Text = "Done";
            this.ButtonDone.UseVisualStyleBackColor = true;
            this.ButtonDone.Click += new System.EventHandler(this.ButtonDone_Click);
            // 
            // Player2TextBox
            // 
            this.Player2TextBox.Enabled = false;
            this.Player2TextBox.Location = new System.Drawing.Point(147, 177);
            this.Player2TextBox.Name = "Player2TextBox";
            this.Player2TextBox.Size = new System.Drawing.Size(150, 31);
            this.Player2TextBox.TabIndex = 8;
            this.Player2TextBox.Text = "[Computer]";
            this.Player2TextBox.TextChanged += new System.EventHandler(this.Player2TextBox_TextChanged);
            // 
            // GameSetting
            // 
            this.AcceptButton = this.ButtonDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(326, 277);
            this.Controls.Add(this.Player2TextBox);
            this.Controls.Add(this.ButtonDone);
            this.Controls.Add(this.Player2CheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Player1TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RadioButtonSize10);
            this.Controls.Add(this.RadioButtonSize8);
            this.Controls.Add(this.RadioButtonSize6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private RadioButton RadioButtonSize6;
        private RadioButton RadioButtonSize8;
        private RadioButton RadioButtonSize10;
        private Label label2;
        private TextBox Player1TextBox;
        private Label label3;
        private CheckBox Player2CheckBox;
        private Button ButtonDone;
        private TextBox Player2TextBox;
    }
}