namespace winform_lab4
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.playertext = new System.Windows.Forms.RichTextBox();
            this.player1 = new System.Windows.Forms.RichTextBox();
            this.player2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(14, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 651);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // playertext
            // 
            this.playertext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playertext.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.playertext.Location = new System.Drawing.Point(199, 690);
            this.playertext.Name = "playertext";
            this.playertext.Size = new System.Drawing.Size(174, 58);
            this.playertext.TabIndex = 1;
            this.playertext.Text = "";
            // 
            // player1
            // 
            this.player1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.player1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.player1.Location = new System.Drawing.Point(14, 690);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(141, 58);
            this.player1.TabIndex = 2;
            this.player1.Text = "";
            // 
            // player2
            // 
            this.player2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.player2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.player2.Location = new System.Drawing.Point(412, 690);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(141, 58);
            this.player2.TabIndex = 3;
            this.player2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 779);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.playertext);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private RichTextBox playertext;
        private RichTextBox player1;
        private RichTextBox player2;
    }
}