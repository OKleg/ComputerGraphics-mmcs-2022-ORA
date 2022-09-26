using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab2_Split_to_RGB
{
    public partial class Form1 : Form
    {
        Image SelectedImage;
        public Form1()
        {
            InitializeComponent();
            //setting thing that whole picture will be in box
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
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
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return; // doing nothing if image didnt selected
            Bitmap bmp = new Bitmap(SelectedImage); //setting original image bitmap 
            (int width, int height) = (bmp.Width, bmp.Height); //getting sizes of bitmap (jsut size of working area) 

            int[] X_axis = new int[256]; // 0.255 X axis         

            //Frequency of each 0..255 saturation 
            int[] rc = new int[256];
            int[] gc = new int[256];
            int[] bc = new int[256];

            //creating array of bitmaps for R,G,B 
            Dictionary<Color, Bitmap> bmps = new Dictionary<Color, Bitmap>();
            bmps.Add(Color.Red, new Bitmap(bmp));;
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
            chart3.Series["Series1"].Points.DataBindXY(X_axis, bc);
        }
    }
}
