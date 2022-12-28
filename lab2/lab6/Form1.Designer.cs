
namespace lab6
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBarOX = new System.Windows.Forms.TrackBar();
            this.labelOY = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.A = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonX2 = new System.Windows.Forms.Button();
            this.buttonDiv2 = new System.Windows.Forms.Button();
            this.buttonMirror = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.hx = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelOX = new System.Windows.Forms.Label();
            this.trackBarOY = new System.Windows.Forms.TrackBar();
            this.hy = new System.Windows.Forms.TextBox();
            this.hz = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.B = new System.Windows.Forms.TextBox();
            this.C = new System.Windows.Forms.TextBox();
            this.trackBarOZ = new System.Windows.Forms.TrackBar();
            this.labelOZ = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tBoxn = new System.Windows.Forms.TextBox();
            this.tBoxm = new System.Windows.Forms.TextBox();
            this.tBoxl = new System.Windows.Forms.TextBox();
            this.trackBarL = new System.Windows.Forms.TrackBar();
            this.labelL = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.RotateAxisSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SplitCountBox = new System.Windows.Forms.TextBox();
            this.AddPointBtn = new System.Windows.Forms.Button();
            this.InputPointX = new System.Windows.Forms.TextBox();
            this.InputPointY = new System.Windows.Forms.TextBox();
            this.InputPointZ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.DrawRotateModelBtn = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.LeftGo = new System.Windows.Forms.Button();
            this.RightGo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioEmpty = new System.Windows.Forms.RadioButton();
            this.radioGuro = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // trackBarOX
            // 
            this.trackBarOX.Location = new System.Drawing.Point(13, 520);
            this.trackBarOX.Maximum = 180;
            this.trackBarOX.Minimum = -180;
            this.trackBarOX.Name = "trackBarOX";
            this.trackBarOX.Size = new System.Drawing.Size(500, 45);
            this.trackBarOX.TabIndex = 1;
            this.trackBarOX.Scroll += new System.EventHandler(this.trackBarOY_Scroll);
            this.trackBarOX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarOY_MouseUp);
            // 
            // labelOY
            // 
            this.labelOY.AutoSize = true;
            this.labelOY.Location = new System.Drawing.Point(257, 550);
            this.labelOY.Name = "labelOY";
            this.labelOY.Size = new System.Drawing.Size(13, 13);
            this.labelOY.TabIndex = 2;
            this.labelOY.Text = "0";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Тетраэдр",
            "Гексаэдр",
            "Октаэдр",
            "Икосаэдр*",
            "Додекаэдр*"});
            this.comboBox1.Location = new System.Drawing.Point(697, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "Тетраэдр";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // A
            // 
            this.A.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.A.Enabled = false;
            this.A.Location = new System.Drawing.Point(697, 149);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(40, 20);
            this.A.TabIndex = 5;
            this.A.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(679, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 65);
            this.label2.TabIndex = 7;
            this.label2.Text = "x\r\n\r\ny\r\n\r\nz";
            // 
            // buttonX2
            // 
            this.buttonX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX2.Location = new System.Drawing.Point(787, 147);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(43, 23);
            this.buttonX2.TabIndex = 10;
            this.buttonX2.Text = "x2";
            this.buttonX2.UseVisualStyleBackColor = true;
            this.buttonX2.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDiv2
            // 
            this.buttonDiv2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDiv2.Location = new System.Drawing.Point(824, 147);
            this.buttonDiv2.Name = "buttonDiv2";
            this.buttonDiv2.Size = new System.Drawing.Size(43, 23);
            this.buttonDiv2.TabIndex = 11;
            this.buttonDiv2.Text = "x0.5";
            this.buttonDiv2.UseVisualStyleBackColor = true;
            this.buttonDiv2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonMirror
            // 
            this.buttonMirror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMirror.Location = new System.Drawing.Point(788, 117);
            this.buttonMirror.Name = "buttonMirror";
            this.buttonMirror.Size = new System.Drawing.Size(79, 21);
            this.buttonMirror.TabIndex = 13;
            this.buttonMirror.Text = "отражение";
            this.buttonMirror.UseVisualStyleBackColor = true;
            this.buttonMirror.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "перспективная",
            "аксонометрическая"});
            this.comboBox4.Location = new System.Drawing.Point(759, 560);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(108, 21);
            this.comboBox4.TabIndex = 14;
            this.comboBox4.Text = "перспективная";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // hx
            // 
            this.hx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hx.Enabled = false;
            this.hx.Location = new System.Drawing.Point(697, 39);
            this.hx.Name = "hx";
            this.hx.Size = new System.Drawing.Size(84, 20);
            this.hx.TabIndex = 15;
            this.hx.Text = "0";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(787, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 72);
            this.button4.TabIndex = 16;
            this.button4.Text = "смещение";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(673, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 65);
            this.label3.TabIndex = 17;
            this.label3.Text = "hx\r\n\r\nhy\r\n\r\nhz";
            // 
            // labelOX
            // 
            this.labelOX.AutoSize = true;
            this.labelOX.Location = new System.Drawing.Point(539, 258);
            this.labelOX.Name = "labelOX";
            this.labelOX.Size = new System.Drawing.Size(16, 13);
            this.labelOX.TabIndex = 18;
            this.labelOX.Text = "0 ";
            // 
            // trackBarOY
            // 
            this.trackBarOY.Location = new System.Drawing.Point(517, 13);
            this.trackBarOY.Maximum = 180;
            this.trackBarOY.Minimum = -180;
            this.trackBarOY.Name = "trackBarOY";
            this.trackBarOY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarOY.Size = new System.Drawing.Size(45, 500);
            this.trackBarOY.TabIndex = 20;
            this.trackBarOY.Scroll += new System.EventHandler(this.trackBarOX_Scroll);
            this.trackBarOY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarOX_MouseUp);
            // 
            // hy
            // 
            this.hy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hy.Enabled = false;
            this.hy.Location = new System.Drawing.Point(697, 65);
            this.hy.Name = "hy";
            this.hy.Size = new System.Drawing.Size(84, 20);
            this.hy.TabIndex = 21;
            this.hy.Text = "0";
            // 
            // hz
            // 
            this.hz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hz.Enabled = false;
            this.hz.Location = new System.Drawing.Point(697, 91);
            this.hz.Name = "hz";
            this.hz.Size = new System.Drawing.Size(84, 20);
            this.hz.TabIndex = 22;
            this.hz.Text = "0";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button5.Location = new System.Drawing.Point(824, 175);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(43, 46);
            this.button5.TabIndex = 23;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox5
            // 
            this.comboBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "Oxy",
            "Oyz",
            "Oxz"});
            this.comboBox5.Location = new System.Drawing.Point(697, 118);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(84, 21);
            this.comboBox5.TabIndex = 24;
            this.comboBox5.Text = "Oxy";
            // 
            // B
            // 
            this.B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B.Enabled = false;
            this.B.Location = new System.Drawing.Point(697, 175);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(40, 20);
            this.B.TabIndex = 25;
            this.B.Text = "0";
            // 
            // C
            // 
            this.C.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C.Enabled = false;
            this.C.Location = new System.Drawing.Point(697, 201);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(40, 20);
            this.C.TabIndex = 26;
            this.C.Text = "0";
            // 
            // trackBarOZ
            // 
            this.trackBarOZ.Location = new System.Drawing.Point(563, 13);
            this.trackBarOZ.Maximum = 180;
            this.trackBarOZ.Minimum = -180;
            this.trackBarOZ.Name = "trackBarOZ";
            this.trackBarOZ.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarOZ.Size = new System.Drawing.Size(45, 500);
            this.trackBarOZ.TabIndex = 27;
            this.trackBarOZ.Scroll += new System.EventHandler(this.trackBarOZ_Scroll);
            this.trackBarOZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarOZ_MouseUp);
            // 
            // labelOZ
            // 
            this.labelOZ.AutoSize = true;
            this.labelOZ.Location = new System.Drawing.Point(585, 258);
            this.labelOZ.Name = "labelOZ";
            this.labelOZ.Size = new System.Drawing.Size(16, 13);
            this.labelOZ.TabIndex = 28;
            this.labelOZ.Text = "0 ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 550);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Oy ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(585, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Oz";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(535, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Ox";
            // 
            // tBoxn
            // 
            this.tBoxn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxn.Enabled = false;
            this.tBoxn.Location = new System.Drawing.Point(741, 201);
            this.tBoxn.Name = "tBoxn";
            this.tBoxn.Size = new System.Drawing.Size(40, 20);
            this.tBoxn.TabIndex = 34;
            this.tBoxn.Text = "0";
            // 
            // tBoxm
            // 
            this.tBoxm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxm.Enabled = false;
            this.tBoxm.Location = new System.Drawing.Point(741, 175);
            this.tBoxm.Name = "tBoxm";
            this.tBoxm.Size = new System.Drawing.Size(40, 20);
            this.tBoxm.TabIndex = 33;
            this.tBoxm.Text = "0";
            // 
            // tBoxl
            // 
            this.tBoxl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxl.Enabled = false;
            this.tBoxl.Location = new System.Drawing.Point(741, 149);
            this.tBoxl.Name = "tBoxl";
            this.tBoxl.Size = new System.Drawing.Size(40, 20);
            this.tBoxl.TabIndex = 32;
            this.tBoxl.Text = "1";
            // 
            // trackBarL
            // 
            this.trackBarL.Location = new System.Drawing.Point(608, 13);
            this.trackBarL.Maximum = 180;
            this.trackBarL.Minimum = -180;
            this.trackBarL.Name = "trackBarL";
            this.trackBarL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarL.Size = new System.Drawing.Size(45, 500);
            this.trackBarL.TabIndex = 36;
            this.trackBarL.Scroll += new System.EventHandler(this.trackBarL_Scroll);
            this.trackBarL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarL_MouseUp);
            // 
            // labelL
            // 
            this.labelL.AutoSize = true;
            this.labelL.Location = new System.Drawing.Point(630, 258);
            this.labelL.Name = "labelL";
            this.labelL.Size = new System.Drawing.Size(16, 13);
            this.labelL.TabIndex = 37;
            this.labelL.Text = "0 ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(614, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "L";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn.Location = new System.Drawing.Point(697, 232);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(79, 39);
            this.SaveBtn.TabIndex = 39;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // LoadBtn
            // 
            this.LoadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadBtn.Location = new System.Drawing.Point(787, 232);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(79, 39);
            this.LoadBtn.TabIndex = 40;
            this.LoadBtn.Text = "Загрузить";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // RotateAxisSelector
            // 
            this.RotateAxisSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RotateAxisSelector.FormattingEnabled = true;
            this.RotateAxisSelector.Items.AddRange(new object[] {
            "Ox",
            "Oy",
            "Oz"});
            this.RotateAxisSelector.Location = new System.Drawing.Point(697, 298);
            this.RotateAxisSelector.Name = "RotateAxisSelector";
            this.RotateAxisSelector.Size = new System.Drawing.Size(80, 21);
            this.RotateAxisSelector.TabIndex = 41;
            this.RotateAxisSelector.Text = "Oz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(694, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Ось вращения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(800, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Разбиения";
            // 
            // SplitCountBox
            // 
            this.SplitCountBox.Location = new System.Drawing.Point(783, 298);
            this.SplitCountBox.Name = "SplitCountBox";
            this.SplitCountBox.Size = new System.Drawing.Size(83, 20);
            this.SplitCountBox.TabIndex = 44;
            this.SplitCountBox.Text = "8";
            // 
            // AddPointBtn
            // 
            this.AddPointBtn.Location = new System.Drawing.Point(697, 364);
            this.AddPointBtn.Name = "AddPointBtn";
            this.AddPointBtn.Size = new System.Drawing.Size(170, 25);
            this.AddPointBtn.TabIndex = 45;
            this.AddPointBtn.Text = "Добавить точку";
            this.AddPointBtn.UseVisualStyleBackColor = true;
            this.AddPointBtn.Click += new System.EventHandler(this.AddPointBtn_Click);
            // 
            // InputPointX
            // 
            this.InputPointX.Location = new System.Drawing.Point(697, 339);
            this.InputPointX.Name = "InputPointX";
            this.InputPointX.Size = new System.Drawing.Size(56, 20);
            this.InputPointX.TabIndex = 46;
            this.InputPointX.Text = "0";
            // 
            // InputPointY
            // 
            this.InputPointY.Location = new System.Drawing.Point(759, 338);
            this.InputPointY.Name = "InputPointY";
            this.InputPointY.Size = new System.Drawing.Size(47, 20);
            this.InputPointY.TabIndex = 47;
            this.InputPointY.Text = "0";
            // 
            // InputPointZ
            // 
            this.InputPointZ.Location = new System.Drawing.Point(812, 338);
            this.InputPointZ.Name = "InputPointZ";
            this.InputPointZ.Size = new System.Drawing.Size(54, 20);
            this.InputPointZ.TabIndex = 48;
            this.InputPointZ.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(719, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(767, 322);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Y";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(832, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Z";
            // 
            // DrawRotateModelBtn
            // 
            this.DrawRotateModelBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DrawRotateModelBtn.Location = new System.Drawing.Point(697, 396);
            this.DrawRotateModelBtn.Name = "DrawRotateModelBtn";
            this.DrawRotateModelBtn.Size = new System.Drawing.Size(170, 23);
            this.DrawRotateModelBtn.TabIndex = 52;
            this.DrawRotateModelBtn.Text = "Нарисовать фигуру вращения";
            this.DrawRotateModelBtn.UseVisualStyleBackColor = true;
            this.DrawRotateModelBtn.Click += new System.EventHandler(this.DrawRotateModelBtn_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearBtn.Location = new System.Drawing.Point(759, 520);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(108, 34);
            this.ClearBtn.TabIndex = 53;
            this.ClearBtn.Text = "Очистить";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // LeftGo
            // 
            this.LeftGo.Location = new System.Drawing.Point(649, 464);
            this.LeftGo.Name = "LeftGo";
            this.LeftGo.Size = new System.Drawing.Size(42, 23);
            this.LeftGo.TabIndex = 54;
            this.LeftGo.Text = "<";
            this.LeftGo.UseVisualStyleBackColor = true;
            this.LeftGo.Click += new System.EventHandler(this.LeftGo_Click);
            // 
            // RightGo
            // 
            this.RightGo.Location = new System.Drawing.Point(711, 464);
            this.RightGo.Name = "RightGo";
            this.RightGo.Size = new System.Drawing.Size(42, 23);
            this.RightGo.TabIndex = 55;
            this.RightGo.Text = ">";
            this.RightGo.UseVisualStyleBackColor = true;
            this.RightGo.Click += new System.EventHandler(this.RightGo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioGuro);
            this.groupBox1.Controls.Add(this.radioEmpty);
            this.groupBox1.Location = new System.Drawing.Point(759, 425);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(103, 88);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            // 
            // radioEmpty
            // 
            this.radioEmpty.AutoSize = true;
            this.radioEmpty.Checked = true;
            this.radioEmpty.Location = new System.Drawing.Point(6, 19);
            this.radioEmpty.Name = "radioEmpty";
            this.radioEmpty.Size = new System.Drawing.Size(54, 17);
            this.radioEmpty.TabIndex = 0;
            this.radioEmpty.TabStop = true;
            this.radioEmpty.Text = "Empty";
            this.radioEmpty.UseVisualStyleBackColor = true;
            // 
            // radioGuro
            // 
            this.radioGuro.AutoSize = true;
            this.radioGuro.Location = new System.Drawing.Point(3, 39);
            this.radioGuro.Name = "radioGuro";
            this.radioGuro.Size = new System.Drawing.Size(48, 17);
            this.radioGuro.TabIndex = 1;
            this.radioGuro.TabStop = true;
            this.radioGuro.Text = "Guro";
            this.radioGuro.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 593);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RightGo);
            this.Controls.Add(this.LeftGo);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.DrawRotateModelBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.InputPointZ);
            this.Controls.Add(this.InputPointY);
            this.Controls.Add(this.InputPointX);
            this.Controls.Add(this.AddPointBtn);
            this.Controls.Add(this.SplitCountBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RotateAxisSelector);
            this.Controls.Add(this.LoadBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelL);
            this.Controls.Add(this.trackBarL);
            this.Controls.Add(this.tBoxn);
            this.Controls.Add(this.tBoxm);
            this.Controls.Add(this.tBoxl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelOZ);
            this.Controls.Add(this.trackBarOZ);
            this.Controls.Add(this.C);
            this.Controls.Add(this.B);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.labelOX);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.hz);
            this.Controls.Add(this.hy);
            this.Controls.Add(this.trackBarOY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.hx);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.buttonMirror);
            this.Controls.Add(this.buttonDiv2);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.A);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelOY);
            this.Controls.Add(this.trackBarOX);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "3D";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBarOX;
        private System.Windows.Forms.Label labelOY;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox A;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonX2;
        private System.Windows.Forms.Button buttonDiv2;
        private System.Windows.Forms.Button buttonMirror;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.TextBox hx;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelOX;
        private System.Windows.Forms.TrackBar trackBarOY;
        private System.Windows.Forms.TextBox hy;
        private System.Windows.Forms.TextBox hz;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.TextBox B;
        private System.Windows.Forms.TextBox C;
        private System.Windows.Forms.TrackBar trackBarOZ;
        private System.Windows.Forms.Label labelOZ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBoxn;
        private System.Windows.Forms.TextBox tBoxm;
        private System.Windows.Forms.TextBox tBoxl;
        private System.Windows.Forms.TrackBar trackBarL;
        private System.Windows.Forms.Label labelL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.ComboBox RotateAxisSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SplitCountBox;
        private System.Windows.Forms.Button AddPointBtn;
        private System.Windows.Forms.TextBox InputPointX;
        private System.Windows.Forms.TextBox InputPointY;
        private System.Windows.Forms.TextBox InputPointZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button DrawRotateModelBtn;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button RightGo;
        private System.Windows.Forms.Button LeftGo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioGuro;
        private System.Windows.Forms.RadioButton radioEmpty;
    }
}

