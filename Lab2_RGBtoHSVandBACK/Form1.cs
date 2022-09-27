using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2_RGBtoHSVandBACK
{
	public partial class Form1 : Form
	{
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

			if (max == R && G>=B)
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

			double H = (GetHue(R, G, B, min, max) + (h - 1)/2*360) % 360d;
			double S = Math.Min(1, GetSaturation(min, max)*s);
			double V = Math.Min(1, GetValue(min, max) * v);

			return ColorFromHSV(H, S, V);
		}

		public Form1()
		{
			InitializeComponent();
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

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

		private void button1_Click(object sender, EventArgs e)
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

		private void label1_Click(object sender, EventArgs e)
		{

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

		private void button2_Click(object sender, EventArgs e)
		{
			TranformImage((double)hScrollBar1.Value / 100, (double)hScrollBar2.Value / 100, (double)hScrollBar3.Value / 100);
			pictureBox1.Image.Save("SavedImage.png");
			//pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
		}
	}
}
