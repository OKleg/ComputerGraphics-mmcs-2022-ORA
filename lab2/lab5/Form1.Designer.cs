
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
            this.buttonMidpoint.Location = new System.Drawing.Point(2, 233);
            this.buttonMidpoint.Name = "buttonMidpoint";
            this.buttonMidpoint.Size = new System.Drawing.Size(107, 23);
            this.buttonMidpoint.TabIndex = 5;
            this.buttonMidpoint.Text = "Midpoint";
            this.buttonMidpoint.UseVisualStyleBackColor = true;
            // 
            // buttonBezier
            // 
            this.buttonBezier.Location = new System.Drawing.Point(2, 262);
            this.buttonBezier.Name = "buttonBezier";
            this.buttonBezier.Size = new System.Drawing.Size(107, 23);
            this.buttonBezier.TabIndex = 6;
            this.buttonBezier.Text = "Безье";
            this.buttonBezier.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 528);
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
    }
}

