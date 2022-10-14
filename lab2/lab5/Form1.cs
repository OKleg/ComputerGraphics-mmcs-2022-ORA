using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace lab5
{
    public partial class Form1 : Form
    {
        Graphics g;
        Color color;
        Pen pen;
        PaintEventArgs ev;
        Point p;
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            color = Color.Black;
            pen = new Pen(color);
            PaintEventArgs ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
            Point p = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);

           
        }
        
         private void F()
        {

        }
        private void buttonL_Click(object sender, EventArgs e)
        {
         using ( FileStream fs = File.OpenRead("../../L.txt")){
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    textBox1.Text += temp.GetString(b)+"\n";

                }
            };
            g.DrawLine(pen, p.X, p.Y, (int)((p.X)+10*Math.Tan(45)),  (int)((p.Y) + 10*Math.Tan(45)) );
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            p = e.Location;
            g.DrawEllipse(pen, e.X - 1, e.Y - 1, 3, 3); 
            pictureBox1.Invalidate();
        }
    }
}
