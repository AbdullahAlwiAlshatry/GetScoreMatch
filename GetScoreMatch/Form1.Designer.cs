namespace GetScoreMatch
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numericM = new System.Windows.Forms.NumericUpDown();
            this.numericD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 20F);
            this.label1.Location = new System.Drawing.Point(81, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Get scores of matches";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(165, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Score";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 340);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(420, 24);
            this.textBox1.TabIndex = 2;
            this.textBox1.Visible = false;
            // 
            // numericM
            // 
            this.numericM.Location = new System.Drawing.Point(180, 148);
            this.numericM.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericM.Name = "numericM";
            this.numericM.Size = new System.Drawing.Size(120, 24);
            this.numericM.TabIndex = 4;
            this.numericM.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericD
            // 
            this.numericD.Location = new System.Drawing.Point(180, 188);
            this.numericD.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericD.Name = "numericD";
            this.numericD.Size = new System.Drawing.Size(120, 24);
            this.numericD.TabIndex = 5;
            this.numericD.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(306, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(306, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Day";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(806, 18);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(574, 311);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 359);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericD);
            this.Controls.Add(this.numericM);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericM;
        private System.Windows.Forms.NumericUpDown numericD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

