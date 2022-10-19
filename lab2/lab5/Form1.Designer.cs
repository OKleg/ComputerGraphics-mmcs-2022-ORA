
namespace lab5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonL = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonTree = new System.Windows.Forms.Button();
            this.buttonMidpoint = new System.Windows.Forms.Button();
            this.buttonBezier = new System.Windows.Forms.Button();
            this.LeftHeight = new System.Windows.Forms.TextBox();
            this.RightHeight = new System.Windows.Forms.TextBox();
            this.Roughness = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LandscapeBox = new System.Windows.Forms.CheckBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.radioBezier = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonL
            // 
            this.buttonL.Location = new System.Drawing.Point(2, 175);
            this.buttonL.Name = "buttonL";
            this.buttonL.Size = new System.Drawing.Size(107, 23);
            this.buttonL.TabIndex = 1;
            this.buttonL.Text = "L-system";
            this.buttonL.UseVisualStyleBackColor = true;
            this.buttonL.Click += new System.EventHandler(this.buttonL_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(115, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(842, 511);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(107, 157);
            this.textBox1.TabIndex = 3;
            // 
            // buttonTree
            // 
            this.buttonTree.Location = new System.Drawing.Point(2, 204);
            this.buttonTree.Name = "buttonTree";
            this.buttonTree.Size = new System.Drawing.Size(107, 23);
            this.buttonTree.TabIndex = 4;
            this.buttonTree.Text = "Tree";
            this.buttonTree.UseVisualStyleBackColor = true;
            // 
            // buttonMidpoint
            // 
            this.buttonMidpoint.Location = new System.Drawing.Point(1, 323);
            this.buttonMidpoint.Name = "buttonMidpoint";
            this.buttonMidpoint.Size = new System.Drawing.Size(107, 23);
            this.buttonMidpoint.TabIndex = 5;
            this.buttonMidpoint.Text = "Midpoint";
            this.buttonMidpoint.UseVisualStyleBackColor = true;
            this.buttonMidpoint.Click += new System.EventHandler(this.buttonMidpoint_Click);
            // 
            // buttonBezier
            // 
            this.buttonBezier.Location = new System.Drawing.Point(1, 389);
            this.buttonBezier.Name = "buttonBezier";
            this.buttonBezier.Size = new System.Drawing.Size(107, 23);
            this.buttonBezier.TabIndex = 6;
            this.buttonBezier.Text = "Безье";
            this.buttonBezier.UseVisualStyleBackColor = true;
            this.buttonBezier.Click += new System.EventHandler(this.buttonBezier_Click);
            // 
            // LeftHeight
            // 
            this.LeftHeight.Location = new System.Drawing.Point(2, 275);
            this.LeftHeight.Name = "LeftHeight";
            this.LeftHeight.Size = new System.Drawing.Size(50, 20);
            this.LeftHeight.TabIndex = 7;
            this.LeftHeight.TextChanged += new System.EventHandler(this.LeftHight_TextChanged);
            // 
            // RightHeight
            // 
            this.RightHeight.Location = new System.Drawing.Point(58, 275);
            this.RightHeight.Name = "RightHeight";
            this.RightHeight.Size = new System.Drawing.Size(50, 20);
            this.RightHeight.TabIndex = 8;
            // 
            // Roughness
            // 
            this.Roughness.Location = new System.Drawing.Point(58, 297);
            this.Roughness.Name = "Roughness";
            this.Roughness.Size = new System.Drawing.Size(50, 20);
            this.Roughness.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "roughness";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Left";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Right";
            // 
            // LandscapeBox
            // 
            this.LandscapeBox.AutoSize = true;
            this.LandscapeBox.Location = new System.Drawing.Point(2, 352);
            this.LandscapeBox.Name = "LandscapeBox";
            this.LandscapeBox.Size = new System.Drawing.Size(75, 17);
            this.LandscapeBox.TabIndex = 13;
            this.LandscapeBox.Text = "landscape";
            this.LandscapeBox.UseVisualStyleBackColor = true;
            this.LandscapeBox.CheckedChanged += new System.EventHandler(this.LandscapeBox_CheckedChanged);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(2, 493);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(107, 23);
            this.ClearBtn.TabIndex = 14;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // radioBezier
            // 
            this.radioBezier.AutoSize = true;
            this.radioBezier.Location = new System.Drawing.Point(0, 389);
            this.radioBezier.Name = "radioBezier";
            this.radioBezier.Size = new System.Drawing.Size(14, 13);
            this.radioBezier.TabIndex = 15;
            this.radioBezier.TabStop = true;
            this.radioBezier.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 528);
            this.Controls.Add(this.radioBezier);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.LandscapeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Roughness);
            this.Controls.Add(this.RightHeight);
            this.Controls.Add(this.LeftHeight);
            this.Controls.Add(this.buttonBezier);
            this.Controls.Add(this.buttonMidpoint);
            this.Controls.Add(this.buttonTree);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonL);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonTree;
        private System.Windows.Forms.Button buttonMidpoint;
        private System.Windows.Forms.Button buttonBezier;
        private System.Windows.Forms.TextBox LeftHeight;
        private System.Windows.Forms.TextBox RightHeight;
        private System.Windows.Forms.TextBox Roughness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox LandscapeBox;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.RadioButton radioBezier;
    }
}

