using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace CG_lab2
{
    public partial class Form2 : Form
    {

        public Form1 f1;
        private Graphics g;
        //Bitmap bmp;
        public Form2()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Paint += Draw;
            g = Graphics.FromImage(pictureBox1.Image);
            //g = pictureBox1.CreateGraphics();
            //bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g.Clear(Color.White);
            
        }
        private void Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Close();

        }
        private void lab2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Close();

        }
        private void Form2_FormClosed(object sender, EventArgs e)
        {
            f1.Show();
            this.Close();

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
			radioButTriangle.Checked = radioButTriangle.Checked ? false : true;
		}

        private void button5_Click(object sender, EventArgs e)
        {
            radioButBrez.Checked = radioButBrez.Checked ? false : true;          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            radioButWu.Checked = radioButWu.Checked ? false : true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        //bool backetPaint = false;
        Color bucketColor;

		List<Point> PointsList = new List<Point>();
		Stack<Point> stackToFill = new Stack<Point>();
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap holst = new Bitmap(pictureBox1.Image);
            if ((radioButBrez.Checked || radioButWu.Checked) && e.Button == MouseButtons.Left)
            {
                if (PointsList.Count == 0)
                {
					PointsList.Add(e.Location);

				}
                else
                {
					PointsList.Add(e.Location);

					if (radioButBrez.Checked)
					{
						BresenhamLine(PointsList[0], PointsList[1], colorDialog1.Color);
					}
					else
					{
						Wyline(PointsList[0], PointsList[1]);
					}
					PointsList.Clear();
                }
            }           
            if (radioButBuc.Checked)//|| backetPaint
            {
				stackToFill.Clear();
				bucketColor = colorDialog1.Color;
                Pen p = new Pen(bucketColor);
				Color fromColor = holst.GetPixel(e.X, e.Y);
				Dictionary<Point, bool> dict = new Dictionary<Point, bool>();
				ReDraw(e.Location, fromColor, bucketColor, holst, dict);
				while(stackToFill.Count>0)
				{
					Point pt = stackToFill.Pop();
					ReDraw(pt, fromColor, bucketColor, holst, dict);
				}
                pictureBox1.Invalidate();
            }
			if (radioButTriangle.Checked)
			{
				if (PointsList.Count<2)
				{
					PointsList.Add(e.Location);
				}
				else
				{
					PointsList.Add(e.Location);
					RastrTriangle(PointsList[0], PointsList[1], PointsList[2], Color.Blue, Color.Red, Color.Green);
					PointsList.Clear();
				}
			}
        }
        //floor
        int ipart(double x) { return (int)x; }
        // double part of num
        double fpart(double x)
        {
            return x - ipart(x);
        }
        //1 - double part
        double rfpart(double x)
        {
            return 1 - fpart(x);
        }
        
        //Point placer
        private void Plot(Bitmap bmp,int x, int y, double c, Color penColor)
        {
            int alpha = ipart(c * 255);
            Color color = Color.FromArgb(alpha, penColor);
            bmp.SetPixel(x, y, color);
        }
        //Xiaolin Wu's line algorithm
        private void Wyline(Point p1, Point p2)
        {
            if (p1 == p2) return;
            var bmp = (pictureBox1.Image as Bitmap);
            Pen pen = new Pen(colorDialog1.Color);
            (int x1, int y1) = (p1.X, p1.Y);
            (int x2, int y2) = (p2.X, p2.Y);

            float dx = x2 - x1;
            float dy = y2 - y1;

            var steep = Math.Abs(dy) > Math.Abs(dx);
            if (steep)
            {
                if (y1 > y2)
                {
                    (x1, x2) = (x2, x1);
                    (y1, y2) = (y2, y1);
                }
            }
            else
            {
                if (x1 > x2)
                {
                    (x1, x2) = (x2, x1);
                    (y1, y2) = (y2, y1);
                }
            }

            bmp.SetPixel(x2, y2, pen.Color);
            pictureBox1.Invalidate();
            float gradient = steep ? dx / dy : dy / dx;
            float intery = steep ? x1 + gradient : y1 + gradient;

            if (steep)
            {
                for (var y = y1 + 1; y <= y2 - 1; y++)
                {
                    Plot(bmp, ipart(intery), y, rfpart(intery), pen.Color);
                    Plot(bmp, ipart(intery) + 1, y, fpart(intery), pen.Color);
                    pictureBox1.Invalidate();
                    intery += gradient;
                }
            }
            else
            {
                for (var x = x1 + 1; x <= x2 - 1; x++)
                {
                    Plot(bmp, x, ipart(intery), rfpart(intery), pen.Color);
                    Plot(bmp, x, ipart(intery) + 1, fpart(intery), pen.Color);
                    pictureBox1.Invalidate();
                    intery += gradient;
                }
            }
            //pictureBox1.Image = bmp;
            pictureBox1.Invalidate();
        }       

        private void BresenhamLine(Point p1, Point p2, Color clr)
        {
            var bmp = (pictureBox1.Image as Bitmap);

			if (p1 == p2)
			{
				bmp.SetPixel(p1.X, p1.Y, clr);
				pictureBox1.Invalidate();
				return;
			}
			//Color color = Color.Black;          
			//delta
			int dx = Math.Abs(p2.X - p1.X);
            int dy = Math.Abs(p2.Y - p1.Y);
            
            //signs, to where go
            int sx = p1.X < p2.X ? 1 : -1;
            int sy = p1.Y < p2.Y ? 1 : -1;

            int err = (dx > dy ? dx : -dy) / 2;
            int e2;

            while (p1.X != p2.X || p1.Y != p2.Y)
            {
                bmp.SetPixel(p1.X, p1.Y, clr);
                e2 = err;
                if (e2 > -dx)
                {
                    err -= dy;
                    p1.X += sx;
                }
                if (e2 < dy)
                {
                    err += dx;
                    p1.Y += sy;
                }
            }
			pictureBox1.Invalidate();
			//pictureBox1.Image = bmp;
		}


		private void pen_Click(object sender, EventArgs e)
        {
             radioButPen.Checked = radioButPen.Checked ?  false : true;
            
			pictureBox1.MouseMove += pictureBox1_MouseMove;
        }

        int OldX=0, oldY=0;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButPen.Checked)
            {
                OldX = e.X;
                oldY = e.Y;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (radioButPen.Checked && e.Button == MouseButtons.Left)
            {
                Pen p = new Pen(colorDialog1.Color, 2);
                //g.DrawEllipse(p, e.X, e.Y, 2, 2);
                g.DrawLine(p, OldX, oldY, e.X, e.Y);
                //pen.Dispose();
                g = Graphics.FromImage(pictureBox1.Image);
                pictureBox1.Invalidate();
                OldX = e.X;
                oldY = e.Y;
            }
        }




        private void Clean_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //отображается ли кнопка "Справка" в диалоговом окне
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        pictureBox1.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            radioButBuc.Checked = radioButBuc.Checked ? false : true;
            //pictureBox1.MouseMove -= pictureBox1_MouseMove;
            

        }
             
        private void ReDraw(Point point, Color fromColor, Color toColor, Bitmap holst, Dictionary<Point, bool> dict)
        {
			if (dict.Count > 100000)
				return;
			if (dict.ContainsKey(point))
				return;
			dict[point] = true;

			if (fromColor == toColor)
				return;


			var bmp = (pictureBox1.Image as Bitmap);

			if (bmp.GetPixel(point.X, point.Y) != fromColor)
				return;

			Point left = point;
			while (left.X>0 && holst.GetPixel(left.X-1, left.Y) == fromColor)
				left.X--;

			Point right = point;
			while (right.X+1 < holst.Width && holst.GetPixel(right.X+1, right.Y) == fromColor)
				right.X++;

			for (int i = left.X; i <= right.X; ++i)
			{
				dict[new Point(i, point.Y)] = true;
				bmp.SetPixel(i, point.Y, toColor);
				pictureBox1.Invalidate();
				if (point.Y + 1 < holst.Height)
				{
					Point up = new Point(i, point.Y + 1);
					if (!dict.ContainsKey(up))
						stackToFill.Push(up);
				}
				if (point.Y - 1>0) 
				{
					
					Point down = new Point(i, point.Y - 1);
					if (!dict.ContainsKey(down))
						stackToFill.Push(down);
				}
			}
		}
		//For Task3

		private void BresenhamLineGradient(Point p1, Point p2, Color clr1, Color clr2)
		{
			if (p1 == p2) 
				return;
			var bmp = (pictureBox1.Image as Bitmap);
			//Color color = Color.Black;          
			//delta
			int dx = Math.Abs(p2.X - p1.X);
			int dy = Math.Abs(p2.Y - p1.Y);

			//signs, to where go
			int sx = p1.X < p2.X ? 1 : -1;
			int sy = p1.Y < p2.Y ? 1 : -1;

			int err = (dx > dy ? dx : -dy) / 2;
			int e2;

			Point pt = p1;

			//Count steps
			int steps = 0;
			while (pt.X != p2.X || pt.Y != p2.Y)
			{
				steps++;
				e2 = err;
				if (e2 > -dx)
				{
					err -= dy;
					pt.X += sx;
				}
				if (e2 < dy)
				{
					err += dx;
					pt.Y += sy;
				}
			}

			int step = 0;
			while (p1.X != p2.X || p1.Y != p2.Y)
			{
				Color clr;
				clr = Color.FromArgb(clr1.R + (clr2.R - clr1.R) * step / steps, clr1.G + (clr2.G - clr1.G) * step / steps, clr1.B + (clr2.B - clr1.B) * step / steps);
				bmp.SetPixel(p1.X, p1.Y, clr);
				pictureBox1.Invalidate();
				e2 = err;
				if (e2 > -dx)
				{
					err -= dy;
					p1.X += sx;
				}
				if (e2 < dy)
				{
					err += dx;
					p1.Y += sy;
				}

				step++;
			}
		}

		private class GradientLeftRight
		{
			public int left_x;
			public int right_x;
			public Color left_Color;
			public Color right_Color;

			public GradientLeftRight(int left_x, int right_x, Color left_Color, Color right_Color)
			{
				this.left_x = left_x;
				this.right_x = right_x;
				this.left_Color = left_Color;
				this.right_Color = right_Color;
			}
		}

		//Key in Dict is y
		private void BresenhamLineGradientForEdge(Point p1, Point p2, Color clr1, Color clr2, Dictionary<int, GradientLeftRight> dict)
		{
			if (p1 == p2) return;
			var bmp = (pictureBox1.Image as Bitmap);
			//Color color = Color.Black;          
			//delta
			int dx = Math.Abs(p2.X - p1.X);
			int dy = Math.Abs(p2.Y - p1.Y);

			//signs, to where go
			int sx = p1.X < p2.X ? 1 : -1;
			int sy = p1.Y < p2.Y ? 1 : -1;

			int err = (dx > dy ? dx : -dy) / 2;
			int e2;

			Point pt = p1;

			//Count steps
			int steps = 0;
			while (pt.X != p2.X || pt.Y != p2.Y)
			{
				steps++;
				e2 = err;
				if (e2 > -dx)
				{
					err -= dy;
					pt.X += sx;
				}
				if (e2 < dy)
				{
					err += dx;
					pt.Y += sy;
				}
			}

			int step = 0;
			while (p1.X != p2.X || p1.Y != p2.Y)
			{
				Color clr;
				clr = Color.FromArgb(clr1.R + (clr2.R - clr1.R) * step / steps, clr1.G + (clr2.G - clr1.G) * step / steps, clr1.B + (clr2.B - clr1.B) * step / steps);
				if (dict.ContainsKey(p1.Y))
				{
					if (dict[p1.Y].left_x > p1.X)
					{
						dict[p1.Y].left_x = p1.X;
						dict[p1.Y].left_Color = clr;
					}
					if (dict[p1.Y].right_x < p1.X)
					{
						dict[p1.Y].right_x = p1.X;
						dict[p1.Y].right_Color = clr;
					}
					
				}
				else
					dict.Add(p1.Y, new GradientLeftRight(p1.X, p1.X, clr, clr));
				step++;

				bmp.SetPixel(p1.X, p1.Y, clr);
				pictureBox1.Invalidate();
				e2 = err;
				if (e2 > -dx)
				{
					err -= dy;
					p1.X += sx;
				}
				if (e2 < dy)
				{
					err += dx;
					p1.Y += sy;
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{

		}

		private void radioButBuc_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void RastrTriangle(Point p1, Point p2, Point p3, Color c1, Color c2, Color c3)
		{
			Dictionary<int, GradientLeftRight> dict = new Dictionary<int, GradientLeftRight>();
			BresenhamLineGradientForEdge(p1, p2, c1, c2, dict);
			BresenhamLineGradientForEdge(p1, p3, c1, c3, dict);
			BresenhamLineGradientForEdge(p2, p3, c2, c3, dict);

			foreach (var t in dict)
			{
				int y = t.Key;
				Point pt1 = new Point(t.Value.left_x, y);
				Point pt2 = new Point(t.Value.right_x, y);
				BresenhamLineGradient(pt1, pt2, t.Value.left_Color, t.Value.right_Color);
			}
		}

        /*     private void ReDraw(Point start,Pen p, Bitmap holst)
         {   
             if (start.X <= 0 || start.Y<=0 
                 || start.X>=holst.Width || start.Y>=holst.Height) return;
             Color now = holst.GetPixel(start.X, start.Y);
             Point left = start, right = start;
             if (left.X>1)
                 left.X--;
             if (right.X < holst.Width-1)
                 right.X++;
             Color previous = holst.GetPixel(left.X, left.Y);
             while (left.X > 1 && previous == now )
             {
                 // if (holst.GetPixel(left.X, left.Y)!=bucketColor)\

                 left.X--;
                 previous = holst.GetPixel(left.X-1, left.Y);
             }
             Color leftCol = holst.GetPixel(left.X, left.Y);
             Color next = holst.GetPixel(right.X, right.Y);
             while (right.X < pictureBox1.Width-1 && next == now)
             {
                 // if (holst.GetPixel(left.X, left.Y)!=bucketColor)

                 right.X++;
                 next = holst.GetPixel(right.X, right.Y);
             }
             g.DrawLine(p, left, right);
             pictureBox1.Invalidate();
             Point up = left, down = left;
             up.Y++;
             down.Y--;
             //bool u = true,d = true;
             //ReDraw(up, p);
             for (int i = ++left.X; i <= --right.X; i++)
             {
                 if ( holst.GetPixel(up.X, up.Y) == now && up.Y < holst.Height-1)
                 { 
                     ReDraw(up, p,holst);
                     up.Y++;
                     break;
                 }
             }
             for (int i = ++left.X; i <= --right.X; i++)
             {
                 if ( holst.GetPixel(down.X, down.Y) == now && down.Y > 1)
                 {
                     ReDraw(down, p, holst);
                     down.Y--;
                     break;
                 }
             }
         }*/
        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            buttonColor.BackColor = colorDialog1.Color;
        }

      
    }
}
