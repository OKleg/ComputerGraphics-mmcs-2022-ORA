
namespace lab3Affinis
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonUP = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonScaleUp = new System.Windows.Forms.Button();
            this.buttonRotate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonScaleDown = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButtonIntersect = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonShift = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.BtnSetCenter = new System.Windows.Forms.Button();
            this.RadioBtnAffine = new System.Windows.Forms.RadioButton();
            this.RadioBtnCenter = new System.Windows.Forms.RadioButton();
            this.SelectedPointLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.RadioPointPos = new System.Windows.Forms.RadioButton();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(123, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Задать примитив";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(18, 578);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(23, 31);
            this.buttonLeft.TabIndex = 2;
            this.buttonLeft.Text = "<";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(75, 578);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(23, 31);
            this.buttonRight.TabIndex = 3;
            this.buttonRight.Text = ">";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonUP
            // 
            this.buttonUP.Location = new System.Drawing.Point(47, 541);
            this.buttonUP.Name = "buttonUP";
            this.buttonUP.Size = new System.Drawing.Size(23, 31);
            this.buttonUP.TabIndex = 4;
            this.buttonUP.Text = "^";
            this.buttonUP.UseVisualStyleBackColor = true;
            this.buttonUP.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(47, 578);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(23, 31);
            this.buttonDown.TabIndex = 5;
            this.buttonDown.Text = "v";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonScaleUp
            // 
            this.buttonScaleUp.Location = new System.Drawing.Point(7, 479);
            this.buttonScaleUp.Name = "buttonScaleUp";
            this.buttonScaleUp.Size = new System.Drawing.Size(100, 25);
            this.buttonScaleUp.TabIndex = 6;
            this.buttonScaleUp.Text = "scale Up";
            this.buttonScaleUp.UseVisualStyleBackColor = true;
            this.buttonScaleUp.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonRotate
            // 
            this.buttonRotate.Location = new System.Drawing.Point(8, 313);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(100, 25);
            this.buttonRotate.TabIndex = 7;
            this.buttonRotate.Text = "rotate";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 262);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(36, 20);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(72, 262);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(36, 20);
            this.textBox2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "dx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "dy";
            // 
            // buttonScaleDown
            // 
            this.buttonScaleDown.Location = new System.Drawing.Point(8, 510);
            this.buttonScaleDown.Name = "buttonScaleDown";
            this.buttonScaleDown.Size = new System.Drawing.Size(100, 25);
            this.buttonScaleDown.TabIndex = 12;
            this.buttonScaleDown.Text = "scale Down";
            this.buttonScaleDown.UseVisualStyleBackColor = true;
            this.buttonScaleDown.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 25);
            this.button3.TabIndex = 14;
            this.button3.Text = "пересечение";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // radioButtonIntersect
            // 
            this.radioButtonIntersect.AutoSize = true;
            this.radioButtonIntersect.Location = new System.Drawing.Point(12, 18);
            this.radioButtonIntersect.Name = "radioButtonIntersect";
            this.radioButtonIntersect.Size = new System.Drawing.Size(14, 13);
            this.radioButtonIntersect.TabIndex = 15;
            this.radioButtonIntersect.TabStop = true;
            this.radioButtonIntersect.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 177);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 25);
            this.button4.TabIndex = 16;
            this.button4.Text = "clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonShift
            // 
            this.buttonShift.Location = new System.Drawing.Point(8, 288);
            this.buttonShift.Name = "buttonShift";
            this.buttonShift.Size = new System.Drawing.Size(100, 25);
            this.buttonShift.TabIndex = 17;
            this.buttonShift.Text = "Shift";
            this.buttonShift.UseVisualStyleBackColor = true;
            this.buttonShift.Click += new System.EventHandler(this.buttonShift_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 43);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 25);
            this.button5.TabIndex = 18;
            this.button5.Text = "Set Affine Point";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 15;
            this.trackBar1.Location = new System.Drawing.Point(8, 344);
            this.trackBar1.Maximum = 360;
            this.trackBar1.Minimum = -360;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(100, 45);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 19;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // BtnSetCenter
            // 
            this.BtnSetCenter.Location = new System.Drawing.Point(12, 74);
            this.BtnSetCenter.Name = "BtnSetCenter";
            this.BtnSetCenter.Size = new System.Drawing.Size(100, 25);
            this.BtnSetCenter.TabIndex = 20;
            this.BtnSetCenter.Text = "Set Centroid";
            this.BtnSetCenter.UseVisualStyleBackColor = true;
            this.BtnSetCenter.Click += new System.EventHandler(this.BtnSetCenter_Click);
            // 
            // RadioBtnAffine
            // 
            this.RadioBtnAffine.AutoSize = true;
            this.RadioBtnAffine.Location = new System.Drawing.Point(12, 49);
            this.RadioBtnAffine.Name = "RadioBtnAffine";
            this.RadioBtnAffine.Size = new System.Drawing.Size(14, 13);
            this.RadioBtnAffine.TabIndex = 21;
            this.RadioBtnAffine.TabStop = true;
            this.RadioBtnAffine.UseVisualStyleBackColor = true;
            this.RadioBtnAffine.Visible = false;
            // 
            // RadioBtnCenter
            // 
            this.RadioBtnCenter.AutoSize = true;
            this.RadioBtnCenter.Location = new System.Drawing.Point(12, 80);
            this.RadioBtnCenter.Name = "RadioBtnCenter";
            this.RadioBtnCenter.Size = new System.Drawing.Size(14, 13);
            this.RadioBtnCenter.TabIndex = 22;
            this.RadioBtnCenter.TabStop = true;
            this.RadioBtnCenter.UseVisualStyleBackColor = true;
            this.RadioBtnCenter.Visible = false;
            // 
            // SelectedPointLabel
            // 
            this.SelectedPointLabel.AutoSize = true;
            this.SelectedPointLabel.Location = new System.Drawing.Point(14, 102);
            this.SelectedPointLabel.Name = "SelectedPointLabel";
            this.SelectedPointLabel.Size = new System.Drawing.Size(76, 13);
            this.SelectedPointLabel.TabIndex = 23;
            this.SelectedPointLabel.Text = "Selected Point";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "PointFromEdge";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // RadioPointPos
            // 
            this.RadioPointPos.AutoSize = true;
            this.RadioPointPos.Location = new System.Drawing.Point(7, 400);
            this.RadioPointPos.Name = "RadioPointPos";
            this.RadioPointPos.Size = new System.Drawing.Size(14, 13);
            this.RadioPointPos.TabIndex = 25;
            this.RadioPointPos.TabStop = true;
            this.RadioPointPos.UseVisualStyleBackColor = true;
            this.RadioPointPos.Visible = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(7, 450);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(101, 23);
            this.button6.TabIndex = 26;
            this.button6.Text = "Union";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 620);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.RadioPointPos);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SelectedPointLabel);
            this.Controls.Add(this.RadioBtnCenter);
            this.Controls.Add(this.RadioBtnAffine);
            this.Controls.Add(this.BtnSetCenter);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.buttonShift);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.radioButtonIntersect);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonScaleDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonRotate);
            this.Controls.Add(this.buttonScaleUp);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUP);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Afin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonUP;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonScaleUp;
        private System.Windows.Forms.Button buttonRotate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonScaleDown;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioButtonIntersect;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonShift;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button BtnSetCenter;
        private System.Windows.Forms.RadioButton RadioBtnAffine;
        private System.Windows.Forms.RadioButton RadioBtnCenter;
        private System.Windows.Forms.Label SelectedPointLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton RadioPointPos;
        private System.Windows.Forms.Button button6;
    }
}

