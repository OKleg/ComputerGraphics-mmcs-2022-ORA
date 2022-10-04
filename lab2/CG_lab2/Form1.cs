using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace CG_lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void SetWorkArea(object sender, EventArgs e)
        {
            var WorkArea = sender as ToolStripMenuItem;

            var wtext = WorkArea.Text;

            (pictureBox1.Width, pictureBox1.Height) = (wtext == "lab3") ? (1218, 588) : (300, 275);
            
            (pictureBox1.Enabled) = (wtext != "lab3")? true : false;

            (pictureBox2.Visible, pictureBox3.Visible, pictureBox4.Visible) = (wtext != "lab3")? (true,true,true) : (false,false,false);          

            (chart1.Visible, chart2.Visible) = (wtext != "lab3") ? (true,true) : (false,false);

            chart3.Visible = (wtext == "RGB")? true : false;
            
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl.Visible = ( wtext != "lab3") ? true : false;
            }           

        }
        private void hVCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetWorkArea(sender, e);
            groupBoxHSV.Visible = true;
            groupBoxHSV.Show();
            if (pictureBox1.Image == null)
            {
                openToolStripMenuItem_Click(sender, e);
            }
            if (label2.Text != "Red") {
                label2.Text = "Red";
                label3.Text = "Green";
                label4.Text = "Blue";
            }
          
        }

        private void rGBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetWorkArea(sender, e);
            groupBoxHSV.Visible = false;

            pictureBox1.Width =300;
            pictureBox1.Width = 275;

            if (pictureBox1.Image != null)
            {
                buttonRGB_Click();
            }
            else
            {
                openToolStripMenuItem_Click(sender, e);
                if (pictureBox1.Image != null)
                {
                    buttonRGB_Click();
                }
            }
            if (label2.Text != "Red")
            {
                label2.Text = "Red";
                label3.Text = "Green";
                label4.Text = "Blue";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkArea(sender, e);
            groupBoxHSV.Visible = false;
            chart1.Visible = true;
            chart2.Visible = true;
            chart3.Visible = false;
            label2.Text = "Gray1"; label2.ForeColor = Color.Black;
            label3.Text = "Gray2"; label3.ForeColor = Color.Black;
            label4.Text = "Dif"; label4.ForeColor = Color.Black;
            if (pictureBox1.Image!=null) {
                Gray(sender, e);
            }
            else
            {
                openToolStripMenuItem_Click(sender, e);
                if (pictureBox1.Image != null)
                {
                    Gray(sender, e);
                }
            }
           
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
             if (groupBoxHSV.Visible)
            {
                openButton3_Click(sender, e);
            }
            else if (label2.Text == "Red")
            {
                openButton2_Click(sender, e);
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image = new Bitmap(ofd.FileName);
                        // Gray(sender, e);
                        SelectedImage = pictureBox1.Image;
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
             if (pictureBox1.Image!=null)
            pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void BresenhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkArea(sender, e);
        }

        private void Gray(object sender, EventArgs e)
        {

            //1
            chart1.Visible = true;
            chart1.Series.Clear();
            chart1.Series.Add("PAL/NTCS");
            chart1.Series["PAL/NTCS"].Color = Color.Gray;
            Dictionary<int, int> h1 = new Dictionary<int, int>();
            //2
            chart2.Visible = true;
            chart2.Series.Clear();
            chart2.Series.Add("HDTV");
            chart2.Series["HDTV"].Color = Color.Gray;
            Dictionary<int, int> h2 = new Dictionary<int, int>();

            if (pictureBox1.Image != null)
            {
                Bitmap input = new Bitmap(pictureBox1.Image);
                Bitmap output1 = new Bitmap(input.Width, input.Height);
                Bitmap output2 = new Bitmap(input.Width, input.Height);
                Bitmap output3 = new Bitmap(input.Width, input.Height);

                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        int R = input.GetPixel(i, j).R;
                        int G = input.GetPixel(i, j).G;
                        int B = input.GetPixel(i, j).B;


                        int gr1 = (int)Math.Round(0.299f * R + 0.587f * G + 0.114f * B);
                        int gr2 = (int)Math.Round(0.2126f * R + 0.7152f * G + 0.0722f * B);
                        int grr = Math.Abs(gr2 - gr1);

                        Color newPixel1 = Color.FromArgb(255, gr1, gr1, gr1);
                        Color newPixel2 = Color.FromArgb(255, gr2, gr2, gr2);
                        Color newPixel3 = Color.FromArgb(255, grr, grr, grr);


                        int value1 = (newPixel1.R) + 1;
                        int value2 = (newPixel2.R) + 1;

                        if (h1.ContainsKey(value1))
                        {
                            h1[value1]++;
                        }
                        else
                        {
                            h1[value1] = 0;
                        }

                        if (h2.ContainsKey(value2))
                        {
                            h2[value2]++;
                        }
                        else
                        {
                            h2[value2] = 0;
                        }

                        output1.SetPixel(i, j, newPixel1);
                        output2.SetPixel(i, j, newPixel2);
                        output3.SetPixel(i, j, newPixel3);
                    }
                pictureBox2.Image = output1;
                pictureBox3.Image = output2;
                pictureBox4.Image = output3;
                //==========================
                foreach (var i in h1)
                {
                    //chart1.CreateGraphics();
                    chart1.Series["PAL/NTCS"].Points.AddXY(i.Key, i.Value);
                }

                foreach (var i in h2)
                {
                    //chart2.CreateGraphics();
                    chart2.Series["HDTV"].Points.AddXY(i.Key, i.Value);
                }
            }

        }
        //============================================================================
        Image SelectedImage;

		public static Color ColorFromHSV(double hue, double saturation, double value)
		{
			int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
			double f = hue / 60 - Math.Floor(hue / 60);

			value = value * 255;
			int v = Convert.ToInt32(value);
			int p = Convert.ToInt32(value * (1 - saturation));
			int q = Convert.ToInt32(value * (1 - f * saturation));
			int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

			if (hi == 0)
				return Color.FromArgb(255, v, t, p);
			else if (hi == 1)
				return Color.FromArgb(255, q, v, p);
			else if (hi == 2)
				return Color.FromArgb(255, p, v, t);
			else if (hi == 3)
				return Color.FromArgb(255, p, q, v);
			else if (hi == 4)
				return Color.FromArgb(255, t, p, v);
			else
				return Color.FromArgb(255, v, p, q);
		}

		private double GetSaturation(double min, double max)
		{
			if (max == 0)
			{
				return 0;
			}
			else
			{
				return 1 - min / max;
			}
		}

		private double GetHue(double R, double G, double B, double min, double max)
		{
			if (max == min)
				return 0;

			if (max == R && G >= B)
			{
				return 60 * (G - B) / (max - min);
			}

			if (max == R && G < B)
			{
				return 60 * (G - B) / (max - min) + 360;
			}

			if (max == G)
			{
				return 60 * (B - R) / (max - min) + 120;
			}

			if (max == B)
			{
				return 60 * (R - G) / (max - min) + 240;
			}

			return 0;
		}

		private double GetValue(double min, double max)
		{
			return max;
		}

		public Color TransformHSV(Color color, double h, double s, double v)
		{
			double R = (double)color.R / 255;
			double G = (double)color.G / 255;
			double B = (double)color.B / 255;

			double max = Math.Max(R, Math.Max(G, B));
			double min = Math.Min(R, Math.Min(G, B));

			double H = (GetHue(R, G, B, min, max) + (h - 1) / 2 * 360) % 360d;
			double S = Math.Min(1, GetSaturation(min, max) * s);
			double V = Math.Min(1, GetValue(min, max) * v);

			return ColorFromHSV(H, S, V);
		}





		public void TranformImage(double h, double s, double v)
		{
			if (SelectedImage == null)
				return;
			Bitmap bitmap_hsv = (Bitmap)(SelectedImage.Clone());

			(int width, int height) = (bitmap_hsv.Width, bitmap_hsv.Height);
			Bitmap newbmp = new Bitmap(width, height);
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					Color clr = bitmap_hsv.GetPixel(x, y);
					newbmp.SetPixel(x, y, TransformHSV(clr, h, s, v));
				}
			}

			pictureBox1.Image = newbmp;
		}

		private void openButton3_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"; //FileDialog filter for images

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					SelectedImage = Image.FromFile(dlg.FileName);
				}

			}
			pictureBox1.Image = SelectedImage;
			//Color clr = ColorFromHSV(235, 0.55, 0.87);
			//Color clr2 = TransformHSV(Color.FromArgb(255, 135, 12, 55), 1, 1, 1);
			TranformImage((double)hScrollBar1.Value / 100, (double)hScrollBar2.Value / 100, (double)hScrollBar3.Value / 100);
		}

		private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{

		}

		private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
		{
		}

		private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
		{

		}

		private void newHVCButton_Click(object sender, EventArgs e)
		{
			TranformImage((double)hScrollBar1.Value / 100, (double)hScrollBar2.Value / 100, (double)hScrollBar3.Value / 100);
			//pictureBox1.Image.Save("SavedImage.png");
			//pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
		}
        //==================================================================================
        private void openButton2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"; //FileDialog filter for images

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SelectedImage = Image.FromFile(dlg.FileName);
                }

            }
            pictureBox1.Image = SelectedImage;
        }


        //Frequency of each 0..255 saturation 
        int[] rc = new int[256];      
        int[] gc = new int[256];    
        int[] bc = new int[256];
         void splitToRed()
        {
            
            Bitmap bmp;
            
            lock (pictureBox1.Image)
            {
                bmp = new Bitmap(pictureBox1.Image);
            }
            (int width, int height) = (bmp.Width, bmp.Height); //getting sizes of bitmap (jsut size of working area) 
           
            Bitmap br = new Bitmap(bmp);
            //get red green blue images
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //get pixel value
                    var rgb = bmp.GetPixel(x, y);

                    //set red green blue bitmaps
                    br.SetPixel(x, y, Color.FromArgb(rgb.A, rgb.R, 0, 0));

                    //counting counts of each 0.255 part of color
                    rc[rgb.R]++;
                }
            }

            //setting images to imageboxes
            pictureBox2.Image = br;


           
        }
        void splitToGreen()
        {
            
            Bitmap bmp;
            lock (pictureBox1.Image) {
                 bmp = new Bitmap(pictureBox1.Image);
            }
            
            (int width, int height) = (bmp.Width, bmp.Height); //getting sizes of bitmap (jsut size of working area) 
          
            Bitmap bg = new Bitmap(bmp);
            //get  green  image
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //get pixel value
                    var rgb = bmp.GetPixel(x, y);

                    //set red green blue bitmaps
                    bg.SetPixel(x, y, Color.FromArgb(rgb.A, 0, rgb.G, 0));

                    //counting counts of each 0.255 part of color
                    gc[rgb.G]++;
                }
            }

            //setting images to imageboxes
            pictureBox3.Image = bg;


            //Draw diagrams by 2 collections, color saturation and count of pixels
           
        }
          void splitToBlue()
        {
            
            Bitmap bmp;
            lock (pictureBox1.Image)
            {
                bmp = new Bitmap(pictureBox1.Image);
            }
            (int width, int height) = (bmp.Width, bmp.Height); //getting sizes of bitmap (jsut size of working area) 
           
            Bitmap bb = new Bitmap(bmp);
            //get red green blue images
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //get pixel value
                    var rgb = bmp.GetPixel(x, y);

                    //set red green blue bitmaps
                    bb.SetPixel(x, y, Color.FromArgb(rgb.A, 0, 0, rgb.B));

                    //counting counts of each 0.255 part of color
                    bc[rgb.B]++;
                }
            }

            //setting images to imageboxes
            pictureBox4.Image = bb;


            //Draw diagrams by 2 collections, color saturation and count of pixels
            
        } 
             
           
        private void buttonRGB_Click()
        {
            label2.ForeColor = Color.Red;
            label3.ForeColor = Color.Green;
            label4.ForeColor = Color.Blue;

            if (pictureBox1.Image == null) return; // doing nothing if image didnt selected
            
           int[] X_axis = new int[256]; // 0.255 X axis      
            //
            ThreadStart redTS = new ThreadStart(splitToRed);
            Thread redThread = new Thread(redTS);
            ThreadStart greenTS = new ThreadStart(splitToGreen);
            Thread greenThread = new Thread(greenTS);
            ThreadStart blueTS = new ThreadStart(splitToBlue);
            Thread blueThread = new Thread(blueTS);
            
            
            
            redThread.Start();
            greenThread.Start();
            blueThread.Start();
           // redThread.Join();
            //greenThread.Join();
            //blueThread.Join();
            while (redThread.IsAlive)
            {

            }
            chart1.Visible = true;
            chart1.Series.Clear();
            chart1.Series.Add("RED");
            chart1.Series["RED"].Color = Color.Red;
            chart1.Series["RED"].Points.DataBindXY(X_axis, rc);
            while (greenThread.IsAlive)
            {

            } 
            chart2.Visible = true;
            chart2.Series.Clear();
            chart2.Series.Add("GREEN");
            chart2.Series["GREEN"].Color = Color.Green;
            chart2.Series["GREEN"].Points.DataBindXY(X_axis, gc);
            while (blueThread.IsAlive)
            {

            }
            chart3.Visible = true;
            chart3.Series.Clear();
            chart3.Series.Add("BLUE");
            chart3.Series["BLUE"].Color = Color.Blue;
            chart3.Series["BLUE"].Points.DataBindXY(X_axis, bc);
            /*Bitmap bmp = new Bitmap(SelectedImage); //setting original image bitmap 
            (int width, int height) = (bmp.Width, bmp.Height); //getting sizes of bitmap (jsut size of working area) 

            int[] X_axis = new int[256]; // 0.255 X axis         

            //Frequency of each 0..255 saturation 
            int[] rc = new int[256];
            int[] gc = new int[256];
            int[] bc = new int[256];

            //creating array of bitmaps for R,G,B 
            Dictionary<Color, Bitmap> bmps = new Dictionary<Color, Bitmap>();
            bmps.Add(Color.Red, new Bitmap(bmp)); ;
            bmps.Add(Color.Green, new Bitmap(bmp));
            bmps.Add(Color.Blue, new Bitmap(bmp));

            //get red green blue images
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //get pixel value
                    var rgb = bmp.GetPixel(x, y);

                    //set red green blue bitmaps
                    bmps[Color.Red].SetPixel(x, y, Color.FromArgb(rgb.A, rgb.R, 0, 0));
                    bmps[Color.Green].SetPixel(x, y, Color.FromArgb(rgb.A, 0, rgb.G, 0));
                    bmps[Color.Blue].SetPixel(x, y, Color.FromArgb(rgb.A, 0, 0, rgb.B));

                    //counting counts of each 0.255 part of color
                    rc[rgb.R]++;
                    gc[rgb.G]++;
                    bc[rgb.B]++;
                }
            }

            //setting images to imageboxes
            pictureBox2.Image = bmps[Color.Red];
            pictureBox3.Image = bmps[Color.Green];
            pictureBox4.Image = bmps[Color.Blue];

            //setting colors for histograms 
            chart1.Series["Series1"].Color = Color.Red;
            chart2.Series["Series1"].Color = Color.Green;
            chart3.Series["Series1"].Color = Color.Blue;

            //Draw diagrams by 2 collections, color saturation and count of pixels
            chart1.Series["Series1"].Points.DataBindXY(X_axis, rc);
            chart2.Series["Series1"].Points.DataBindXY(X_axis, gc);
            chart3.Series["Series1"].Points.DataBindXY(X_axis, bc);*/
        }

        private void buttonHSV_Click(object sender, EventArgs e)
        {
            newHVCButton_Click(sender, e);
            buttonRGB_Click();
        }

        private void buttonOrig_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SelectedImage;
            hScrollBar1.Value = 100;
            hScrollBar2.Value = 100;
            hScrollBar3.Value = 100;
            buttonRGB_Click();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            { 
                pictureBox1.Image.Save("SavedImage.png");
            }
        }

        private void lab2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkArea(sender, e);
        }

        private void lab3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkArea(sender, e);
        }
    }
}
