
namespace CG_lab2
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pen = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lab2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.buttonClean = new System.Windows.Forms.Button();
            this.radioButPen = new System.Windows.Forms.RadioButton();
            this.radioButBuc = new System.Windows.Forms.RadioButton();
            this.radioButShtamp = new System.Windows.Forms.RadioButton();
            this.radioButMagic = new System.Windows.Forms.RadioButton();
            this.radioButBrez = new System.Windows.Forms.RadioButton();
            this.radioButVu = new System.Windows.Forms.RadioButton();
            this.radioButTriangle = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(62, 27);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(600, 600);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pen
            // 
            this.pen.Image = ((System.Drawing.Image)(resources.GetObject("pen.Image")));
            this.pen.Location = new System.Drawing.Point(6, 27);
            this.pen.Name = "pen";
            this.pen.Size = new System.Drawing.Size(50, 50);
            this.pen.TabIndex = 2;
            this.pen.UseVisualStyleBackColor = true;
            this.pen.Click += new System.EventHandler(this.pen_Click);
            this.pen.Enter += new System.EventHandler(this.pen_Enter);
            this.pen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pen_MouseDown);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(6, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lab2ToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(669, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lab2ToolStripMenuItem
            // 
            this.lab2ToolStripMenuItem.Name = "lab2ToolStripMenuItem";
            this.lab2ToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.lab2ToolStripMenuItem.Text = "<<";
            this.lab2ToolStripMenuItem.Click += new System.EventHandler(this.lab2ToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(6, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(6, 195);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 50);
            this.button4.TabIndex = 6;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.AccessibleDescription = "алгоритмом Брезенхема";
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(6, 251);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 50);
            this.button5.TabIndex = 7;
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(6, 359);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 50);
            this.button6.TabIndex = 8;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.AccessibleDescription = "алгоритмом ВУ";
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(6, 303);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 50);
            this.button7.TabIndex = 9;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // buttonColor
            // 
            this.buttonColor.BackColor = System.Drawing.Color.Black;
            this.buttonColor.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonColor.Location = new System.Drawing.Point(6, 415);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(50, 50);
            this.buttonColor.TabIndex = 10;
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonClean
            // 
            this.buttonClean.Location = new System.Drawing.Point(6, 471);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(50, 45);
            this.buttonClean.TabIndex = 11;
            this.buttonClean.Text = "Clean";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.Clean_Click);
            // 
            // radioButPen
            // 
            this.radioButPen.AutoSize = true;
            this.radioButPen.Location = new System.Drawing.Point(42, 27);
            this.radioButPen.Name = "radioButPen";
            this.radioButPen.Size = new System.Drawing.Size(14, 13);
            this.radioButPen.TabIndex = 12;
            this.radioButPen.TabStop = true;
            this.radioButPen.UseVisualStyleBackColor = true;
            this.radioButPen.Visible = false;
            // 
            // radioButBuc
            // 
            this.radioButBuc.AutoSize = true;
            this.radioButBuc.Location = new System.Drawing.Point(42, 83);
            this.radioButBuc.Name = "radioButBuc";
            this.radioButBuc.Size = new System.Drawing.Size(14, 13);
            this.radioButBuc.TabIndex = 13;
            this.radioButBuc.TabStop = true;
            this.radioButBuc.UseVisualStyleBackColor = true;
            this.radioButBuc.Visible = false;
            // 
            // radioButShtamp
            // 
            this.radioButShtamp.AutoSize = true;
            this.radioButShtamp.Location = new System.Drawing.Point(42, 139);
            this.radioButShtamp.Name = "radioButShtamp";
            this.radioButShtamp.Size = new System.Drawing.Size(14, 13);
            this.radioButShtamp.TabIndex = 14;
            this.radioButShtamp.TabStop = true;
            this.radioButShtamp.UseVisualStyleBackColor = true;
            this.radioButShtamp.Visible = false;
            // 
            // radioButMagic
            // 
            this.radioButMagic.AutoSize = true;
            this.radioButMagic.Location = new System.Drawing.Point(42, 195);
            this.radioButMagic.Name = "radioButMagic";
            this.radioButMagic.Size = new System.Drawing.Size(14, 13);
            this.radioButMagic.TabIndex = 15;
            this.radioButMagic.TabStop = true;
            this.radioButMagic.UseVisualStyleBackColor = true;
            this.radioButMagic.Visible = false;
            // 
            // radioButBrez
            // 
            this.radioButBrez.AutoSize = true;
            this.radioButBrez.Location = new System.Drawing.Point(42, 251);
            this.radioButBrez.Name = "radioButBrez";
            this.radioButBrez.Size = new System.Drawing.Size(14, 13);
            this.radioButBrez.TabIndex = 16;
            this.radioButBrez.TabStop = true;
            this.radioButBrez.UseVisualStyleBackColor = true;
            this.radioButBrez.Visible = false;
            // 
            // radioButVu
            // 
            this.radioButVu.AutoSize = true;
            this.radioButVu.Location = new System.Drawing.Point(42, 303);
            this.radioButVu.Name = "radioButVu";
            this.radioButVu.Size = new System.Drawing.Size(14, 13);
            this.radioButVu.TabIndex = 17;
            this.radioButVu.TabStop = true;
            this.radioButVu.UseVisualStyleBackColor = true;
            this.radioButVu.Visible = false;
            // 
            // radioButTriangle
            // 
            this.radioButTriangle.AutoSize = true;
            this.radioButTriangle.Location = new System.Drawing.Point(42, 359);
            this.radioButTriangle.Name = "radioButTriangle";
            this.radioButTriangle.Size = new System.Drawing.Size(14, 13);
            this.radioButTriangle.TabIndex = 18;
            this.radioButTriangle.TabStop = true;
            this.radioButTriangle.UseVisualStyleBackColor = true;
            this.radioButTriangle.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 631);
            this.Controls.Add(this.radioButTriangle);
            this.Controls.Add(this.radioButVu);
            this.Controls.Add(this.radioButBrez);
            this.Controls.Add(this.radioButMagic);
            this.Controls.Add(this.radioButShtamp);
            this.Controls.Add(this.radioButBuc);
            this.Controls.Add(this.radioButPen);
            this.Controls.Add(this.buttonClean);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pen);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(685, 670);
            this.Name = "Form2";
            this.Text = "Lab3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button pen;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lab2ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.RadioButton radioButPen;
        private System.Windows.Forms.RadioButton radioButBuc;
        private System.Windows.Forms.RadioButton radioButShtamp;
        private System.Windows.Forms.RadioButton radioButMagic;
        private System.Windows.Forms.RadioButton radioButBrez;
        private System.Windows.Forms.RadioButton radioButVu;
        private System.Windows.Forms.RadioButton radioButTriangle;
    }
}